using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.ManagementElements
{
    public partial class ManageCharactersWindow : Form
    {
        private const string NAME_CELL_ID = "name";
        private const string ID_CELL_ID = "id";

        public ManageCharactersWindow()
        {
            InitializeComponent();

            exportBt.Enabled = false;

            charactersDgv.Columns.Add(ID_CELL_ID, "ID");
            charactersDgv.Columns.Add(NAME_CELL_ID, "Name");
            updateCharacterList();
        }

        private void updateCharacterList()
        {
            charactersDgv.Rows.Clear();
            foreach (Character c in CharacterController.Instance.CharacterDict.Values)
            {
                charactersDgv.Rows.Add(getRow(c));
            }
        }

        private DataGridViewRow getRow(Character c)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(charactersDgv, c.Id, c.Name);
            return r;
        }

        private void importBt_Click(object sender, EventArgs e)
        {

        }

        private void exportBt_Click(object sender, EventArgs e)
        {
            // todo: implement
        }

        private void deleteBt_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in charactersDgv.SelectedRows)
            {
                uint id = (uint)r.Cells[ID_CELL_ID].Value;
                CharacterController.Instance.RemoveCharacter(id);
            }

            updateCharacterList();
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
