using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
            onActiveCombatsChanged(newCombat.CombatId, ActiveCombatsChangedEvent.NEW_COMBAT);
            return newCombat.CombatId;
        }

        public void SetCombatDict(Dictionary<uint, Combat> dict)
        {
            // End all combats before trying to load the new ones
            onActiveCombatsChanged(0, ActiveCombatsChangedEvent.END_ALL_COMBATS);

            _activeCombats = dict;
            onActiveCombatsChanged(0, ActiveCombatsChangedEvent.NEW_DICT);
        }

        public void EndCombat(uint id)
        {
            _activeCombats.Remove(id);
            onActiveCombatsChanged(id, ActiveCombatsChangedEvent.ENDED_COMBAT);
        }

        public bool CombatIsActive(uint id)
        {
            return _activeCombats.ContainsKey(id);
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

        #region Events
        public delegate void ActiveCombatsChangedHandler(object sender, ActiveCombatsChangedEventArgs e);
        [Description("Fires when the Active Combats dictionary is altered.")]
        public event ActiveCombatsChangedHandler ActiveCombatsChanged;

        protected void onActiveCombatsChanged(uint combatId, ActiveCombatsChangedEvent eventType)
        {
            ActiveCombatsChanged?.Invoke(this, new ActiveCombatsChangedEventArgs(combatId, eventType));
        }
        #endregion
    }
}
