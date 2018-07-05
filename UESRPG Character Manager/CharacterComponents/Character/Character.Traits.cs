using System.Collections.Generic;
using System.Linq;

using System.Xml.Serialization;

namespace UESRPG_Character_Manager.CharacterComponents
{
    partial class Character
    {
        public List<Trait> Traits
        {
            get { return _traits; }
        }

        [XmlIgnore()]
        public List<Trait> AggregateTraits
        {
            get
            {
                _aggregateTraits = new List<Trait>();
                _aggregateTraits.AddRange(Race.Traits);
                _aggregateTraits.AddRange(_traits);
                return _aggregateTraits;
            }
        }

        public void AddTrait(Trait newTrait)
        {
            _traits.Add(newTrait);
        }

        public void EditTrait(Trait newTrait)
        {
            IEnumerable<Trait> traitSearch = from Trait t in _traits
                                             where t.TraitId == newTrait.TraitId
                                             select t;
            if (traitSearch.Count() == 1)
            {
                Trait currentTrait = traitSearch.ElementAt(0);
                int traitIndex = Traits.IndexOf(currentTrait);
                Traits[traitIndex] = newTrait;

                onTraitListChanged();
            }
        }

        public void DeleteTrait(Trait traitToDelete)
        {
            _traits.Remove(traitToDelete);

            onTraitListChanged();
        }
    }
}
