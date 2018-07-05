using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.GameComponents
{
    public interface ICombatant
    {
        string Name { get; set; }
        string ApString { get; }
        uint Initiative { get; set; }
        void PassTurn();
        void TakeAction();
        void NewRound();
        bool CanAct();
    }
}
