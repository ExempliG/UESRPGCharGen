using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.MainWindow
{

    public partial class CharacterSelector : UserControl
    {
        public CharacterSelector()
        {
            InitializeComponent();

            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;

            updateCharacterComboBox();
        }

        public bool HasActiveCharacter()
        {
            return (CharacterController.Instance.ActiveCharacter != null);
        }

        private void updateCharacterComboBox()
        {
            charactersCb.Items.Clear();
            foreach (Character c in CharacterController.Instance.CharacterList)
            {
                charactersCb.Items.Add(c.Name);
            }
            charactersCb.SelectedIndex = 0;
        }

        private void charactersCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (charactersCb.SelectedIndex >= 0)
            {
                CharacterController.Instance.SelectCharacter((uint)charactersCb.SelectedIndex);
            }
        }

        private void btAddCharacter_Click(object sender, EventArgs e)
        {
            Character newChar = CharacterController.Instance.AddCharacter();
            charactersCb.Items.Add(newChar.Name);
        }

        private void onCharacterListChanged(object sender, EventArgs e)
        {
            updateCharacterComboBox();
        }
    }
}
