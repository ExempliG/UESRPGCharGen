using System;
using System.ComponentModel;
using System.Windows.Forms;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class SpellListView : SelectedCharacterControl
    {
        public SpellListView()
        {
            InitializeComponent();
            aspectsToWatch.Add( CharacterAspect.SPELL );
        }

        public delegate void SelectedSpell(object sender, int spellIndex);
        [Description("Fires when the selected spell changes")]
        public event SelectedSpell OnSelectedSpell;

        protected void onSelectedSpell(int spellIndex)
        {
            OnSelectedSpell?.Invoke(this, spellIndex);
        }

        protected override void updateView()
        {
            if (_selector.HasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
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

        protected override void toggleAllControls(bool enabled)
        {
            if(!enabled)
            {
                spellsDgv.DataSource = null;
            }
            addSpellBt.Enabled = enabled;
            spellEditBt.Enabled = enabled;
        }

        private void addSpellBt_Click(object sender, EventArgs e)
        {
            Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
            EditSpell es = new EditSpell(c);
            es.ShowDialog();
            if( es.GetSpell( out Spell spell ) )
            {
                CharacterController.Instance.AddSpell( _selector.GetCharacterGuid(), spell );
            }
            updateView();
        }

        private void spellEditBt_Click(object sender, EventArgs e)
        {
            Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
            int spellIndex = spellsDgv.SelectedRows[0].Index;
            Spell selectedSpell = c.Spells[spellIndex];
            EditSpell es = new EditSpell(c, selectedSpell);
            es.ShowDialog();
            if ( es.GetSpell( out Spell spell ) )
            {
                CharacterController.Instance.EditSpell( _selector.GetCharacterGuid(), spell );
            }
            updateView();
        }

        private void spellsDgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = spellsDgv.SelectedRows;
            if (spellsDgv.SelectedRows.Count == 1)
            {
                spellEditBt.Enabled = true;
                int selectedIndex = theRows[0].Index;
                onSelectedSpell(selectedIndex);
            }
            else
            {
                spellEditBt.Enabled = false;
            }
        }
    }
}
