using System;
using System.Collections.Generic;
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
        }

        public float Encumbrance
        {
            get { return _encumbrance; }
        }

        public int Price
        {
            get { return _price; }
        }
    }
}
