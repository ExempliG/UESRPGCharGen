using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.GameComponents
{
    public enum ActiveCombatsChangedEvent
    {
        ENDED_COMBAT,
        END_ALL_COMBATS,
        NEW_COMBAT,
        NEW_DICT
    }

    public class ActiveCombatsChangedEventArgs : EventArgs
    {
        public uint CombatId { get; set; }
        public ActiveCombatsChangedEvent EventType { get; set; }

        public ActiveCombatsChangedEventArgs(uint CombatId, ActiveCombatsChangedEvent EventType)
        {
            this.CombatId = CombatId;
            this.EventType = EventType;
        }
    }
}
