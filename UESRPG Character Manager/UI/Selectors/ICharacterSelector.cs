using System;
using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.Selectors
{
    public delegate void SelectedCharacterChangedHandler( object o, CharacterChangedEventArgs e );
    public delegate void SelectedNewCharacterHandler( object o, SelectedNewCharacterEventArgs e );

    public interface ICharacterSelector
    {
        SelectedCharacterChangedHandler OnCharacterChanged { get; set; }
        SelectedNewCharacterHandler OnSelectedNewCharacter { get; set; }
        Guid GetCharacterGuid();
        bool HasCharacter { get; }
    }
}
