using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.Items
{
    public class Item
    {
        protected string _name;
        protected string _description;
        protected float _encumbrance;
        protected int _price;

        protected bool _isEquippable = false;
        protected List<string> _equipSlots;

        public enum ItemClass
        {
            INVENTORY,
            ARMOR,
            WEAPON
        }

        public Item(string name, string description, float encumbrance, int price)
        {
            _name = name;
            _description = description;
            _encumbrance = encumbrance;
            _price = price;
            Classification = ItemClass.INVENTORY;
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

        [XmlIgnore]
        public ItemClass Classification { get; protected set; }
    }
}
