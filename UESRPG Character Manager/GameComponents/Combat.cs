using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Xml.Serialization;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.GameComponents
{
    /// <summary>
    /// RemoteCombatant embodies a Combatant that is not local to this app, i.e., NPCs.
    /// </summary>
    public class RemoteCombatant : ICombatant
    {
        public string Name { get; private set; }
        public string Ap   { get; private set; }

        public RemoteCombatant()
        {
            Name = "Other Combatant(s)";
            Ap = "N/A";
        }

        public string GetName()
        {
            return Name;
        }

        public string GetAp()
        {
            return Ap;
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

    public class Combat
    {
        public static uint NextAvailableId { get; set; }
        [XmlIgnore(), Browsable(false)]
        public uint CombatId { get; private set; }

        private List<ICombatant> _combatants;

        public Combat()
        {
            CombatId = NextAvailableId;
            NextAvailableId++;

            _combatants = new List<ICombatant>();
        }

        public Combat(List<ICombatant> combatants) : this()
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
        public static event CombatUpdatedHandler CombatUpdated;

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

            onCombatUpdated();
        }

        public void RemoveCombatant(ICombatant toRemove)
        {
            _combatants.Remove(toRemove);

            onCombatUpdated();
        }

        public void RemoveCombatant(int indexToRemove)
        {
            if (indexToRemove >= 0 && indexToRemove < _combatants.Count)
            {
                _combatants.RemoveAt(indexToRemove);

                onCombatUpdated();
            }
            else
            {
                throw new ArgumentOutOfRangeException("indexToRemove", indexToRemove, GameComponentExceptions.InvalidRemoveCombatantIndex);
            }
        }

        public void RaiseCombatant( int index )
        {
            if (index > 0 && index < _combatants.Count)
            {
                ICombatant ic = _combatants[index];
                _combatants.Remove(ic);
                _combatants.Insert(index - 1, ic);

                onCombatUpdated();
            }
        }

        public void LowerCombatant( int index )
        {
            if (index >= 0 && index < _combatants.Count - 1)
            {
                ICombatant ic = _combatants[index];
                _combatants.Remove(ic);
                _combatants.Insert(index + 1, ic);

                onCombatUpdated();
            }
        }
    }
}
