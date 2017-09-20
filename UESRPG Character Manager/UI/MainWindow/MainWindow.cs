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

        private const string FILE_TYPE_STRING = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        private bool _updatingDataBindings = false;

        public MainWindow ()
        {
            InitializeComponent ();

            // Subscribe Character views to the character change event
            characterSelector.SelectedCharacterChanged += onSelectedCharacterChanged;

            characterSelector.SelectedCharacterChanged += charaView_statsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += attributesView_statsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += skillListView_statsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += spellListView_statsPage.OnSelectedCharacterChanged;

            characterSelector.SelectedCharacterChanged += weaponsView_equipPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += armorView_equipPage.OnSelectedCharacterChanged;

            characterSelector.SelectedCharacterChanged += checkRollView_rollsPage.OnSelectedCharacterChanged;

            characterSelector.ForceUpdate();
            charaView_statsPage.CharacteristicChanged += attributesView_statsPage.OnCharacteristicChanged;

            /*CUSTOM EVENT BINDINGS*/
            //this.rollResultTb.TextChanged += softRoll;
            this.characterNotesRtb.LostFocus += characterNotesRtb_LostFocus;
            /*END CUSTOM EVENT BINDINGS*/

            saveMi.Enabled = false;

            hitLocationCb.DataSource = ArmorLocationsData.s_names;

            /*foreach (string characteristic in Characteristics.s_characteristicNames)
            {
                characteristicCb.Items.Add (characteristic);
            }

            characteristicCb.SelectedIndex = 0;*/

            updateDataBindings();
        }

        private void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();
        }

        private void characterNotesRtb_LostFocus(object sender, EventArgs e)
        {
            selectedCharacter().Notes = characterNotesRtb.Text;
        }

        private Character selectedCharacter ()
        {
            //return characterSelector.GetActiveCharacter();
            return _activeCharacter;
        }

        private void nameTb_TextChanged (object sender, EventArgs e)
        {
            selectedCharacter ().Name = nameTb.Text;
        }

        /// <summary>
        /// Update all UI elements with Data Bindings.
        /// </summary>
        /// <todo>Refactor this to reduce code repetition</todo>
        private void updateDataBindings ()
        {
            _updatingDataBindings = true;

            weaponCb.DataSource = null;
            if (selectedCharacter ().Weapons.Count > 0)
            {
                weaponCb.DataSource = selectedCharacter ().Weapons;
            }

            spellsCb.DataSource = null;
            if (selectedCharacter().Spells.Count > 0)
            {
                spellsCb.DataSource = selectedCharacter().Spells;
            }

            _updatingDataBindings = false;
        }

        private void skillsCb_SelectedIndexChanged (object sender, EventArgs e)
        {
            /*if (skillRb.Checked)
            {
                updateCharacteristicCb ();
            }*/
        }

        /// <summary>
        /// This function will determine which Characteristics govern the selected skill and remove all other Characteristics from the Characteristic CB.
        /// </summary>
        private void updateCharacteristicCb ()
        {
            /*object selectedItem = skillsCb.SelectedItem;
            if (selectedItem != null && skillRb.Checked)
            {
                Skill skill = (Skill)selectedItem;
                characteristicCb.Items.Clear ();
                foreach (int characteristic in skill.Characteristics)
                {
                    characteristicCb.Items.Add (Characteristics.s_characteristicNames[characteristic]);
                }
                if (characteristicCb.Items.Count > 0)
                {
                    characteristicCb.SelectedIndex = 0;
                }
            }
            else
            {
                reloadCharacteristicCb ();
            }*/
        }

        /// <summary>
        /// Restores the Characteristics CB to include all Characteristics.
        /// </summary>
        private void reloadCharacteristicCb ()
        {
            /*characteristicCb.Items.Clear ();
            foreach (string characteristic in Characteristics.s_characteristicNames)
            {
                characteristicCb.Items.Add (characteristic);
            }
            characteristicCb.SelectedIndex = 0;*/
        }

        /// <summary>
        /// Will filter the Characteristic combobox for the selected skill and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillRb_CheckedChanged (object sender, EventArgs e)
        {
            /*updateCharacteristicCb ();
            extraDifficultyNud.Value = 0;

            softRoll (sender, e);*/
        }

        /// <summary>
        /// Will filter the Characteristic combobox for the selected skill and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicRb_CheckedChanged (object sender, EventArgs e)
        {
            /*updateCharacteristicCb ();
            extraDifficultyNud.Value = 0;

            softRoll (sender, e);*/
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
            /*Random r = new Random ();

            int result = r.Next (1, 100);
            rollResultTb.Text = "" + result;

            softRoll (sender, e);*/
        }

        /// <summary>
        /// This function is bound to our NumericUpDowns' GotFocus event. It will cause the numeric values to be highlighted when tabbed into.
        /// </summary>
        private void numberBoxFocus (object sender, EventArgs e)
        {
            NumericUpDown theNb = (NumericUpDown)sender;
            theNb.Select (0, 3);
        }

        /// <summary>
        /// Performs the saving of a Character list.
        /// </summary>
        /// <param name="fileName">The filename to save the list as.</param>
        private void saveChar (string fileName)
        {
            XmlSerializer xml = new XmlSerializer (typeof (List<Character>));
            FileStream fs = new FileStream (fileName, FileMode.Create);
            try
            {
                List<Character> listToSave = characterSelector.GetCharacterList();
                foreach (Character c in listToSave)
                {
                    c.EngVersion = Program.CURRENT_ENG_VERSION;
                    c.MinorVersion = Program.CURRENT_MINOR_VERSION;
                    c.MajorVersion = Program.CURRENT_MINOR_VERSION;
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
        private void loadChar ()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                DefaultExt = ".xml",
                Filter = FILE_TYPE_STRING
            };
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

                nameTb.Text = selectedCharacter ().Name;

                updateDataBindings();
            }
        }

        private void saveMi_Click (object sender, EventArgs e)
        {
            saveChar (_currentFile);
        }

        private void saveAsMi_Click (object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".xml",
                Filter = FILE_TYPE_STRING
            };
            DialogResult result = sfd.ShowDialog ();

            string fileName = sfd.FileName;
            if (!string.IsNullOrEmpty (fileName) && result == DialogResult.OK)
            {
                saveChar (fileName);
            }
        }

        private void loadMi_Click (object sender, EventArgs e)
        {
            loadChar ();
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
            ArmorLocations location = (ArmorLocations)hitLocationCb.SelectedIndex;

            if (int.TryParse (receivedDamageTb.Text, out int damage) && int.TryParse (receivedPenTb.Text, out int pen))
            {
                double armorMitigation = selectedCharacter ().GetArmorPiece (location).AR;
                armorMitigation = Math.Max(armorMitigation - pen, 0);                       // Pen reduces armorMitigation to a lower limit of zero.
                damage = Math.Max(damage - (int)armorMitigation, 0);                        // armorMitigation then reduces received damage to a lower limit of zero.

                finalDamageReceivedTb.Text = damage.ToString ();
            }
        }

        private void applyDamageBt_Click (object sender, EventArgs e)
        {
            if (int.TryParse (finalDamageReceivedTb.Text, out int damage))
            {
                selectedCharacter ().CurrentHealth -= damage;
            }
        }

        private void armorDataGridView_ChangeOccurred (object sender, EventArgs e)
        {
            updateDamage ();
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

            breakdownString += string.Format ("{0} + bonus {1}", selectedWeapon.DamageMod, selectedCharacter().DamageBonus);
            resultTotal += selectedWeapon.DamageMod;
            resultTotal += selectedCharacter().DamageBonus;

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
            EditSpell es = new EditSpell (selectedCharacter ());
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
                        //skillRb.Checked = true;
                        IEnumerable<Skill> skillSearch = from skill in selectedCharacter().Skills
                                                         where skill.Name == selectedSpell.AssociatedSkill
                                                         select skill;
                        if (skillSearch.Count() == 1)
                        {
                            //int skillIndex = skillsCb.Items.IndexOf(skillSearch.ElementAt(0));
                            //skillsCb.SelectedIndex = skillIndex;
                            //extraDifficultyNud.Value = selectedSpell.Difficulty;
                        }
                    }

                    allowRoll = selectedSpell.DoesDamage;
                }
            }

            spellRollBt.Enabled = allowRoll;
        }

        private void notesCommitChangesBt_Click(object sender, EventArgs e)
        {
            selectedCharacter().Notes = characterNotesRtb.Text;
        }
    }
}
