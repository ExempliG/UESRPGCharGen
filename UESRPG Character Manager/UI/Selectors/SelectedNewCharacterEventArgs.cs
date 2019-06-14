using System;

namespace UESRPG_Character_Manager.UI.Selectors
{
    public enum SelectionType
    {
        NO_CHARACTER,
        NEW_CHARACTER
    }

    public class SelectedNewCharacterEventArgs : EventArgs
    {
        public Guid CharacterGuid { get; private set; }
        public SelectionType EventType { get; private set; }

        public SelectedNewCharacterEventArgs(Guid characterGuid, SelectionType eventType )
        {
            CharacterGuid = characterGuid;
            EventType = eventType;
        }
    }
}
