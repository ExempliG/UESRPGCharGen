using System;
using System.Linq;
using System.Windows.Forms;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.UI.CombatViews
{
    public partial class CombatantsListView : UserControl
    {
        private const string ACTIVE_COMBATANT_MARKER = "*";
        private const string NAME_CELL_ID = "name";
        private const string AP_CELL_ID = "ap";
        private const string INIT_CELL_ID = "initiative";
        private const uint COLUMN_COUNT = 3;
        public uint _combatId;
        public uint SelectorId { get; set; }

        public CombatantsListView()
        {
            InitializeComponent();
            combatantsDgv.Columns.Add(NAME_CELL_ID, "Name");
            combatantsDgv.Columns[NAME_CELL_ID].ReadOnly = true;
            combatantsDgv.Columns.Add(AP_CELL_ID, "AP");
            combatantsDgv.Columns[AP_CELL_ID].ReadOnly = true;
            combatantsDgv.Columns.Add(INIT_CELL_ID, "Initiative");
            combatantsDgv.Columns[INIT_CELL_ID].ReadOnly = false;

            //_combatId = 0;// combatId;

            Combat.CombatUpdated += onCombatUpdated;
            Combat.CombatantListUpdated += onCombatantListUpdated;
            SelectorId = CharacterController.Instance.StartSelector();
            combatantsDgv.CellEndEdit += onCellEndEdit;
            //CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
        }

        protected void onCombatUpdated(object sender, EventArgs e)
        {
            Combat c = (Combat)sender;
            if (c.CombatId == _combatId)
            {
                UpdateList(c);
            }
        }

        protected void onCharacterListChanged(object sender, CharacterListChangedEventArgs e)
        {
            if(e.IsMainList)
            {
                Combat c = GameController.Instance.GetCombatById(_combatId);
                var combatantIds = from cmbs in c.Combatants
                                   where cmbs.GetType() == typeof(Character)
                                   select ((Character)cmbs).Id;
                //if()
            }
        }

        public void UpdateList()
        {
            if (GameController.Instance.CombatIsActive(_combatId))
            {
                Combat c = GameController.Instance.GetCombatById(_combatId);
                UpdateList(c);
            }
        }

        public void UpdateList(Combat c)
        {
            if (c.CombatId == _combatId && c.Combatants.Count > 0 && combatantsDgv.Rows.Count > 0)
            {
                ICombatant previous = c.Combatants[c.PreviousCombatantIndex];
                combatantsDgv.Rows[c.PreviousCombatantIndex].Cells[NAME_CELL_ID].Value = previous.Name;
                combatantsDgv.Rows[c.PreviousCombatantIndex].Cells[AP_CELL_ID].Value = previous.ApString;

                ICombatant current = c.Combatants[c.CurrentCombatantIndex];
                combatantsDgv.Rows[c.CurrentCombatantIndex].Cells[NAME_CELL_ID].Value = ACTIVE_COMBATANT_MARKER + current.Name;
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

        protected void onCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int charIndex = e.RowIndex;
            string cellString = (string)combatantsDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if(uint.TryParse(cellString, out uint cellInt))
            {
                GameController.Instance.EditCombatantInitiative(_combatId, charIndex, cellInt);
            }
            else
            {
                // todo: Error? Edit rejection?
            }
        }

        public void UpdateView()
        {
            if (GameController.Instance.CombatIsActive(_combatId))
            {
                Combat c = GameController.Instance.GetCombatById(_combatId);
                updateView(c);
            }
        }

        private void updateView( Combat c )
        {
            // Only try to populate the DataGridView if the columns have been initialized
            if (combatantsDgv.Columns.Count == COLUMN_COUNT)
            {
                combatantsDgv.Rows.Clear();
                for (int i = 0; i < c.Combatants.Count; i++)
                {
                    ICombatant ic = c.Combatants[i];
                    DataGridViewRow r = getRow(ic, i == c.CurrentCombatantIndex);
                    combatantsDgv.Rows.Add(r);
                }
            }
        }

        private DataGridViewRow getRow(ICombatant c, bool isActiveCombatant=false)
        {
            DataGridViewRow r = new DataGridViewRow();
            string name = c.Name;
            if(isActiveCombatant)
            {
                name = ACTIVE_COMBATANT_MARKER + name;
            }
            r.CreateCells(combatantsDgv, name, c.ApString, c.Initiative);
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
                    CharacterController.Instance.SelectCharacterById(chara.Id, SelectorId);
                }
                else
                {
                    CharacterController.Instance.DeselectCharacter(SelectorId);
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
