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

namespace UESRPG_Character_Manager
{
    public partial class MainWindow : Form
    {
        private List<Character> _characterList;
        private Character _selectedChar;
        private int _selectedIndex = 0;
        private string _currentFile = "";

        private const string _FileTypeString = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        private bool _characterStatsMutex = false;

        public MainWindow ()
        {
            InitializeComponent ();

            /*CUSTOM EVENT BINDINGS*/
            this.rollResultTb.TextChanged += softRoll;
            /*END CUSTOM EVENT BINDINGS*/

            saveMi.Enabled = false;

            _characterList = new List<Character> ();
            _selectedChar = new Character ();
            _characterList.Add (_selectedChar);

            charactersCb.Items.Add (_selectedChar.Name);
            charactersCb.SelectedIndex = 0;
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

            skillsCb.Items.Add ("Untrained");
            skillsCb.SelectedIndex = 0;
        }

        private Character SelectedCharacter ()
        {
            return _characterList[_selectedIndex];
        }

        private void nameTb_TextChanged (object sender, EventArgs e)
        {
            SelectedCharacter ().Name = nameTb.Text;
            charactersCb.Items[_selectedIndex] = nameTb.Text;
        }

        /// <summary>
        /// A characteristic changed, so we will update all the character's values/mods and re-calculate the calculated fields.
        /// This function will do nothing if Characteristics are currently being updated somewhere else.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicChanged (object sender, EventArgs e)
        {
            if (!_characterStatsMutex)
            {
                _characterStatsMutex = true;
                SelectedCharacter ().Strength = (int)nbStrength.Value;
                SelectedCharacter ().Endurance = (int)nbEndurance.Value;
                SelectedCharacter ().Agility = (int)nbAgility.Value;
                SelectedCharacter ().Intelligence = (int)nbIntelligence.Value;
                SelectedCharacter ().Willpower = (int)nbWillpower.Value;
                SelectedCharacter ().Perception = (int)nbPerception.Value;
                SelectedCharacter ().Personality = (int)nbPersonality.Value;
                SelectedCharacter ().Luck = (int)nbLuck.Value;

                int health = 0;
                int.TryParse (healthTb.Text, out health);
                SelectedCharacter ().CurrentHealth = health;
                int stamina = 0;
                int.TryParse (staminaTb.Text, out stamina);
                SelectedCharacter ().CurrentStamina = stamina;
                int magicka = 0;
                int.TryParse (magickaTb.Text, out magicka);
                SelectedCharacter ().CurrentMagicka = magicka;
                int luck = 0;
                int.TryParse (luckPointsTb.Text, out luck);
                SelectedCharacter ().CurrentLuckPoints = luck;
                int ap = 0;
                int.TryParse (actionPointsTb.Text, out ap);
                SelectedCharacter ().CurrentAp = ap;

                SelectedCharacter ().HealthMod = (int)nbModHealth.Value;
                SelectedCharacter ().WoundThresholdMod = (int)nbModWoundThreshold.Value;
                SelectedCharacter ().StaminaMod = (int)nbModStamina.Value;
                SelectedCharacter ().MagickaMod = (int)nbModMagicka.Value;
                SelectedCharacter ().ActionPointsMod = (int)nbModActionPoints.Value;
                SelectedCharacter ().MovementRatingMod = (int)nbModMovementRating.Value;
                SelectedCharacter ().CarryRatingMod = (int)nbModCarryRating.Value;
                SelectedCharacter ().InitiativeRatingMod = (int)nbModInitiativeRating.Value;
                SelectedCharacter ().DamageBonusMod = (int)nbModDamageBonus.Value;
                SelectedCharacter ().LuckPointsMod = (int)nbModLuck.Value;

                updateCalculatedFields ();
                _characterStatsMutex = false;
            }
        }

        /// <summary>
        /// Update the UI representation of the character to match its data.
        /// This function will do nothing if Characteristics are currently being updated somewhere else.
        /// </summary>
        private void refreshUIRepresentation ()
        {
            if (!_characterStatsMutex)
            {
                _characterStatsMutex = true;
                nbStrength.Value = SelectedCharacter ().Strength;
                nbEndurance.Value = SelectedCharacter ().Endurance;
                nbAgility.Value = SelectedCharacter ().Agility;
                nbIntelligence.Value = SelectedCharacter ().Intelligence;
                nbWillpower.Value = SelectedCharacter ().Willpower;
                nbPerception.Value = SelectedCharacter ().Perception;
                nbPersonality.Value = SelectedCharacter ().Personality;
                nbLuck.Value = SelectedCharacter ().Luck;

                healthTb.Text = SelectedCharacter ().CurrentHealth.ToString ();
                staminaTb.Text = SelectedCharacter ().CurrentStamina.ToString ();
                magickaTb.Text = SelectedCharacter ().CurrentMagicka.ToString ();
                luckPointsTb.Text = SelectedCharacter ().CurrentLuckPoints.ToString ();
                actionPointsTb.Text = SelectedCharacter ().CurrentAp.ToString ();

                nbModHealth.Value = SelectedCharacter ().HealthMod;
                nbModWoundThreshold.Value = SelectedCharacter ().WoundThresholdMod;
                nbModStamina.Value = SelectedCharacter ().StaminaMod;
                nbModMagicka.Value = SelectedCharacter ().MagickaMod;
                nbModActionPoints.Value = SelectedCharacter ().ActionPointsMod;
                nbModMovementRating.Value = SelectedCharacter ().MovementRatingMod;
                nbModCarryRating.Value = SelectedCharacter ().CarryRatingMod;
                nbModInitiativeRating.Value = SelectedCharacter ().InitiativeRatingMod;
                nbModDamageBonus.Value = SelectedCharacter ().DamageBonusMod;
                nbModLuck.Value = SelectedCharacter ().LuckPointsMod;

                updateCalculatedFields ();
                _characterStatsMutex = false;
            }
        }

        /// <summary>
        /// Updates the UI representation of all the current Character's calculated fields.
        /// </summary>
        private void updateCalculatedFields ()
        {
            maxLuckPointsTb.Text = "" + (SelectedCharacter ().MaximumLuckPoints);
            initiativeRatingTb.Text = "" + (SelectedCharacter ().InitiativeRating);
            maxActionPointsTb.Text = "" + (SelectedCharacter ().MaximumAp);
            maxStaminaTb.Text = "" + (SelectedCharacter ().Stamina);
            maxMagickaTb.Text = "" + (SelectedCharacter ().MagickaPool);
            movementRatingTb.Text = "" + (SelectedCharacter ().MovementRating);
            carryRatingTb.Text = "" + (SelectedCharacter ().CarryRating);
            woundThresholdTb.Text = "" + (SelectedCharacter ().WoundThreshold);
            maxHealthTb.Text = "" + (SelectedCharacter ().MaxHealth);
            damageBonusTb.Text = "" + (SelectedCharacter ().DamageBonus);
        }

        /// <summary>
        /// Update all UI elements with Data Bindings.
        /// </summary>
        /// <todo>Refactor this to reduce code repetition</todo>
        private void updateDataBindings ()
        {
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

            skillsDgv.DataSource = null;
            if (SelectedCharacter ().Skills.Count > 0)
            {
                skillsDgv.DataSource = SelectedCharacter ().Skills;
            }

            spellsDgv.DataSource = null;
            if (SelectedCharacter ().Spells.Count > 0)
            {
                spellsDgv.DataSource = SelectedCharacter ().Spells;
            }

            int selectedIndex = skillsCb.SelectedIndex;
            skillsCb.Items.Clear ();
            skillsCb.Items.Add ("Untrained");
            for (int i = 0; i < SelectedCharacter ().Skills.Count; i++)
            {
                Skill skill = SelectedCharacter ().Skills[i];
                skillsCb.Items.Add (skill);
            }
            if (selectedIndex < skillsCb.Items.Count)
            {
                skillsCb.SelectedIndex = selectedIndex;
            }
            else
            {
                skillsCb.SelectedIndex = 0;
            }
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
        /// <todo>Rework this to eliminate type checking wizardry</todo>
        private void updateCharacteristicCb ()
        {
            object selectedItem = skillsCb.SelectedItem;
            if ((selectedItem.GetType () == typeof (Skill)) && skillRb.Checked)
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
        /// Will disable the skillLevel textbox if a skill roll is not selected and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillRb_CheckedChanged (object sender, EventArgs e)
        {
            updateCharacteristicCb ();

            softRoll (sender, e);
        }

        /// <summary>
        /// Will disable the skillLevel textbox if a skill roll is not selected and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicRb_CheckedChanged (object sender, EventArgs e)
        {
            updateCharacteristicCb ();

            softRoll (sender, e);
        }

        /// <summary>
        /// Rolls against selected parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rollBt_Click (object sender, EventArgs e)
        {
            rollBt_Click (sender, e, 0);
        }

        /// <summary>
        /// Rolls against selected parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="extraDifficulty">An extra difficulty modifier, in case a particular check is harder or easier</param>
        /// <todo>Expose the extraDifficulty modifier somewhere</todo>
        private void rollBt_Click (object sender, EventArgs e, int extraDifficulty = 0)
        {
            Random r = new Random ();

            int result = r.Next (1, 100);
            rollResultTb.Text = "" + result;

            softRoll (sender, e, extraDifficulty);
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
            softRoll (sender, e, 0);
        }

        /// <summary>
        /// A soft roll performs all of the calculations of a regular roll, but does not change the roll result.
        /// This is useful for using outside roll values with the app, since we don't want to replace the player's
        /// entered roll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <todo>
        /// Expose the extraDifficulty modifier somewhere. This function is expected to change a lot to remove
        /// much of the Character logic (and especially the Untrained Skill wizardry).
        /// </todo>
        private void softRoll (object sender, EventArgs e, int extraDifficulty = 0)
        {
            bool isSkillRoll = skillRb.Checked;

            int result = 0;
            if (int.TryParse (rollResultTb.Text, out result))
            {
                int luck = SelectedCharacter ().Luck;
                if (result <= SelectedCharacter ().GetBonus (luck))
                {
                    successOrFailLb.Text = "Critical success!";
                    successOrFailLb.Visible = true;
                }
                else if (result >= (95 + SelectedCharacter ().GetBonus (luck)))
                {
                    successOrFailLb.Text = "Critical failure!";
                    successOrFailLb.Visible = true;
                }
                else
                {
                    successOrFailLb.Visible = false;
                }

                int difference = 0;

                int characteristicIndex = 0;
                int characteristic = 0;

                if (isSkillRoll)
                {
                    // if we haven't selected a skill, we are rolling an untrained skill
                    if (skillsCb.SelectedItem.GetType () != typeof (Skill))
                    {
                        characteristicIndex = characteristicCb.SelectedIndex;
                        characteristic = SelectedCharacter ().GetCharacteristic (characteristicIndex);

                        characteristic = ((characteristic - 20) + extraDifficulty);
                    }
                    else
                    {
                        Skill skill = (Skill)skillsCb.SelectedItem;

                        characteristicIndex = skill.Characteristics[characteristicCb.SelectedIndex];
                        characteristic = SelectedCharacter ().GetCharacteristic (characteristicIndex);

                        int skillLevel = skill.Rank;
                        characteristic = (characteristic + (skillLevel * 10) + extraDifficulty);
                    }
                }
                else
                {
                    characteristicIndex = characteristicCb.SelectedIndex;
                    characteristic = SelectedCharacter ().GetCharacteristic (characteristicIndex);
                }

                difference = (characteristic - result);

                int successes = SelectedCharacter ().GetBonus (difference);

                rollBreakdownTb.Text = String.Format ("{0} - {1} = {2}", characteristic, result, difference);
                rollSuccessesTb.Text = "" + successes;
            }
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
                foreach (Character c in _characterList)
                {
                    c.EngVersion = Program.CurrentEngVersion;
                    c.MinorVersion = Program.CurrentMinorVersion;
                    c.MajorVersion = Program.CurrentMinorVersion;
                }

                
                xml.Serialize (fs, _characterList);
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

                    // Ensure that our selected character is in the range of the new list.
                    if (loadedList.Count > 1)
                    {
                        _selectedIndex = 0;
                    }
                    _characterList = loadedList;
                    _currentFile = fileName;
                    saveMi.Enabled = true;

                    foreach (Character c in _characterList)
                    {
                        // Perform any necessary updates.
                        c.Update ();
                    }

                }
                catch (IOException)
                {

                }
                finally
                {
                    fs.Close ();
                }
                refreshUIRepresentation ();

                charactersCb.Items.Clear ();
                foreach (Character c in _characterList)
                {
                    charactersCb.Items.Add (c.Name);
                }
                charactersCb.SelectedIndex = 0;
                nameTb.Text = SelectedCharacter ().Name;
            }
        }

        private void btAddCharacter_Click (object sender, EventArgs e)
        {
            Character newChar = new Character ();
            _characterList.Add (newChar);
            charactersCb.Items.Add (newChar.Name);
        }

        private void charactersCb_SelectedIndexChanged (object sender, EventArgs e)
        {
            _selectedIndex = charactersCb.SelectedIndex;
            nameTb.Text = SelectedCharacter ().Name;
            refreshUIRepresentation ();
            updateDataBindings ();
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
                refreshUIRepresentation();
            }
        }

        private void addSkillBt_Click (object sender, EventArgs e)
        {
            int skillIndex = skillsCb.SelectedIndex;
            EditSkill es = new EditSkill (SelectedCharacter ());
            es.ShowDialog ();
            updateDataBindings ();
            skillsCb.SelectedIndex = skillIndex;
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

            breakdownString += string.Format ("{0}", selectedWeapon.DamageMod);
            resultTotal += selectedWeapon.DamageMod;

            weaponResultTb.Text = string.Format ("{0} pen {1}", resultTotal, selectedWeapon.Penetration);
            weaponResultBreakdownTb.Text = breakdownString;
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

        /// <todo>make this good</todo>
        private void castSpellBt_Click (object sender, EventArgs e)
        {
            if (spellsDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show ("Please select 1 spell to cast.");
                return;
            }

            Spell s = SelectedCharacter ().Spells[spellsDgv.CurrentCell.RowIndex];

            if (SelectedCharacter ().CurrentMagicka < s.Cost)
            {
                MessageBox.Show ("You don't have enough magicka to cast this spell!");
            }
            else
            {
                SelectedCharacter ().CurrentMagicka -= s.Cost;

                int skillIndex = -1;
                for (int i = 0; i < SelectedCharacter ().Skills.Count; i++)
                {
                    if (SelectedCharacter ().Skills[i].Name == s.AssociatedSkill)
                    {
                        skillIndex = i;
                        break;
                    }
                }

                if (skillIndex > -1)
                {
                    skillRb.Checked = true;
                    // add 1 because of the "Untrained" option
                    skillsCb.SelectedIndex = skillIndex + 1;
                    rollBt_Click (sender, e, s.Difficulty);
                    spellRollBreakdownTb.Text = rollBreakdownTb.Text;
                    if (int.Parse (rollResultTb.Text) >= 0 && s.DoesDamage)
                    {
                        Random r = new Random ();
                        int totalResult = 0;
                        for (int i = 0; i < s.NumberOfDice; i++)
                        {
                            totalResult += r.Next (1, s.DiceSides);
                        }

                        spellDamageTb.Text = string.Format ("{0} pen {1}", totalResult, s.Penetration);
                    }
                    else
                    {
                        spellDamageTb.Text = "N/A";
                    }
                }
            }

            refreshUIRepresentation ();
        }
    }
}
