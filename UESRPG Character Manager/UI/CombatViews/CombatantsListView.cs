using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.GameComponents;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.CombatViews
{
    public partial class CombatantsListView : UserControl
    {
        public uint _combatId;

        public CombatantsListView()
        {
            InitializeComponent();
            combatantsDgv.Columns.Add("name", "Name");
            combatantsDgv.Columns.Add("ap", "AP");

            //_combatId = 0;// combatId;

            Combat.CombatUpdated += onCombatUpdated;
        }

        protected void onCombatUpdated(object sender, EventArgs e)
        {
            Combat c = (Combat)sender;
            if(c.CombatId == _combatId)
            {
                updateView( c );
            }
        }

        private void updateView( Combat c )
        {
            combatantsDgv.Rows.Clear();
            foreach( ICombatant ic in c.Combatants )
            {
                DataGridViewRow r = getRow(ic);
                combatantsDgv.Rows.Add(r);
            }
        }

        private DataGridViewRow getRow(ICombatant c)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(combatantsDgv, c.GetName(), c.GetAp());
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
