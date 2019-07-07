﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Xml.Serialization;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;
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

        public RemoteCombatant(Character c)
        {
            Name = c.Name;
            ApString = c.ApString;
            Initiative = c.Initiative;
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
            public Guid Guid { get; set; }

            public SaveCombatant(Character c)
            {
                Name = c.Name;
                ApString = c.ApString;
                Initiative = c.Initiative;
                Guid = c.Guid;
            }

            public SaveCombatant(RemoteCombatant c)
            {
                Name = c.Name;
                ApString = c.ApString;
                Initiative = c.Initiative;
                Guid = Guid.Empty;
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

            CharacterController.Instance.CharacterListChanged += onCharacterListChanged;
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
            foreach(CombatSave.SaveCombatant sc in save.SaveCombatants)
            {
                bool processed = false;

                // Handle cases where a Combat is restored from a Save, but a Combatant was deleted.
                if (sc.Guid != Guid.Empty)
                {
                    try
                    {
                        Character c = CharacterController.Instance.GetCharacterByGuid(sc.Guid);
                        theCombat.Combatants.Add(c);
                        processed = true;
                    }
                    catch(KeyNotFoundException e)
                    {
                        processed = false;
                    }
                }
                
                if(!processed)
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

        protected void onCharacterListChanged(object sender, CharacterListChangedEventArgs e)
        {
            // Handle Character deletion by converting the Character to a RemoteCombatant
            if(e.EventType == CharacterListChangedEvent.BEFORE_DELETE_CHARACTER)
            {
                // Select a tuple containing the List element and its index in the list
                var search = Combatants
                                .Select((ic, index) => new { Combatant = ic, Index = index })
                                .Where((item) => { return item.Combatant.GetType() == typeof(Character); })
                                .Where((item) => { return ((Character)item.Combatant).Guid == e.CharacterGuid; });
                if(search.Count() == 1)
                {
                    var item = search.ElementAt(0);
                    Character c = (Character)item.Combatant;
                    RemoteCombatant rc = new RemoteCombatant(c);
                    Combatants[item.Index] = rc;

                    onCombatantListUpdated();
                }
            }
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

            // Search for the next Combatant who can go (stopping once the search arrives back at the Previous combatant)
            do
            {
                CurrentCombatantIndex++;
                CurrentCombatantIndex %= _combatants.Count;
            }
            while (!_combatants[CurrentCombatantIndex].CanAct() && CurrentCombatantIndex != PreviousCombatantIndex);
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