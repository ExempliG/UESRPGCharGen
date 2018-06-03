using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.GameComponents
{
    public interface ICombatant
    {
        void PassTurn();
        void TakeAction();
        void ResetRound();
        bool CanAct();
    }
}
