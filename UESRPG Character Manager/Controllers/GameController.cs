using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The GameController class handles game mechanics not explicitly related to Character handling, such as the creation of Combat
    /// objects, management of combat rounds, and so on.
    /// </summary>
    public class GameController
    {
        private static GameController _instance;
        private static bool _isInitialized = false;

        private List<Combat> _activeCombats;

        private GameController()
        {
            _activeCombats = new List<Combat>();
        }

        public static GameController Instance
        {
            get
            {
                if (!_isInitialized)
                {
                    _instance = new GameController();
                    _isInitialized = true;
                }
                return _instance;
            }
        }

        public uint CreateNewCombat()
        {
            Combat newCombat = new Combat();
            _activeCombats.Add(newCombat);
            return newCombat.CombatId;
        }

        public void EndCombat(uint id)
        {
            Combat c = GetCombatById(id);
            _activeCombats.Remove(c);
        }

        public Combat GetCombatById(uint id)
        {
            IEnumerable<Combat> combatSearch = from Combat c in _activeCombats
                                               where c.CombatId == id
                                               select c;
            if (combatSearch.Count() == 1)
            {
                Combat combatResult = combatSearch.ElementAt(0);
                return combatResult;
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, GameControllerExceptionMessages.InvalidCombatId);
            }
        }

        public void ResetCombat()
        {

        }

        public void StepCombat( uint id, bool takeAction )
        {
            Combat c = GetCombatById(id);
            c.StepCombat(takeAction);
        }

        public void AddCombatant( uint id, ICombatant combatant )
        {
            Combat c = GetCombatById(id);
            c.AddCombatant(combatant);
        }

        public void RemoveCombatant( uint id, int indexToRemove )
        {
            Combat c = GetCombatById(id);
            c.RemoveCombatant(indexToRemove);
        }

        public void RaiseCombatant( uint id, int index )
        {
            Combat c = GetCombatById(id);
            c.RaiseCombatant(index);
        }

        public void LowerCombatant( uint id, int index )
        {
            Combat c = GetCombatById(id);
            c.LowerCombatant(index);
        }
    }
}
