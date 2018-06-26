using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.GameComponents;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.CombatViews
{
    public partial class CombatantsListView : UserControl
    {
        private const string ACTIVE_COMBATANT_MARKER = "*";
        private const string NAME_CELL_ID = "name";
        private const string AP_CELL_ID = "ap";
        public uint _combatId;
        public uint SelectorId { get; set; }

        public CombatantsListView()
        {
            InitializeComponent();
            combatantsDgv.Columns.Add(NAME_CELL_ID, "Name");
            combatantsDgv.Columns.Add(AP_CELL_ID, "AP");

            //_combatId = 0;// combatId;

            Combat.CombatUpdated += onCombatUpdated;
            Combat.CombatantListUpdated += onCombatantListUpdated;
            SelectorId = CharacterController.Instance.StartSelector();
        }

        protected void onCombatUpdated(object sender, EventArgs e)
        {
            Combat c = (Combat)sender;
            if (c.CombatId == _combatId)
            {
                ICombatant previous = c.Combatants[c.PreviousCombatantIndex];
                combatantsDgv.Rows[c.PreviousCombatantIndex].Cells[NAME_CELL_ID].Value = previous.GetName();
                combatantsDgv.Rows[c.PreviousCombatantIndex].Cells[AP_CELL_ID].Value = previous.GetAp();

                ICombatant current = c.Combatants[c.CurrentCombatantIndex];
                combatantsDgv.Rows[c.CurrentCombatantIndex].Cells[NAME_CELL_ID].Value = ACTIVE_COMBATANT_MARKER + current.GetName();
            }
        }

        protected void onCombatantListUpdated(object sender, EventArgs e)
        {
            Combat c = (Combat)sender;
            if (c.CombatId == _combatId)
            {
                updateView(c);
            }
        }

        private void updateView( Combat c )
        {
            combatantsDgv.Rows.Clear();
            for( int i = 0; i < c.Combatants.Count; i++ )
            {
                ICombatant ic = c.Combatants[i];
                DataGridViewRow r = getRow(ic, i == c.CurrentCombatantIndex);
                combatantsDgv.Rows.Add(r);
            }
        }

        private DataGridViewRow getRow(ICombatant c, bool isActiveCombatant=false)
        {
            DataGridViewRow r = new DataGridViewRow();
            string name = c.GetName();
            if(isActiveCombatant)
            {
                name = ACTIVE_COMBATANT_MARKER + name;
            }
            r.CreateCells(combatantsDgv, name, c.GetAp());
            return r;
        }

        private void addCombatantBt_Click(object sender, EventArgs e)
        {
            NewCombatantWindow ncw = new NewCombatantWindow(_combatId);
            DialogResult result = ncw.ShowDialog();
        }

        private void removeCombatantBt_Click(object sender, EventArgs e)
        {
            if( combatantsDgv.SelectedRows.Count == 1 )
            {
                int selectedIndex = combatantsDgv.SelectedRows[0].Index;
                GameController.Instance.RemoveCombatant(_combatId, selectedIndex);
            }
        }

        private void combatantUpBt_Click(object sender, EventArgs e)
        {
            if( combatantsDgv.SelectedRows.Count == 1 )
            {
                int selectedIndex = combatantsDgv.SelectedRows[0].Index;
                if (selectedIndex > 0)
                {
                    GameController.Instance.RaiseCombatant(_combatId, selectedIndex);
                    combatantsDgv.ClearSelection();
                    combatantsDgv.Rows[selectedIndex - 1].Selected = true;
                }
            }
        }

        private void combatantDownBt_Click(object sender, EventArgs e)
        {
            if (combatantsDgv.SelectedRows.Count == 1)
            {
                int selectedIndex = combatantsDgv.SelectedRows[0].Index;
                if (selectedIndex < (combatantsDgv.RowCount - 1) )
                {
                    GameController.Instance.LowerCombatant(_combatId, selectedIndex);
                    combatantsDgv.ClearSelection();
                    combatantsDgv.Rows[selectedIndex + 1].Selected = true;
                }
            }
        }

        private void combatantsDgv_SelectionChanged(object sender, EventArgs e)
        {
            bool enable = (combatantsDgv.SelectedRows.Count == 1);
            if (enable)
            {
                int selectedIndex = combatantsDgv.SelectedRows[0].Index;
                removeCombatantBt.Enabled = true;
                combatantUpBt.Enabled = enable && selectedIndex > 0;
                combatantDownBt.Enabled = enable && selectedIndex < (combatantsDgv.RowCount - 1);

                Combat c = GameController.Instance.GetCombatById(_combatId);
                ICombatant ic = c.Combatants[selectedIndex];
                if(ic.GetType() == typeof(Character))
                {
                    Character chara = (Character)ic;
                    CharacterController.Instance.SelectCharacter(chara.CharacterId, SelectorId);
                }
            }
            else
            {
                removeCombatantBt.Enabled = false;
                combatantUpBt.Enabled = false;
                combatantDownBt.Enabled = false;
            }
        }
    }
}
