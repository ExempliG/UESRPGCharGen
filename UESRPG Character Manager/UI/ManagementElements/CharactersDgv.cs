using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.ManagementElements
{
    public partial class CharactersDgv : UserControl
    {
        private const string NAME_CELL_ID = "name";
        private const string ID_CELL_ID = "id";

        public CharactersDgv()
        {
            InitializeComponent();

            characterDgv.Columns.Add(ID_CELL_ID, "ID");
            characterDgv.Columns.Add(NAME_CELL_ID, "Name");
        }

        public void UpdateCharacterList(ICollection<Character> characterCollection)
        {
            characterDgv.Rows.Clear();
            foreach (Character c in characterCollection)
            {
                characterDgv.Rows.Add(getRow(c));
            }
        }

        private DataGridViewRow getRow(Character c)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(characterDgv, c.Guid, c.Name);
            return r;
        }

        public Guid[] GetSelectedCharacters()
        {
            Guid[] characters = new Guid[characterDgv.SelectedRows.Count];

            for (int i = 0; i < characters.Length; i++)
            {
                DataGridViewRow r = characterDgv.SelectedRows[i];
                characters[i] = (Guid)r.Cells[ID_CELL_ID].Value;
            }

            return characters;
        }
    }
}
