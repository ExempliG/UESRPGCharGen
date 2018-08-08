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
    public partial class ImportCharactersWindow : Form
    {
        public uint CharacterListId { get; set; }

        public ImportCharactersWindow()
        {
            InitializeComponent();
            Shown += onShown;
        }

        public ImportCharactersWindow(uint CharacterListId) : this()
        {
            this.CharacterListId = CharacterListId;
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
            base.OnClosed(e);

            CharacterController.Instance.EndCharacterList(CharacterListId);
        }
    }
}
