using System.Collections.Generic;
using System.Linq;

using System.Xml.Serialization;

namespace UESRPG_Character_Manager.CharacterComponents
{
    partial class Character
    {
        public List<Power> Powers
        {
            get { return _powers; }
        }

        [XmlIgnore()]
        public List<Power> AggregatePowers
        {
            get
            {
                _aggregatePowers = new List<Power>();
                _aggregatePowers.AddRange(Race.Powers);
                _aggregatePowers.AddRange(_powers);
                return _aggregatePowers;
            }
        }

        public void AddPower(Power newPower)
        {
            _powers.Add(newPower);
        }

        public void EditPower(Power newPower)
        {
            IEnumerable<Power> powerSearch = from Power p in _powers
                                             where p.PowerId == newPower.PowerId
                                             select p;
            if (powerSearch.Count() == 1)
            {
                Power currentPower = powerSearch.ElementAt(0);
                int powerIndex = Powers.IndexOf(currentPower);
                Powers[powerIndex] = newPower;

                onPowerListChanged();
            }
        }

        public void DeletePower(Power powerToDelete)
        {
            _powers.Remove(powerToDelete);

            onPowerListChanged();
        }
    }
}
