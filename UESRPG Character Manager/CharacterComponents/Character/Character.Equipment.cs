using System.Collections.Generic;
using System.Linq;

using UESRPG_Character_Manager.Items;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public List<Armor> EquippedArmorPieces { get; set; }

        /// <summary>
        /// Add a piece of armor, replacing any existing piece that belongs to the same body part
        /// </summary>
        /// <param name="piece">An Armor object to equip</param>
        /// <todo>
        /// Make this good (no but really, we should have an inventory
        /// instead of just blasting away Armor pieces)
        /// </todo>
        public void EquipNewArmor(Armor piece)
        {
            bool addNew = true;

            _inventory.AddToInventory( piece );

            for (int i = 0; i < EquippedArmorPieces.Count; i++)
            {
                if (EquippedArmorPieces[i].Location == piece.Location)
                {
                    EquippedArmorPieces[i] = piece;
                    addNew = false;
                    break;
                }
            }

            if (addNew)
            {
                EquippedArmorPieces.Add(piece);
                EquippedArmorPieces.Sort();
            }
        }

        public Armor GetEquippedArmorPiece(ArmorLocations location)
        {
            Armor result = new Armor();
            for (int i = 0; i < EquippedArmorPieces.Count; i++)
            {
                if (EquippedArmorPieces[i].Location == location)
                {
                    result = EquippedArmorPieces[i];
                    break;
                }
            }
            return result;
        }

        public List<Weapon> EquippedWeapons { get; set; }

        public void AddWeapon( Weapon newWeapon )
        {
            EquippedWeapons.Add( newWeapon );
            _inventory.AddToInventory( newWeapon );
            onWeaponsChanged();
        }

        public void EditWeapon( Weapon newWeapon )
        {
            IEnumerable<Weapon> weaponSearch = from Weapon w in EquippedWeapons
                                               where w.Guid == newWeapon.Guid
                                               select w;
            if ( weaponSearch.Count() == 1 )
            {
                Weapon currentWeapon = weaponSearch.ElementAt( 0 );
                int weaponIndex = EquippedWeapons.IndexOf( currentWeapon );
                EquippedWeapons[weaponIndex] = newWeapon;

                onWeaponsChanged();
            }
        }

        public void DeleteWeapon( Weapon weaponToDelete )
        {
            EquippedWeapons.Remove( weaponToDelete );
            _inventory.RemoveItemFromInventory( weaponToDelete );

            onWeaponsChanged();
        }
    }
}
