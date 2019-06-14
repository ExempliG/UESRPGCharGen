using System.Collections.Generic;
using System.Linq;

using UESRPG_Character_Manager.Items;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public List<Armor> ArmorPieces
        {
            get { return _armorPieces; }
            set { _armorPieces = value; }
        }

        /// <summary>
        /// Add a piece of armor, replacing any existing piece that belongs to the same body part
        /// </summary>
        /// <param name="piece">An Armor object to equip</param>
        /// <todo>
        /// Make this good (no but really, we should have an inventory
        /// instead of just blasting away Armor pieces)
        /// </todo>
        public void AddArmorPiece(Armor piece)
        {
            bool addNew = true;

            for (int i = 0; i < _armorPieces.Count; i++)
            {
                if (_armorPieces[i].Location == piece.Location)
                {
                    _armorPieces[i] = piece;
                    addNew = false;
                    break;
                }
            }

            if (addNew)
            {
                _armorPieces.Add(piece);
                _armorPieces.Sort();
            }
        }

        public Armor GetArmorPiece(ArmorLocations location)
        {
            Armor result = new Armor();
            for (int i = 0; i < _armorPieces.Count; i++)
            {
                if (_armorPieces[i].Location == location)
                {
                    result = _armorPieces[i];
                    break;
                }
            }
            return result;
        }

        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public void AddWeapon(Weapon newWeapon)
        {
            Weapons.Add(newWeapon);
            onWeaponsChanged();
        }

        public void EditWeapon(Weapon newWeapon)
        {
            IEnumerable<Weapon> weaponSearch = from Weapon w in Weapons
                                               where w.Guid == newWeapon.Guid
                                               select w;
            if (weaponSearch.Count() == 1)
            {
                Weapon currentWeapon = weaponSearch.ElementAt(0);
                int weaponIndex = Weapons.IndexOf(currentWeapon);
                Weapons[weaponIndex] = newWeapon;

                onWeaponsChanged();
            }
        }

        public void DeleteWeapon(Weapon weaponToDelete)
        {
            Weapons.Remove(weaponToDelete);

            onWeaponsChanged();
        }
    }
}
