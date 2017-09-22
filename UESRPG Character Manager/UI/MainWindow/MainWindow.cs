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
            characterSelector.SelectedCharacterChanged += weaponDamageView_rollsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += spellDamageView_rollsPage.OnSelectedCharacterChanged;
            characterSelector.SelectedCharacterChanged += receivedDamageView_rollsPage.OnSelectedCharacterChanged;

            characterSelector.ForceUpdate();

            charaView_statsPage.CharacteristicChanged += attributesView_statsPage.OnCharacteristicChanged;

            spellDamageView_rollsPage.SelectedSpellChanged += checkRollView_rollsPage.OnSelectedSpellChanged;

            spellListView_statsPage.SpellListChanged += spellDamageView_rollsPage.OnSpellListChanged;

            skillListView_statsPage.SkillListChanged += checkRollView_rollsPage.OnSkillListChanged;

            /*CUSTOM EVENT BINDINGS*/
            this.characterNotesRtb.LostFocus += characterNotesRtb_LostFocus;
            /*END CUSTOM EVENT BINDINGS*/

            saveMi.Enabled = false;
        }

        private void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();
        }

        private void characterNotesRtb_LostFocus(object sender, EventArgs e)
        {
            _activeCharacter.Notes = characterNotesRtb.Text;
        }

        private void nameTb_TextChanged (object sender, EventArgs e)
        {
            _activeCharacter.Name = nameTb.Text;
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

                nameTb.Text = _activeCharacter.Name;
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

        private void notesCommitChangesBt_Click(object sender, EventArgs e)
        {
            _activeCharacter.Notes = characterNotesRtb.Text;
        }
    }
}
