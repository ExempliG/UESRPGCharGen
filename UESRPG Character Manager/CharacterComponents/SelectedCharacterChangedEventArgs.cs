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
        public Guid CharacterGuid { get; private set; }
        public uint SelectorId { get; private set; }
        public CharacterSelectionEvent EventType { get; private set; }

        public SelectedCharacterChangedEventArgs(Guid characterGuid, uint selectorId, CharacterSelectionEvent eventType)
        {
            CharacterGuid = characterGuid;
            SelectorId = selectorId;
            EventType = eventType;
        }
    }
}
