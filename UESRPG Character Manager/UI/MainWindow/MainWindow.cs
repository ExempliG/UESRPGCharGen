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

using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.MainWindow
{
    public partial class MainWindow : Form
    {
        private string _currentFile = "";
        private Character _activeCharacter;
        private bool _changingCharacter = false;

        private const string FILE_TYPE_STRING = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        public MainWindow ()
        {
            InitializeComponent ();

            // Subscribe Character views to the character change event
            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            CharacterController.Instance.ForceUpdate();

            spellDamageView_rollsPage.SelectedSpellChanged += checkRollView_rollsPage.OnSelectedSpellChanged;

            /*CUSTOM EVENT BINDINGS*/
            this.LostFocus += characterNotesRtb_LostFocus;
            /*END CUSTOM EVENT BINDINGS*/

            saveMi.Enabled = false;
        }

        private void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _changingCharacter = true;
            if (_activeCharacter != null)
            {
                _activeCharacter.Notes = characterNotesRtb.Text;
            }
            _activeCharacter = CharacterController.Instance.ActiveCharacter;
            nameTb.Text = _activeCharacter.Name;
            characterNotesRtb.Text = _activeCharacter.Notes;
            _changingCharacter = false;
        }

        private void characterNotesRtb_LostFocus(object sender, EventArgs e)
        {
            _activeCharacter.Notes = characterNotesRtb.Text;
        }

        private void nameTb_TextChanged (object sender, EventArgs e)
        {
            if (!_changingCharacter)
            {
                CharacterController.Instance.ChangeCharacterName(nameTb.Text);
            }
        }

        /// <summary>
        /// This function is bound to our NumericUpDowns' GotFocus event. It will cause the numeric values to be highlighted when tabbed into.
        /// </summary>
        private void numberBoxFocus (object sender, EventArgs e)
        {
            NumericUpDown theNb = (NumericUpDown)sender;
            theNb.Select (0, 3);
        }

        private void saveMi_Click (object sender, EventArgs e)
        {
            _activeCharacter.Notes = characterNotesRtb.Text;

            if (!string.IsNullOrEmpty(_currentFile))
            {
                string message;
                bool result = CharacterController.Instance.SaveChar(_currentFile, out message);

                if(!result)
                {
                    MessageBox.Show(message);
                }
            }
        }

        private void saveAsMi_Click (object sender, EventArgs e)
        {
            _activeCharacter.Notes = characterNotesRtb.Text;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ".xml",
                Filter = FILE_TYPE_STRING
            };
            DialogResult sfdResult = sfd.ShowDialog ();

            if (sfdResult == DialogResult.OK)
            {
                string message;
                bool result = CharacterController.Instance.SaveChar(sfd.FileName, out message);

                if (result)
                {
                    _currentFile = sfd.FileName;
                    saveMi.Enabled = true;
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }

        private void loadMi_Click (object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                DefaultExt = ".xml",
                Filter = FILE_TYPE_STRING
            };
            DialogResult ofdResult = ofd.ShowDialog();

            if (ofdResult == DialogResult.OK)
            {
                string message;
                bool result = CharacterController.Instance.LoadChar(ofd.FileName, out message);

                if (result)
                {
                    _currentFile = ofd.FileName;
                    saveMi.Enabled = true;
                    nameTb.Text = _activeCharacter.Name;
                    characterNotesRtb.Text = _activeCharacter.Notes;
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint combatId = GameController.Instance.CreateNewCombat();
            GameController.Instance.AddCombatant(combatId, _activeCharacter);
            CombatViews.CombatWindow cw = new CombatViews.CombatWindow(combatId);
            Point cwLoc = this.Location;
            cwLoc.X += ( this.Width + 5 );
            cw.Show();
            cw.Location = cwLoc;
            GameController.Instance.AddCombatant(combatId, new UESRPG_Character_Manager.GameComponents.RemoteCombatant());
        }
    }
}
