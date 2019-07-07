using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESRPG_Character_Manager.Items;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    public class Inventory : List<Item>
    {
        public Inventory() : base()
        {
        }

        public List<Armor> GetArmors()
        {
            IEnumerable<Armor> armors = from i in this
                                        where i.Classification == Item.ItemClass.ARMOR
                                        select (Armor)i;
            return armors.ToList();
        }

        public List<Weapon> GetWeapons()
        {
            IEnumerable<Weapon> weapons = from i in this
                                          where i.Classification == Item.ItemClass.WEAPON
                                          select (Weapon)i;
            return weapons.ToList();
        }

        public List<Item> GetEquipment()
        {
            IEnumerable<Item> items = from i in this
                                      where i.IsEquippable
                                      select i;
            return items.ToList();
        }

        public void AddToInventory( Item i )
        {
            Add( i );
        }

        public void RemoveItemFromInventory( Item i )
        {
            Remove( i );
        }
    }
}
