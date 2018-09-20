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
    public partial class ImportExportCharactersWindow : Form
    {
        public uint CharacterListId { get; set; }
        public string FileName { get; set; }

        public ImportExportCharactersWindow()
        {
            InitializeComponent();
            Shown += onShown;
            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
        }

        public ImportExportCharactersWindow(uint CharacterListId, string FileName) : this()
        {
            this.CharacterListId = CharacterListId;
            this.FileName = FileName;
        }

        protected void onCharacterListChanged(object sender, CharacterListChangedEventArgs e)
        {
            if (!e.IsMainList && e.ListId == CharacterListId)
            {
                updateView();
            }
        }

        protected void onShown(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            charactersDgv.UpdateCharacterList(CharacterController.Instance.GetCharacterDict(CharacterListId).Values);
        }

        private void importBt_Click(object sender, EventArgs e)
        {
            uint[] selectedCharIds = charactersDgv.GetSelectedCharacters();

            if(selectedCharIds.Length > 0)
            {
                foreach(uint id in selectedCharIds)
                {
                    CharacterController.Instance.AddCharacter(CharacterListId, id);
                }
            }
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            DialogResult saveResult = MessageBox.Show("Save changes to Import/Export file?", "Save Changes", MessageBoxButtons.YesNoCancel);

            if(saveResult == DialogResult.Yes)
            {
                SaveFile saveFile = new SaveFile(CharacterController.Instance.GetCharacterDict(CharacterListId));
                saveFile.SaveToFilename(FileName, out string message);
            }
            else if(saveResult == DialogResult.No)
            {
                // do nothing
            }
            else if(saveResult == DialogResult.Cancel)
            {
                return;
            }

            base.OnClosed(e);

            CharacterController.Instance.EndCharacterList(CharacterListId);
        }
    }
}
