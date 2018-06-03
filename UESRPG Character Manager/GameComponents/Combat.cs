using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.GameComponents
{
    /// <summary>
    /// RemoteCombatant embodies a Combatant that is not local to this app, i.e., NPCs.
    /// </summary>
    public class RemoteCombatant : ICombatant
    {
        public string Name { get; private set; }

        public RemoteCombatant()
        {
            Name = "Other Combatant(s)";
        }

        public void PassTurn()
        {
            // do nothing
        }

        public void TakeAction()
        {
            // do nothing
        }

        public void ResetRound()
        {
            // do nothing
        }

        public bool CanAct()
        {
            return true;
        }
    }

    class Combat
    {
        private List<ICombatant> _combatants;

        public Combat(List<ICombatant> combatants)
        {
            _combatants = combatants;
        }

        public List<ICombatant> Combatants
        {
            get         { return _combatants; }
            private set { _combatants = value; }
        }

        public int CurrentCombatantIndex
        {
            get; private set;
        }

        public delegate void CombatUpdatedHandler(object sender, EventArgs e);
        [Description("Fires when actions are taken or the Combat otherwise updates (e.g. new Combatants).")]
        public CombatUpdatedHandler CombatUpdated;

        protected void onCombatUpdated()
        {
            CombatUpdated?.Invoke(this, new EventArgs());
        }

        public void StepCombat()
        {
            _combatants[CurrentCombatantIndex].PassTurn();

            CurrentCombatantIndex++;
            CurrentCombatantIndex %= _combatants.Count;

            onCombatUpdated();
        }

        public void StepCombat( bool takeAction )
        {
            if( takeAction )
            {
                _combatants[CurrentCombatantIndex].TakeAction();
            }
            else
            {
                _combatants[CurrentCombatantIndex].PassTurn();
            }

            CurrentCombatantIndex++;
            CurrentCombatantIndex %= _combatants.Count;

            onCombatUpdated();
        }

        public void AddCombatant(ICombatant newCombatant)
        {
            _combatants.Add(newCombatant);
        }
    }
}
