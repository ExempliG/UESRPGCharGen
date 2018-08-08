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
using UESRPG_Character_Manager.Common;

namespace UESRPG_Character_Manager.UI.ManagementElements
{
    public partial class ManageCharactersWindow : Form
    {
        public ManageCharactersWindow()
        {
            InitializeComponent();

            exportBt.Enabled = false;
            updateCharacterList();

            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
        }

        protected void onCharacterListChanged(object sender, EventArgs e)
        {
            updateCharacterList();
        }

        private void updateCharacterList()
        {
            charactersDgv.UpdateCharacterList(CharacterController.Instance.CharacterDict.Values);
        }

        private void importBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if(result == DialogResult.OK)
            {
                SaveFile save = SaveFile.LoadFilename(ofd.FileName, out bool success, out string message);
                if(success)
                {
                    uint listId = CharacterController.Instance.StartCharacterList(save.Characters);
                    ImportCharactersWindow icw = new ImportCharactersWindow(listId);
                    icw.Show();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
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
