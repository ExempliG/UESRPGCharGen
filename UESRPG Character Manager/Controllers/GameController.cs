using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.GameComponents;
using UESRPG_Character_Manager.Common;

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The GameController class handles game mechanics not explicitly related to Character handling, such as the creation of Combat
    /// objects, management of combat rounds, and so on.
    /// </summary>
    public class GameController : Singleton<GameController>
    {
        private Dictionary<uint, Combat> _activeCombats;

        public GameController()
        {
            _activeCombats = new Dictionary<uint, Combat>();
        }

        public Dictionary<uint, Combat> CombatDict
        {
            get { return _activeCombats; }
            private set { _activeCombats = value; }
        }

        public uint CreateNewCombat()
        {
            Combat newCombat = new Combat();
            _activeCombats.Add(newCombat.CombatId, newCombat);
            return newCombat.CombatId;
        }

        public void AddCombat(Combat c)
        {
            _activeCombats.Add(c.CombatId, c);
        }

        public void EndCombat(uint id)
        {
            _activeCombats.Remove(id);
        }

        public Combat GetCombatById(uint id)
        {
            if (_activeCombats.ContainsKey(id))
            {
                return _activeCombats[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, GameControllerExceptionMessages.InvalidCombatId);
            }
        }

        public void NewRound( uint id )
        {
            Combat c = GetCombatById(id);
            c.NewRound();
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

        public void EditCombatantInitiative( uint id, int combatantIndex, uint newValue)
        {
            Combat c = GetCombatById(id);
            c.EditCombatantInitiative(combatantIndex, newValue);
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
