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
        private Character _activeCharacter;

        public SpellListView()
        {
            InitializeComponent();

            spellsDgv.CellValueChanged += onSpellListChanged;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.SpellListChanged += onSpellListChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;
            updateView();
        }

        protected void onSpellListChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            spellsDgv.DataSource = null;
            if (_activeCharacter.Spells.Count > 0)
            {
                spellsDgv.DataSource = _activeCharacter.Spells;
            }
        }

        private void addSpellBt_Click(object sender, EventArgs e)
        {
            EditSpell es = new EditSpell(_activeCharacter);
            es.ShowDialog();
            updateView();
        }

        private void spellEditBt_Click(object sender, EventArgs e)
        {
            int spellIndex = spellsDgv.SelectedRows[0].Index;
            Spell selectedSpell = _activeCharacter.Spells[spellIndex];
            EditSpell es = new EditSpell(_activeCharacter, selectedSpell);
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
