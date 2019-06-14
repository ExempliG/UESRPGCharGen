using System;
using System.Windows.Forms;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.Selectors
{

    public partial class CharacterSelector : UserControl, ICharacterSelector
    {
        private class CharacterCbEntry
        {
            public string Name { get; set; }
            public Guid Guid { get; }

            public CharacterCbEntry(Character c)
            {
                Name = c.Name;
                Guid = c.Guid;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public uint SelectorId { get; private set; }
        public Guid Guid { get; private set; }

        public bool HasCharacter { get; private set; }
        public SelectedCharacterChangedHandler OnCharacterChanged { get; set; }
        public SelectedNewCharacterHandler OnSelectedNewCharacter { get; set; }
        public Guid GetCharacterGuid()
        {
            return ( ( CharacterCbEntry )charactersCb.SelectedItem ).Guid;
        }

        public CharacterSelector()
        {
            InitializeComponent();

            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
            SelectorId = CharacterController.Instance.StartSelector();

            HasCharacter = false;

            updateCharacterComboBox();
        }

        private void updateCharacterComboBox()
        {
            int selectedIndex = charactersCb.SelectedIndex;

            charactersCb.Items.Clear();
            foreach (Character c in CharacterController.Instance.CharacterDict.Values)
            {
                charactersCb.Items.Add( new CharacterCbEntry( c ) );
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
                if ( Guid != Guid.Empty )
                {
                    CharacterController.Instance.UnsubscribeFromCharacter( Guid, characterChanged );
                }
                Guid = ( ( CharacterCbEntry )charactersCb.SelectedItem ).Guid;
                HasCharacter = true;
                CharacterController.Instance.SubscribeToCharacter( Guid, characterChanged );
                selectedNewCharacter( SelectionType.NEW_CHARACTER );
            }
            else
            {
                HasCharacter = false;
            }
        }

        private void btAddCharacter_Click(object sender, EventArgs e)
        {
            Character newChar = CharacterController.Instance.AddCharacter();
            charactersCb.Items.Add( new CharacterCbEntry( newChar ) );
        }

        private void onCharacterListChanged(object sender, CharacterListChangedEventArgs e)
        {
            if (e.EventType != CharacterListChangedEvent.BEFORE_DELETE_CHARACTER)
            {
                updateCharacterComboBox();
            }
        }

        private void selectedNewCharacter( SelectionType type )
        {
            OnSelectedNewCharacter?.Invoke( this, new SelectedNewCharacterEventArgs( Guid, type ) );
        }

        protected void characterChanged( object sender, CharacterChangedEventArgs e )
        {
            OnCharacterChanged?.Invoke( this, e );
        }
    }
}
