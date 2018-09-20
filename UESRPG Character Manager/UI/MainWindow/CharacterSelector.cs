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
        public uint SelectorId { get; private set; }
        public uint CharacterId { get; private set; }
        private bool _hasActiveCharacter;

        public CharacterSelector()
        {
            InitializeComponent();

            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
            SelectorId = CharacterController.Instance.StartSelector();

            _hasActiveCharacter = false;

            updateCharacterComboBox();
        }

        public bool HasActiveCharacter()
        {
            return _hasActiveCharacter;
        }

        private void updateCharacterComboBox()
        {
            int selectedIndex = charactersCb.SelectedIndex;

            charactersCb.Items.Clear();
            foreach (Character c in CharacterController.Instance.CharacterDict.Values)
            {
                charactersCb.Items.Add(c.Name);
            }

            if (charactersCb.Items.Count != 0 && charactersCb.Items.Count >= selectedIndex && selectedIndex >= 0)
            {
                charactersCb.SelectedIndex = selectedIndex;
            }
            else if(charactersCb.Items.Count > 0)
            {
                charactersCb.SelectedIndex = 0;
            }
            else
            {
                charactersCb.SelectedIndex = -1;
                charactersCb.Text = string.Empty;
            }
        }

        private void charactersCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (charactersCb.SelectedIndex >= 0)
            {
                CharacterController.Instance.SelectCharacter(charactersCb.SelectedIndex, SelectorId);
            }
        }

        private void btAddCharacter_Click(object sender, EventArgs e)
        {
            Character newChar = CharacterController.Instance.AddCharacter();
            charactersCb.Items.Add(newChar.Name);
        }

        private void onCharacterListChanged(object sender, CharacterListChangedEventArgs e)
        {
            if (e.EventType != CharacterListChangedEvent.BEFORE_DELETE_CHARACTER)
            {
                updateCharacterComboBox();
            }
        }
    }
}
