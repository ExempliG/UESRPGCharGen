using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.UI.MainWindow;
using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class SpellListView : UserControl
    {
        private uint _activeCharacter;
        private bool _hasCharacter;
        public uint SelectorId { get; set; }

        public SpellListView()
        {
            InitializeComponent();

            spellsDgv.CellValueChanged += onSpellListChanged;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.SpellListChanged += onSpellListChanged;
        }

        protected void onSelectedCharacterChanged(object sender, SelectedCharacterChangedEventArgs e)
        {
            if (e.SelectorId == SelectorId)
            {
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

                toggleAllControls(_hasCharacter);

                updateView();
            }
        }

        protected void onSpellListChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                spellsDgv.DataSource = null;
                if (c.Spells.Count > 0)
                {
                    spellsDgv.DataSource = c.Spells;
                }
            }
            else
            {
                spellsDgv.DataSource = null;
            }
        }

        private void toggleAllControls(bool enabled)
        {
            ///<todo>Do it</todo>
        }

        private void addSpellBt_Click(object sender, EventArgs e)
        {
            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            EditSpell es = new EditSpell(c);
            es.ShowDialog();
            updateView();
        }

        private void spellEditBt_Click(object sender, EventArgs e)
        {
            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            int spellIndex = spellsDgv.SelectedRows[0].Index;
            Spell selectedSpell = c.Spells[spellIndex];
            EditSpell es = new EditSpell(c, selectedSpell);
            es.ShowDialog();
            updateView();
        }

        private void spellsDgv_SelectionChanged(object sender, EventArgs e)
        {
            if(spellsDgv.SelectedRows.Count == 1)
            {
                spellEditBt.Enabled = true;
            }
            else
            {
                spellEditBt.Enabled = false;
            }
        }
    }
}
