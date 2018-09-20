using System;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public enum CharacterSelectionEvent
    {
        NO_CHARACTER,
        NEW_CHARACTER,
        SAME_CHARACTER
    }

    public class SelectedCharacterChangedEventArgs : EventArgs
    {
        public uint CharacterId { get; private set; }
        public uint SelectorId { get; private set; }
        public CharacterSelectionEvent EventType { get; private set; }

        public SelectedCharacterChangedEventArgs(uint characterId, uint selectorId, CharacterSelectionEvent eventType)
        {
            CharacterId = characterId;
            SelectorId = selectorId;
            EventType = eventType;
        }
    }
}
