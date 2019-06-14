using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public enum CharacterListChangedEvent
    {
        NEW_CHARACTER,
        BEFORE_DELETE_CHARACTER,
        AFTER_DELETE_CHARACTER,
        NEW_LIST
    }

    public class CharacterListChangedEventArgs : EventArgs
    {
        public Guid CharacterGuid { get; private set; }
        public CharacterListChangedEvent EventType { get; private set; }

        public bool IsMainList
        {
            get
            {
                return _characterListId < 0;
            }
        }
        public uint ListId
        {
            get
            {
                return (uint)_characterListId;
            }
        }

        private int _characterListId;

        public CharacterListChangedEventArgs(Guid characterGuid, CharacterListChangedEvent eventType)
        {
            CharacterGuid = characterGuid;
            _characterListId = -1;
            EventType = eventType;
        }

        public CharacterListChangedEventArgs(Guid characterGuid, int characterListId, CharacterListChangedEvent eventType)
        {
            CharacterGuid = characterGuid;
            _characterListId = characterListId;
            EventType = eventType;
        }

        public CharacterListChangedEventArgs(Guid characterGuid, uint characterListId, CharacterListChangedEvent eventType) :
            this(characterGuid, (int)characterListId, eventType)
        {

        }
    }
}
