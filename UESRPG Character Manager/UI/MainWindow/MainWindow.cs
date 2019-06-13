﻿using System;
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
using UESRPG_Character_Manager.GameComponents;
using UESRPG_Character_Manager.UI.CharacterViews;
using UESRPG_Character_Manager.UI.ManagementElements;

namespace UESRPG_Character_Manager.UI.MainWindow
{
    public partial class MainWindow : Form
    {
        private string _currentFile = "";
        private uint _activeCharacter;
        private bool _hasCharacter;
        public uint SelectorId { get; set; }
        private bool _changingCharacter = false;

        private const string FILE_TYPE_STRING = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

        public MainWindow ()
        {
            InitializeComponent ();

            // Subscribe Character views to the character change event
            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
            CharacterController.Instance.ForceUpdate();

            GameController.Instance.ActiveCombatsChanged += onActiveCombatsChanged;

            SelectorId = characterSelector.SelectorId;
            charaView_statsPage.SelectorId = SelectorId;
            attributesView_statsPage.SelectorId = SelectorId;
            skillListView_statsPage.SelectorId = SelectorId;
            attributesView_statsPage.SelectorId = SelectorId;
            weaponsView_equipPage.SelectorId = SelectorId;
            armorView_equipPage.SelectorId = SelectorId;
            checkRollView_statsPage.SelectorId = SelectorId;

            skillListView_statsPage.OnSelectedSkill += checkRollView_statsPage.OnSelectedSkillChanged;
            spellListView_statsPage.OnSelectedSpell += checkRollView_statsPage.OnSelectedSpellChanged;

            /*CUSTOM EVENT BINDINGS*/
            this.LostFocus += characterNotesRtb_LostFocus;
            /*END CUSTOM EVENT BINDINGS*/

            saveMi.Enabled = false;
        }

        private void onSelectedCharacterChanged(object sender, SelectedCharacterChangedEventArgs e)
        {
            if (e.SelectorId == SelectorId)
            {
                // If the character is being changed, store the old character's Notes
                if (_hasCharacter && e.EventType != CharacterSelectionEvent.SAME_CHARACTER)
                {
                    Character oldCharacter = CharacterController.Instance.GetCharacterById(_activeCharacter);
                    ///<todo>Update this to go through the Controller</todo>
                    oldCharacter.Notes = characterNotesRtb.Text;
                }

                switch (e.EventType)
                {
                    case CharacterSelectionEvent.NEW_CHARACTER:
                        _activeCharacter = e.CharacterId;
                        _hasCharacter = true;
                        break;
                    case CharacterSelectionEvent.NO_CHARACTER:
                        _hasCharacter = false;
                        break;
                    case CharacterSelectionEvent.SAME_CHARACTER:
                        break;

                }

                _changingCharacter = true;
                if (_hasCharacter)
                {
                    Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                    ///<todo>Update this to go through the Controller</todo>
                    nameTb.Text = c.Name;
                    characterNotesRtb.Text = c.Notes;
                }
                else
                {
                    nameTb.Text = string.Empty;
                    characterNotesRtb.Text = string.Empty;
                }
                _changingCharacter = false;
            }
        }

        protected void onCharacterListChanged(object sender, CharacterListChangedEventArgs e)
        {
            if(e.IsMainList)
            {
                int count = CharacterController.Instance.CharacterDict.Values.Count;
                bool hasCharacters = count != 0;
                updateButtonStatus(hasCharacters);
            }
        }

        private void onActiveCombatsChanged(object sender, ActiveCombatsChangedEventArgs e)
        {
            switch(e.EventType)
            {
                case ActiveCombatsChangedEvent.ENDED_COMBAT:
                    // do nothing
                    break;
                case ActiveCombatsChangedEvent.END_ALL_COMBATS:
                    // do nothing
                    break;
                case ActiveCombatsChangedEvent.NEW_COMBAT:
                    // do nothing
                    break;
                case ActiveCombatsChangedEvent.NEW_DICT:
                    createCombatWindows();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("e.EventType", "todo: You stink");
            }
        }

        private void updateButtonStatus(bool enabled)
        {
            newCombatMenuItem.Enabled = enabled;
            manageCharactersToolStripMenuItem.Enabled = enabled;
        }

        private void createCombatWindows()
        {
            Dictionary<uint, Combat> combatDict = GameController.Instance.CombatDict;

            int counter = 1;
            foreach (Combat c in combatDict.Values)
            {
                CombatViews.CombatWindow cw = new CombatViews.CombatWindow(c.CombatId);
                Point cwLoc = this.Location;
                cwLoc.X += (35 * counter);
                cwLoc.Y += (35 * counter);
                counter++;
                cw.Show();
                cw.Location = cwLoc;
            }
        }

        private void characterNotesRtb_LostFocus(object sender, EventArgs e)
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                c.Notes = characterNotesRtb.Text;
            }
        }

        private void nameTb_TextChanged (object sender, EventArgs e)
        {
            if (!_changingCharacter && _hasCharacter)
            {
                CharacterController.Instance.ChangeCharacterName(_activeCharacter, nameTb.Text);
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
            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            c.Notes = characterNotesRtb.Text;

            if (!string.IsNullOrEmpty(_currentFile))
            {
                string message;
                bool result = IOController.Instance.SaveChar(_currentFile, out message);

                if(!result)
                {
                    MessageBox.Show(message);
                }
            }
        }

        private void saveAsMi_Click (object sender, EventArgs e)
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                c.Notes = characterNotesRtb.Text;
            }

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
                bool result = IOController.Instance.SaveChar(sfd.FileName, out message);

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
                bool result = IOController.Instance.LoadChar(ofd.FileName, out message);

                if (result)
                {
                    _currentFile = ofd.FileName;
                    saveMi.Enabled = true;
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
        }

        private void manageCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCharactersWindow mcw = new ManageCharactersWindow();
            mcw.Show();
        }

        private void newCombatMenuItem_Click(object sender, EventArgs e)
        {
            uint combatId = GameController.Instance.CreateNewCombat();
            CombatViews.CombatWindow cw = new CombatViews.CombatWindow(combatId);
            Point cwLoc = this.Location;
            cwLoc.X += (this.Width + 1);
            cw.Show();
            cw.Location = cwLoc;
        }

        private void showConsoleToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Form f = new Form();
            GraphicalConsole c = new GraphicalConsole();
            f.Controls.Add( c );
            f.ClientSize = c.Size;
            c.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            f.Show();
            f.Text = "Console";
        }
    }
}
