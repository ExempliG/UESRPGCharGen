using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.GameComponents
{
    class Combat
    {
        private List<Character> _combatants;
        private int _currentCombatantIndex;

        public Combat(List<Character> combatants)
        {
            _combatants = combatants;
        }

        public void StepCombat( bool takeAction )
        {
            if( takeAction )
            {
                
            }
        }
    }
}
