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
        private uint _otherCharListId;

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
            DialogResult mbResult = MessageBox.Show("Exporting to new file?", "Import/Export Type", MessageBoxButtons.YesNoCancel);

            if (mbResult == DialogResult.No)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    SaveFile save = SaveFile.LoadFilename(ofd.FileName, out bool success, out string message);
                    if (success)
                    {
                        _otherCharListId = CharacterController.Instance.StartCharacterList(save.Characters);
                        ImportExportCharactersWindow icw = new ImportExportCharactersWindow(_otherCharListId, ofd.FileName);
                        icw.Show();
                        icw.FormClosed += onImportWindowClosed;
                        importBt.Enabled = false;
                        exportBt.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                }
            }
            else if (mbResult == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                DialogResult result = sfd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    SaveFile save = new SaveFile(new List<Character>());
                    save.SaveToFilename(sfd.FileName, out string message);

                    _otherCharListId = CharacterController.Instance.StartCharacterList();
                    ImportExportCharactersWindow icw = new ImportExportCharactersWindow(_otherCharListId, sfd.FileName);
                    icw.Show();
                    icw.FormClosed += onImportWindowClosed;
                    importBt.Enabled = false;
                    exportBt.Enabled = true;
                }
            }
            else
            {
                // do nothing
            }
        }

        protected void onImportWindowClosed(object sender, EventArgs e)
        {
            importBt.Enabled = true;
        }

        private void exportBt_Click(object sender, EventArgs e)
        {
            uint[] selectedCharIds = charactersDgv.GetSelectedCharacters();

            if (selectedCharIds.Length > 0)
            {
                foreach (uint id in selectedCharIds)
                {
                    CharacterController.Instance.ExportCharacter(id, _otherCharListId);
                }
            }
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
