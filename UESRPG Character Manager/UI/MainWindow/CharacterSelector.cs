using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UESRPG_Character_Manager.UI.MainWindow
{

    public partial class CharacterSelector : UserControl
    {
        public delegate void SelectedCharacterChangedHandler(object sender, EventArgs e);
        [Description("Fires when the selected character changes.")]
        public event SelectedCharacterChangedHandler SelectedCharacterChanged;

        private List<Character> _characterList;
        private Character _selectedChar;
        private int _selectedIndex = 0;

        public CharacterSelector()
        {
            InitializeComponent();

            _characterList = new List<Character>();
            _selectedChar = new Character();
            _selectedChar.Update();
            _characterList.Add(_selectedChar);
            updateCharacterComboBox();
            onSelectedCharacterChanged();
        }

        public void ForceUpdate()
        {
            onSelectedCharacterChanged();
        }

        public bool HasActiveCharacter()
        {
            return (_selectedChar != null);
        }

        public bool TryGetActiveCharacter(out Character activeCharacter)
        {
            bool result = (_selectedChar == null);
            activeCharacter = result ? new Character() : _selectedChar;
            return result;
        }

        public Character GetActiveCharacter()
        {
            return _selectedChar;
        }

        public void LoadCharacterList(List<Character> loadedList)
        {
            _characterList = loadedList;

            updateCharacterComboBox();
        }

        public List<Character> GetCharacterList()
        {
            return _characterList;
        }

        private void updateCharacterComboBox()
        {
            charactersCb.Items.Clear();
            foreach (Character c in _characterList)
            {
                charactersCb.Items.Add(c.Name);
            }
            charactersCb.SelectedIndex = 0;
        }

        private void charactersCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = charactersCb.SelectedIndex;
            if (_selectedIndex >= 0 && _selectedIndex < _characterList.Count)
            {
                _selectedChar = _characterList[_selectedIndex];

                onSelectedCharacterChanged();
            }
        }

        protected void onSelectedCharacterChanged()
        {
            // Invoke the event if subscribers exist
            SelectedCharacterChanged?.Invoke(this, new System.EventArgs());
        }

        private void btAddCharacter_Click(object sender, EventArgs e)
        {
            Character newChar = new Character();
            newChar.Update();
            _characterList.Add(newChar);
            charactersCb.Items.Add(newChar.Name);
        }
    }
}
