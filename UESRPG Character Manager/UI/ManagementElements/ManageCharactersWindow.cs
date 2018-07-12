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
        public ManageCharactersWindow()
        {
            InitializeComponent();

            exportBt.Enabled = false;
            updateCharacterList();
        }

        private void updateCharacterList()
        {
            charactersDgv.UpdateCharacterList(CharacterController.Instance.CharacterDict.Values);
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
            foreach(uint id in charactersDgv.GetSelectedCharacters())
            {
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
