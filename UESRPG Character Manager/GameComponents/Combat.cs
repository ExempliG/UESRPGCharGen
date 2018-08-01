using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Xml.Serialization;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.GameComponents
{
    /// <summary>
    /// RemoteCombatant embodies a Combatant that is not local to this app, i.e., NPCs.
    /// </summary>
    public class RemoteCombatant : ICombatant
    {
        public string Name { get; set; }
        public string ApString   { get; private set; }
        public uint Initiative { get; set; }

        public RemoteCombatant()
        {
            Name = "Other Combatant(s)";
            ApString = "N/A";
            Initiative = 0;
        }

        public RemoteCombatant(CombatSave.SaveCombatant sc)
        {
            Name = sc.Name;
            ApString = sc.ApString;
            Initiative = sc.Initiative;
        }

        public void PassTurn()
        {
            // do nothing
        }

        public void TakeAction()
        {
            // do nothing
        }

        public void NewRound()
        {
            // do nothing
        }

        public bool CanAct()
        {
            return true;
        }
    }

    public class CombatSave : Combat
    {
        public struct SaveCombatant : ICombatant
        {
            public string Name { get; set; }
            public string ApString { get; set; }
            public uint Initiative { get; set; }
            public int Id { get; set; }

            public SaveCombatant(Character c)
            {
                Name = c.Name;
                ApString = c.ApString;
                Initiative = c.Initiative;
                Id = (int)c.Id;
            }

            public SaveCombatant(RemoteCombatant c)
            {
                Name = c.Name;
                ApString = c.ApString;
                Initiative = c.Initiative;
                Id = -1;
            }

            public void PassTurn()
            {
                // do nothing
            }

            public void TakeAction()
            {
                // do nothing
            }

            public void NewRound()
            {
                // do nothing
            }

            public bool CanAct()
            {
                return true;
            }
        }

        public List<SaveCombatant> SaveCombatants;
        new public uint CombatId { get; set; }
        new public int PreviousCombatantIndex { get; set; }
        new public int CurrentCombatantIndex { get; set; }

        public CombatSave()
        {
            SaveCombatants = new List<SaveCombatant>();
        }

        public CombatSave(Combat c)
        {
            CombatId = c.CombatId;
            PreviousCombatantIndex = c.PreviousCombatantIndex;
            CurrentCombatantIndex = c.CurrentCombatantIndex;

            SaveCombatants = new List<SaveCombatant>();
            foreach (ICombatant ic in c.Combatants)
            {
                if (ic.GetType() == typeof(Character))
                {
                    SaveCombatants.Add(new SaveCombatant((Character)ic));
                }
                else
                {
                    SaveCombatants.Add(new SaveCombatant((RemoteCombatant)ic));
                }
            }
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

        private Combat(CombatSave save)
        {
            CombatId = save.CombatId;
            PreviousCombatantIndex = save.PreviousCombatantIndex;
            CurrentCombatantIndex = save.CurrentCombatantIndex;
        }

        public static Combat Restore(CombatSave save)
        {
            Combat theCombat = save;

            theCombat.CombatId = save.CombatId;
            theCombat.PreviousCombatantIndex = save.PreviousCombatantIndex;
            theCombat.CurrentCombatantIndex = save.CurrentCombatantIndex;

            theCombat.Combatants = new List<ICombatant>();
            foreach(CombatSave.SaveCombatant sc in save.Combatants)
            {
                if (sc.Id >= 0)
                {
                    Character c = CharacterController.Instance.GetCharacterById((uint)sc.Id);
                    theCombat.Combatants.Add(c);
                }
                else
                {
                    RemoteCombatant rc = new RemoteCombatant(sc);
                    theCombat.Combatants.Add(rc);
                }
            }

            return theCombat;
        }

        public Combat(List<ICombatant> combatants) : this()
        {
            _combatants = combatants;
        }

        [XmlIgnore()]
        public List<ICombatant> Combatants
        {
            get         { return _combatants; }
            private set { _combatants = value; }
        }

        [XmlIgnore()]
        public int PreviousCombatantIndex
        {
            get; private set;
        }

        [XmlIgnore()]
        public int CurrentCombatantIndex
        {
            get; private set;
        }

        public delegate void CombatUpdatedHandler(object sender, EventArgs e);
        [Description("Fires when actions are taken or the Combat otherwise updates.")]
        public static event CombatUpdatedHandler CombatUpdated;
        public delegate void CombatantListUpdatedHandler(object sender, EventArgs e);
        [Description("Fires when the list of Combatants is altered.")]
        public static event CombatantListUpdatedHandler CombatantListUpdated;

        protected void onCombatUpdated()
        {
            CombatUpdated?.Invoke(this, new EventArgs());
        }

        protected void onCombatantListUpdated()
        {
            CombatantListUpdated?.Invoke(this, new EventArgs());
        }

        public void StepCombat()
        {
            _combatants[CurrentCombatantIndex].PassTurn();

            updateCombatantIndices();
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

            updateCombatantIndices();
            onCombatUpdated();
        }

        private void updateCombatantIndices()
        {
            // Store the previous combatant for the sake of removing the "active combatant indicator" in UI
            PreviousCombatantIndex = CurrentCombatantIndex;

            // Search for the next Combatant who can go
            do
            {
                CurrentCombatantIndex++;
                CurrentCombatantIndex %= _combatants.Count;
            }
            while (!_combatants[CurrentCombatantIndex].CanAct());
        }

        public void NewRound()
        {
            foreach(ICombatant c in _combatants)
            {
                c.NewRound();
            }

            CurrentCombatantIndex = 0;
            onCombatantListUpdated();
            onCombatUpdated();
        }

        public void AddCombatant(ICombatant newCombatant)
        {
            _combatants.Add(newCombatant);

            onCombatantListUpdated();
        }

        public void EditCombatantInitiative(int index, uint newValue)
        {
            _combatants[index].Initiative = newValue;
            onCombatantListUpdated();
        }

        public void RemoveCombatant(ICombatant toRemove)
        {
            _combatants.Remove(toRemove);

            onCombatantListUpdated();
        }

        public void RemoveCombatant(int indexToRemove)
        {
            if (indexToRemove >= 0 && indexToRemove < _combatants.Count)
            {
                _combatants.RemoveAt(indexToRemove);

                onCombatantListUpdated();
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
                _combatants[index] = _combatants[index - 1];
                _combatants[index - 1] = ic;

                onCombatantListUpdated();
            }
        }

        public void LowerCombatant( int index )
        {
            if (index >= 0 && index < _combatants.Count - 1)
            {
                ICombatant ic = _combatants[index];
                _combatants[index] = _combatants[index + 1];
                _combatants[index + 1] = ic;

                onCombatantListUpdated();
            }
        }
    }
}
