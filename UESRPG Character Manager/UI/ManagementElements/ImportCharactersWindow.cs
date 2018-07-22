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
        }

        public ImportCharactersWindow(uint CharacterListId) : this()
        {
            this.CharacterListId = CharacterListId;
        }

        private void importBt_Click(object sender, EventArgs e)
        {
            uint[] selectedCharIds = charactersDgv.GetSelectedCharacters();

            if(selectedCharIds.Length > 0)
            {

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
