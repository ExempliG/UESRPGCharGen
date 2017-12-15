using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.Items
{
    public class Item : ICloneable
    {
        protected string _name;
        protected string _description;
        protected float _encumbrance;
        protected int _price;

        protected bool _isEquippable = false;
        protected List<string> _equipSlots;

        public Item(string name, string description, float encumbrance, int price)
        {
            _name = name;
            _description = description;
            _encumbrance = encumbrance;
            _price = price;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public float Encumbrance
        {
            get { return _encumbrance; }
            set { _encumbrance = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public bool IsEquippable
        {
            get { return _isEquippable; }
            set { _isEquippable = value; }
        }

        public List<string> EquipSlots
        {
            get { return _equipSlots; }
            set { _equipSlots = value; }
        }

        public object Clone()
        {
            Item i = new Item(_name, _description, _encumbrance, _price);

            i.IsEquippable = _isEquippable;
            i.EquipSlots = new List<string>();
            foreach(string slot in EquipSlots)
            {
                i.EquipSlots.Add(slot);
            }

            return i;
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(Item))
            {
                return false;
            }

            Item i = (Item)obj;

            return
            (
                i.Name == Name &&
                i.Description == Description &&
                i.Encumbrance == Encumbrance &&
                i.Price == Price &&
                i.IsEquippable == IsEquippable &&
                i.EquipSlots.SequenceEqual(EquipSlots)
            );
        }
    }
}
