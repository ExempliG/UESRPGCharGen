using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace UESRPG_Character_Manager.UI.MainWindow
{
    public partial class MainWindow : Form
    {
        private string _currentFile = "";
        private Character _activeCharacter;

        private const string _FileTypeString = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        private bool _characterStatsMutex = false;
        private bool _updatingDataBindings = false;

        public MainWindow ()
        {
            InitializeComponent ();

            // Subscribe Character views to the character change event
            characterSelector.SelectedCharacterChanged += OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += charaView_statsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += attributesView_statsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += skillListView_statsPage.OnSelectedCharacterChanged;
            characterSelector.ForceUpdate();
            charaView_statsPage.CharacteristicChanged += attributesView_statsPage.OnCharacteristicChanged;

            /*CUSTOM EVENT BINDINGS*/
            this.rollResultTb.TextChanged += softRoll;
            this.characterNotesRtb.LostFocus += characterNotesRtb_LostFocus;
            /*END CUSTOM EVENT BINDINGS*/

            saveMi.Enabled = false;

            armorLocationCb.DataSource = ArmorLocationsData.Names;
            hitLocationCb.DataSource = ArmorLocationsData.Names;
            armorTypeCb.DataSource = ArmorQualityData.Names;
            armorMaterialCb.DataSource = ArmorTypeData.Names;
            armorQualityCb.DataSource = ArmorMaterialData.Names;

            for (int i = 0; i < (int)WeaponType.MAX; i++)
            {
                weaponTypeCb.Items.Add ((WeaponType)i);
            }
            weaponTypeCb.SelectedIndex = 0;

            for (int i = 0; i < (int)WeaponMaterial.MAX; i++)
            {
                weaponMaterialCb.Items.Add ((WeaponMaterial)i);
            }
            weaponMaterialCb.SelectedIndex = 0;

            foreach (string characteristic in Characteristics.CharacteristicNames)
            {
                characteristicCb.Items.Add (characteristic);
            }

            characteristicCb.SelectedIndex = 0;

            updateDataBindings();
        }

        private void OnSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();
        }

        private void characterNotesRtb_LostFocus(object sender, EventArgs e)
        {
            SelectedCharacter().Notes = characterNotesRtb.Text;
        }

        private Character SelectedCharacter ()
        {
            //return characterSelector.GetActiveCharacter();
            return _activeCharacter;
        }

        private void nameTb_TextChanged (object sender, EventArgs e)
        {
            SelectedCharacter ().Name = nameTb.Text;
        }

        /// <summary>
        /// Update all UI elements with Data Bindings.
        /// </summary>
        /// <todo>Refactor this to reduce code repetition</todo>
        private void updateDataBindings ()
        {
            _updatingDataBindings = true;

            armorDgv.DataSource = null;
            if (SelectedCharacter ().ArmorPieces.Count > 0)
            {
                armorDgv.DataSource = SelectedCharacter ().ArmorPieces;
            }

            weaponsDgv.DataSource = null;
            weaponCb.DataSource = null;
            if (SelectedCharacter ().Weapons.Count > 0)
            {
                weaponsDgv.DataSource = SelectedCharacter ().Weapons;
                weaponCb.DataSource = SelectedCharacter ().Weapons;
            }

            spellsDgv.DataSource = null;
            spellsCb.DataSource = null;
            if (SelectedCharacter ().Spells.Count > 0)
            {
                spellsDgv.DataSource = SelectedCharacter ().Spells;
                spellsCb.DataSource = SelectedCharacter().Spells;
            }

            int selectedIndex = skillsCb.SelectedIndex;
            skillsCb.Items.Clear ();

            for (int i = 0; i < SelectedCharacter ().Skills.Count; i++)
            {
                Skill skill = SelectedCharacter ().Skills[i];
                skillsCb.Items.Add (skill);
            }
            if (selectedIndex < skillsCb.Items.Count && selectedIndex != -1)
            {
                skillsCb.SelectedIndex = selectedIndex;
            }
            else if (skillsCb.Items.Count >= 1)
            {
                skillsCb.SelectedIndex = 0;
            }
            else
            {
                // do nothing
            }

            _updatingDataBindings = false;
        }

        private void skillsCb_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (skillRb.Checked)
            {
                updateCharacteristicCb ();
            }
        }

        /// <summary>
        /// This function will determine which Characteristics govern the selected skill and remove all other Characteristics from the Characteristic CB.
        /// </summary>
        private void updateCharacteristicCb ()
        {
            object selectedItem = skillsCb.SelectedItem;
            if (selectedItem != null && skillRb.Checked)
            {
                Skill skill = (Skill)selectedItem;
                characteristicCb.Items.Clear ();
                foreach (int characteristic in skill.Characteristics)
                {
                    characteristicCb.Items.Add (Characteristics.CharacteristicNames[characteristic]);
                }
                if (characteristicCb.Items.Count > 0)
                {
                    characteristicCb.SelectedIndex = 0;
                }
            }
            else
            {
                reloadCharacteristicCb ();
            }
        }

        /// <summary>
        /// Restores the Characteristics CB to include all Characteristics.
        /// </summary>
        private void reloadCharacteristicCb ()
        {
            characteristicCb.Items.Clear ();
            foreach (string characteristic in Characteristics.CharacteristicNames)
            {
                characteristicCb.Items.Add (characteristic);
            }
            characteristicCb.SelectedIndex = 0;
        }

        /// <summary>
        /// Will filter the Characteristic combobox for the selected skill and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillRb_CheckedChanged (object sender, EventArgs e)
        {
            updateCharacteristicCb ();
            extraDifficultyNud.Value = 0;

            softRoll (sender, e);
        }

        /// <summary>
        /// Will filter the Characteristic combobox for the selected skill and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicRb_CheckedChanged (object sender, EventArgs e)
        {
            updateCharacteristicCb ();
            extraDifficultyNud.Value = 0;

            softRoll (sender, e);
        }

        /// <summary>
        /// Rolls against selected parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="extraDifficulty">An extra difficulty modifier, in case a particular check is harder or easier</param>
        /// <todo>Expose the extraDifficulty modifier somewhere</todo>
        private void rollBt_Click (object sender, EventArgs e)
        {
            Random r = new Random ();

            int result = r.Next (1, 100);
            rollResultTb.Text = "" + result;

            softRoll (sender, e);
        }

        /// <summary>
        /// A soft roll performs all of the calculations of a regular roll, but does not change the roll result.
        /// This is useful for using outside roll values with the app, since we don't want to replace the player's
        /// entered roll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void softRoll (object sender, EventArgs e)
        {
            int extraDifficulty = (int)extraDifficultyNud.Value;
            softRoll (sender, e, extraDifficulty);
        }

        /// <summary>
        /// A soft roll performs all of the calculations of a regular roll, but does not change the roll result.
        /// This is useful for using outside roll values with the app, since we don't want to replace the player's
        /// entered roll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <todo> We can probably encapsulate this further by containing all the Skill/Characteristic Check logic in the Character class.</todo>
        private void softRoll (object sender, EventArgs e, int extraDifficulty)
        {
            bool isSkillRoll = skillRb.Checked;
            bool success = true;

            int result = 0;
            if (int.TryParse (rollResultTb.Text, out result))
            {
                updateCriticalLabel(result);
                updateHitLocationLabel(result);

                int difference = 0;

                int characteristicIndex = 0;
                int characteristic = 0;

                if (isSkillRoll)
                {
                    if (skillsCb.Items.Count >= 1)
                    {
                        Skill skill = (Skill)skillsCb.SelectedItem;

                        characteristicIndex = skill.Characteristics[characteristicCb.SelectedIndex];
                        characteristic = SelectedCharacter().GetCharacteristic(characteristicIndex);

                        int skillLevel = skill.Rank;
                        rollBreakdownTb.Text = string.Format("({0} + skill {1} + diff {2}) - {3} =",
                                                             characteristic,
                                                             skillLevel * 10,
                                                             extraDifficulty,
                                                             result);
                        characteristic = (characteristic + (skillLevel * 10) + extraDifficulty);
                    }
                    else
                    {
                        success = false;
                    }
                }
                else   // Otherwise it's a Characteristic roll
                {
                    characteristicIndex = characteristicCb.SelectedIndex;
                    characteristic = SelectedCharacter ().GetCharacteristic (characteristicIndex);
                    rollBreakdownTb.Text = string.Format("({0} + diff {1}) - {2} =",
                                                         characteristic,
                                                         extraDifficulty,
                                                         result);
                    characteristic += extraDifficulty;
                }

                if (success)
                {
                    difference = (characteristic - result);

                    int successes = SelectedCharacter().GetBonus(difference);

                    rollBreakdownTb.Text += String.Format("{0}", difference);
                    rollSuccessesTb.Text = "" + successes;
                }
                else
                {
                    rollBreakdownTb.Text = "No skill selected!";
                }
            }
        }

        /// <summary>
        /// Will update the "Critical" label for a given rollResult based on the currently-selected Character.
        /// </summary>
        /// <param name="rollResult">The roll result used to update.</param>
        private void updateCriticalLabel(int rollResult)
        {
            int luck = SelectedCharacter().Luck;
            if (rollResult <= SelectedCharacter().GetBonus(luck))
            {
                successOrFailLb.Text = "Critical success!";
                successOrFailLb.Visible = true;
            }
            else if (rollResult >= (95 + SelectedCharacter().GetBonus(luck)))
            {
                successOrFailLb.Text = "Critical failure!";
                successOrFailLb.Visible = true;
            }
            else
            {
                successOrFailLb.Visible = false;
            }
        }

        private void updateHitLocationLabel(int rollResult)
        {
            int tensDigit = (rollResult / 10);
            int tensComponent = tensDigit * 10;
            int onesComponent = rollResult - tensComponent;

            if(onesComponent == 0)
            {
                hitLocationLb.Text = "Head!";
            }
            else if(onesComponent >= 1 && onesComponent <= 2)
            {
                hitLocationLb.Text = "Right Arm!";
            }
            else if(onesComponent >= 3 && onesComponent <= 4)
            {
                hitLocationLb.Text = "Left Arm!";
            }
            else if(onesComponent >= 5 && onesComponent <= 7)
            {
                hitLocationLb.Text = "Body!";
            }
            else if(onesComponent == 8)
            {
                hitLocationLb.Text = "Right Leg!";
            }
            else if (onesComponent == 9)
            {
                hitLocationLb.Text = "Left Leg!";
            }
            hitLocationLb.Visible = true;
        }

        /// <summary>
        /// This function is bound to our NumericUpDowns' GotFocus event. It will cause the numeric values to be highlighted when tabbed into.
        /// </summary>
        private void NumberBoxFocus (object sender, EventArgs e)
        {
            NumericUpDown theNb = (NumericUpDown)sender;
            theNb.Select (0, 3);
        }

        /// <summary>
        /// Performs the saving of a Character list.
        /// </summary>
        /// <param name="fileName">The filename to save the list as.</param>
        private void SaveChar (string fileName)
        {
            XmlSerializer xml = new XmlSerializer (typeof (List<Character>));
            FileStream fs = new FileStream (fileName, FileMode.Create);
            try
            {
                List<Character> listToSave = characterSelector.GetCharacterList();
                foreach (Character c in listToSave)
                {
                    c.EngVersion = Program.CurrentEngVersion;
                    c.MinorVersion = Program.CurrentMinorVersion;
                    c.MajorVersion = Program.CurrentMinorVersion;
                }

                xml.Serialize (fs, listToSave);
                _currentFile = fileName;
                saveMi.Enabled = true;
            }
            catch (IOException e)
            {
                MessageBox.Show (string.Format ("File was not saved successfully for reason:\n{0}", e.Message));
            }
            finally
            {
                fs.Close ();
            }
        }

        /// <summary>
        /// Handle the loading of a Character list.
        /// </summary>
        /// <todo>Re-evaluate this whole mess.</todo>
        private void LoadChar ()
        {
            OpenFileDialog ofd = new OpenFileDialog ();
            ofd.DefaultExt = ".xml";
            ofd.Filter = _FileTypeString;
            ofd.ShowDialog();

            string fileName = ofd.FileName;

            if (!string.IsNullOrEmpty (fileName))
            {
                XmlSerializer xml = new XmlSerializer (typeof (List<Character>));
                FileStream fs = new FileStream (fileName, FileMode.Open);

                try
                {
                    List<Character> loadedList = (List<Character>)xml.Deserialize (fs);

                    //_characterList = loadedList;
                    _currentFile = fileName;
                    saveMi.Enabled = true;

                    foreach (Character c in loadedList)
                    {
                        // Perform any necessary updates.
                        c.Update ();
                    }

                    characterSelector.LoadCharacterList(loadedList);
                }
                catch (IOException)
                {

                }
                finally
                {
                    fs.Close ();
                }

                nameTb.Text = SelectedCharacter ().Name;

                updateDataBindings();
            }
        }

        private void addNewArmorBt_Click (object sender, EventArgs e)
        {
            double ar = Armor.CalculateAR ((ArmorTypes)armorMaterialCb.SelectedIndex,
                                           (ArmorMaterials)armorQualityCb.SelectedIndex,
                                           (ArmorQualities)armorTypeCb.SelectedIndex);
            SelectedCharacter ().AddArmorPiece (new Armor (armorNameTb.Text, ar, 0, 0, (ArmorLocations)armorLocationCb.SelectedIndex, null));
            updateDataBindings ();
        }

        private void saveMi_Click (object sender, EventArgs e)
        {
            SaveChar (_currentFile);
        }

        private void saveAsMi_Click (object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog ();
            sfd.AddExtension = true;
            sfd.DefaultExt = ".xml";
            sfd.Filter = _FileTypeString;
            DialogResult result = sfd.ShowDialog ();

            string fileName = sfd.FileName;
            if (!string.IsNullOrEmpty (fileName) && result == DialogResult.OK)
            {
                SaveChar (fileName);
            }
        }

        private void loadMi_Click (object sender, EventArgs e)
        {
            LoadChar ();
        }


/// <todo>YOU SHOULD REALLY SPLIT MAINWINDOW INTO RELEVANT PARTIAL CLASSES, MOSTLY BELOW THIS LINE</todo>


        private void receivedDamage_ParameterChange (object sender, EventArgs e)
        {
            updateDamage ();
        }

        /// <summary>
        /// Calculate the total damage received to a particular location.
        /// </summary>
        private void updateDamage ()
        {
            int damage = 0;
            int pen = 0;
            ArmorLocations location = (ArmorLocations)hitLocationCb.SelectedIndex;

            if (int.TryParse (receivedDamageTb.Text, out damage) && int.TryParse (receivedPenTb.Text, out pen))
            {
                double armorMitigation = SelectedCharacter ().GetArmorPiece (location).AR;
                armorMitigation = Math.Max(armorMitigation - pen, 0);                       // Pen reduces armorMitigation to a lower limit of zero.
                damage = Math.Max(damage - (int)armorMitigation, 0);                        // armorMitigation then reduces received damage to a lower limit of zero.

                finalDamageReceivedTb.Text = damage.ToString ();
            }
        }

        private void applyDamageBt_Click (object sender, EventArgs e)
        {
            int damage;
            if (int.TryParse (finalDamageReceivedTb.Text, out damage))
            {
                SelectedCharacter ().CurrentHealth -= damage;
            }
        }

        private void armorDataGridView_ChangeOccurred (object sender, EventArgs e)
        {
            updateDamage ();
        }

        private void addNewWeaponBt_Click (object sender, EventArgs e)
        {
            WeaponType type = (WeaponType)weaponTypeCb.SelectedItem;
            WeaponMaterial material = (WeaponMaterial)weaponMaterialCb.SelectedItem;

            Weapon template = WeaponTemplates.DefaultWeapons[(int)type];
            WeaponMaterialModifier modifier = WeaponTemplates.Materials[(int)material];

            Weapon result = (template * modifier);
            result.Name = weaponNameTb.Text;

            SelectedCharacter ().Weapons.Add (result);
            updateDataBindings ();
        }

        private void weaponRollBt_Click (object sender, EventArgs e)
        {
            Random r = new Random ();

            Weapon selectedWeapon = (Weapon)weaponCb.SelectedItem;
            int resultTotal = 0;
            string breakdownString = "";

            for (int i = 0; i < selectedWeapon.NumberOfDice; i++)
            {
                int roll = r.Next (1, selectedWeapon.DiceSides);
                breakdownString += string.Format ("{0} + ", roll);
                resultTotal += roll;
            }

            breakdownString += string.Format ("{0} + bonus {1}", selectedWeapon.DamageMod, SelectedCharacter().DamageBonus);
            resultTotal += selectedWeapon.DamageMod;
            resultTotal += SelectedCharacter().DamageBonus;

            weaponResultTb.Text = string.Format ("{0} pen {1}", resultTotal, selectedWeapon.Penetration);
            weaponResultBreakdownTb.Text = breakdownString;
        }

        private void spellRollBt_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Spell selectedSpell = (Spell)spellsCb.SelectedItem;
            int resultTotal = 0;
            string breakdownString = "";

            for (int i = 0; i < selectedSpell.NumberOfDice; i++)
            {
                string formatString;

                if (i == selectedSpell.NumberOfDice - 1)
                {
                    formatString = "{0}";
                }
                else
                {
                    formatString = "{0} + ";
                }

                int roll = r.Next(1, selectedSpell.DiceSides);
                breakdownString += string.Format(formatString, roll);
                resultTotal += roll;
            }

            spellResultTb.Text = string.Format("{0} pen {1}", resultTotal, selectedSpell.Penetration);
            spellResultBreakdownTb.Text = breakdownString;
        }

        private void weaponCb_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (weaponCb.SelectedIndex > -1 && weaponCb.SelectedItem.GetType () == typeof (Weapon))
            {
                weaponRollBt.Enabled = true;
            }
            else
            {
                weaponRollBt.Enabled = false;
            }
        }

        private void addSpellBt_Click (object sender, EventArgs e)
        {
            EditSpell es = new EditSpell (SelectedCharacter ());
            es.ShowDialog ();
            updateDataBindings ();
        }

        private void spellsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allowRoll = false;

            if (spellsCb.Items.Count > 0)
            {
                if (spellsCb.SelectedItem != null && spellsCb.SelectedItem.GetType() == typeof(Spell))
                {
                    Spell selectedSpell = (Spell)spellsCb.SelectedItem;

                    // Set up the skill roll for the user, assuming this event was not triggered in updateDataBindings.
                    if (!_updatingDataBindings)
                    {
                        skillRb.Checked = true;
                        IEnumerable<Skill> skillSearch = from skill in SelectedCharacter().Skills
                                                         where skill.Name == selectedSpell.AssociatedSkill
                                                         select skill;
                        if (skillSearch.Count() == 1)
                        {
                            int skillIndex = skillsCb.Items.IndexOf(skillSearch.ElementAt(0));
                            skillsCb.SelectedIndex = skillIndex;
                            extraDifficultyNud.Value = selectedSpell.Difficulty;
                        }
                    }

                    allowRoll = selectedSpell.DoesDamage;
                }
            }

            spellRollBt.Enabled = allowRoll;
        }

        private void notesCommitChangesBt_Click(object sender, EventArgs e)
        {
            SelectedCharacter().Notes = characterNotesRtb.Text;
        }
    }
}
