using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;

namespace UESRPG_Character_Manager.Items
{
    public class Weapon : Item, IComparable, ICloneable
    {
        public static uint NextAvailableId { get; set; }

        private WeaponHandedness _handedness;

        public int NumberOfDice { get; set; }
        public int DiceSides { get; set; }
        public int DamageMod { get; set; }
        public int Penetration { get; set; }
        public int EnchantmentLevel { get; set; }
        public WeaponType Type { get; set; }
        public WeaponReach Reach { get; set; }
        public WeaponSize Size { get; set; }
        public WeaponQuality Quality { get; set; }
        public WeaponMaterial Material { get; set; }
        public bool IsDire { get; set; }

        [XmlIgnore(), Browsable(false)]
        public uint WeaponId { get; private set; }

        public WeaponHandedness Handedness
        {
            get
            {
                return _handedness;
            }
            set
            {
                // This ensures that equip slots are kept up-to-date.
                _equipSlots = new List<string>();
                if (value == WeaponHandedness.ONE || value == WeaponHandedness.HAND_AND_A_HALF)
                {
                    _equipSlots.Add("RIGHT_WEAPON");
                    _equipSlots.Add("LEFT_WEAPON");
                }
                if (value == WeaponHandedness.TWO || value == WeaponHandedness.HAND_AND_A_HALF)
                {
                    _equipSlots.Add("TWO_HAND_WEAPON");
                }

                _handedness = value;
            }
        }

        /// <summary>
        /// This empty default constructor exists only because XmlSerializer requires a default constructor.
        /// </summary>
        public Weapon () : base ("", "", 0, 0)
        {
            _isEquippable = true;

            WeaponId = NextAvailableId;
            NextAvailableId++;
        }

        public Weapon (int numberOfDice,
                       int diceSides,
                       int damageMod,
                       int penetration,
                       int encumbrance,
                       int enchantmentLevel,
                       int price,
                       WeaponType type,
                       WeaponReach reach,
                       WeaponHandedness handedness,
                       WeaponSize size) :
            base("", "", encumbrance, price)
        {
            NumberOfDice = numberOfDice;
            DiceSides = diceSides;
            DamageMod = damageMod;
            Penetration = penetration;
            EnchantmentLevel = enchantmentLevel;
            Type = type;
            Reach = reach;
            Handedness = handedness;
            Size = size;
            IsDire = false;
            Quality = WeaponQuality.MAX;
            Material = WeaponMaterial.MAX;

            _isEquippable = true;

            WeaponId = NextAvailableId;
            NextAvailableId++;
        }

        // Private Weapon constructor used in cloning to preserve Weapon ID.
        private Weapon(uint weaponId) : base("", "", 0, 0)
        {
            WeaponId = weaponId;
        }

        /// <summary>
        /// Adjust a weapon's stats by a Material Modifier.
        /// </summary>
        /// <param name="a">The weapon</param>
        /// <param name="b">The material modifier</param>
        /// <returns>The adjusted weapon</returns>
        public static Weapon ApplyMaterial (Weapon a, WeaponMaterialModifier b)
        {
            float enchLev = a.EnchantmentLevel;
            float price = a.Price;

            Weapon result = new Weapon()
            {
                NumberOfDice = a.NumberOfDice,
                DiceSides = a.DiceSides,
                Type = a.Type,
                Reach = a.Reach,
                Handedness = a.Handedness,
                Size = a.Size,
                DamageMod = a.DamageMod + b.DamageMod,
                Penetration = a.Penetration + b.PenetrationMod,
                _encumbrance = a.Encumbrance * b.EncumbranceMod,
                EnchantmentLevel = (int)((enchLev * b.EnchantMod) + 0.5),
                _price = (int)((price * b.PriceMod) + 0.5),
                IsDire = b.IsDire,
                Material = b.Material
            };
            return result;
        }

        /// <todo>Be more respectful of the IComparable interface, dude.</todo>
        public int CompareTo (object obj)
        {
            return ((IComparable)Type).CompareTo (((Weapon)obj).Type);
        }

        public override string ToString ()
        {
            return Name;
        }

        public object Clone()
        {
            Weapon w = new Weapon(this.WeaponId);

            w.DamageMod = this.DamageMod;
            w.NumberOfDice = this.NumberOfDice;
            w.DiceSides = this.DiceSides;
            w.Penetration = this.Penetration;
            w.EnchantmentLevel = this.EnchantmentLevel;
            w._encumbrance = this.Encumbrance;
            w._description = this.Description;
            w._name = this.Name;
            w._price = this.Price;
            w.Quality = this.Quality;
            w.Handedness = this.Handedness;
            w.EquipSlots = this.EquipSlots;
            w.Material = this.Material;
            w.Reach = this.Reach;
            w.Size = this.Size;
            w.Type = this.Type;

            return w;
        }
    }

    public struct WeaponMaterialModifier
    {
        public WeaponMaterial Material;
        public int DamageMod;
        public int PenetrationMod;
        public float EncumbranceMod;
        public float EnchantMod;
        public float PriceMod;
        public bool IsDire;

        public WeaponMaterialModifier (WeaponMaterial Material, int DamageMod, int PenetrationMod, float EncumbranceMod, float EnchantMod, float PriceMod, bool IsDire)
        {
            this.Material = Material;
            this.DamageMod = DamageMod;
            this.PenetrationMod = PenetrationMod;
            this.EncumbranceMod = EncumbranceMod;
            this.EnchantMod = EnchantMod;
            this.PriceMod = PriceMod;
            this.IsDire = IsDire;
        }
    }

    /// <summary>
    /// Weapon Template helper class
    /// </summary>
    /// <todo>For real, load these things from a .csv. TRUST</todo>
    public static class WeaponTemplates
    {
        static bool _s_isLoaded = false;

        private static Weapon[] _DefaultWeapons =
        {
            new Weapon(0,  0,  0,  0, 0,   0,   0, WeaponType.CUSTOM,           WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(3, 10,  5,  2, 3, 200, 310, WeaponType.DAI_KATANA,       WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(2, 10, 10,  5, 3, 175, 250, WeaponType.GLAIVE,           WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.LARGE),
            new Weapon(2, 10,  5, 15, 3, 175, 180, WeaponType.GRAND_MACE,       WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(3, 10,  5, 10, 3, 200, 260, WeaponType.GREAT_AXE,        WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(2, 10,  0,  5, 3, 175,  90, WeaponType.GREAT_CLUB,       WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(2, 10,  0, 10, 3, 175, 100, WeaponType.GREAT_FLAIL,      WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(3, 10,  5,  5, 4, 225, 300, WeaponType.GREAT_SWORD,      WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(2, 10,  4, 15, 4, 180, 200, WeaponType.HALBERD,          WeaponReach.VERY_LONG,  WeaponHandedness.TWO,               WeaponSize.LARGE),
            new Weapon(3, 10,  0, 10, 3, 175, 140, WeaponType.LONGSPEAR,        WeaponReach.VERY_LONG,  WeaponHandedness.TWO,               WeaponSize.LARGE),
            new Weapon(3, 10,  2, 25, 4, 200, 230, WeaponType.MAUL,             WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.HUGE),
            new Weapon(1, 10,  3,  5, 2, 200,  30, WeaponType.QUARTERSTAFF,     WeaponReach.LONG,       WeaponHandedness.TWO,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  6, 10, 2, 175, 210, WeaponType.BATTLE_AXE,       WeaponReach.LONG,       WeaponHandedness.HAND_AND_A_HALF,   WeaponSize.MEDIUM),
            new Weapon(2, 10,  5,  2, 2, 175, 260, WeaponType.KATANA,           WeaponReach.LONG,       WeaponHandedness.HAND_AND_A_HALF,   WeaponSize.MEDIUM),
            new Weapon(2, 10,  5,  5, 2, 175, 250, WeaponType.LONGSWORD,        WeaponReach.LONG,       WeaponHandedness.HAND_AND_A_HALF,   WeaponSize.MEDIUM),
            new Weapon(1, 10,  2, 15, 2, 175, 165, WeaponType.WARHAMMER,        WeaponReach.MEDIUM,     WeaponHandedness.HAND_AND_A_HALF,   WeaponSize.MEDIUM),
            new Weapon(2, 10,  2,  5, 2, 150, 175, WeaponType.BROADSWORD,       WeaponReach.MEDIUM,     WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(1, 10,  1,  5, 1,  50,  85, WeaponType.CLAWS,            WeaponReach.TOUCH,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(1, 10,  0,  5, 1, 100,  40, WeaponType.CLUB,             WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(1, 10,  2,  5, 1, 100,  70, WeaponType.DAGGER,           WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(1, 10,  0, 10, 1, 140,  50, WeaponType.FLAIL,            WeaponReach.MEDIUM,     WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  0, 10, 1, 125,  90, WeaponType.HATCHET,          WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(2, 10,  0,  0, 1, 140, 160, WeaponType.HOOK_SWORD,       WeaponReach.MEDIUM,     WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  1, 10, 1, 125,  80, WeaponType.JAVELIN,          WeaponReach.LONG,       WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(1, 10, -1,  5, 1,  50,  40, WeaponType.KNUCKLES,         WeaponReach.TOUCH,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(2, 10,  5, 10, 3, 175, 150, WeaponType.LANCE,            WeaponReach.VERY_LONG,  WeaponHandedness.ONE,               WeaponSize.HUGE),
            new Weapon(1, 10,  5, 15, 2, 140, 125, WeaponType.MACE,             WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(0,  0,  0,  0, 1,   0,  25, WeaponType.NET,              WeaponReach.LONG,       WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(1,  5,  0,  2, 1,  50, 100, WeaponType.PARRYING_DAGGER,  WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(1, 10,  0,  5, 0,  75,  50, WeaponType.PUNCH_DAGGER,     WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(2, 10,  1,  5, 1, 140, 125, WeaponType.RAPIER,           WeaponReach.LONG,       WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  2,  2, 1, 150, 200, WeaponType.SABRE,            WeaponReach.MEDIUM,     WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  3,  2, 2, 160, 225, WeaponType.SCIMITAR,         WeaponReach.MEDIUM,     WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  3, 10, 2, 140,  70, WeaponType.SHORTSPEAR,       WeaponReach.LONG,       WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(1, 10,  5,  5, 1, 125, 125, WeaponType.SHORTSWORD,       WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(1, 10,  2,  2, 1, 100,  75, WeaponType.TANTO,            WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(1, 10,  1,  5, 0,  75,  90, WeaponType.THROWING_DAGGER,  WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.SMALL),
            new Weapon(2, 10,  1, 10, 2, 150, 160, WeaponType.TRIDENT,          WeaponReach.LONG,       WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(1, 10,  5,  2, 1, 125, 130, WeaponType.WAKIZASHI,        WeaponReach.SHORT,      WeaponHandedness.ONE,               WeaponSize.MEDIUM),
            new Weapon(2, 10,  3, 10, 2, 150, 175, WeaponType.WAR_AXE,          WeaponReach.MEDIUM,     WeaponHandedness.ONE,               WeaponSize.MEDIUM)
        };

        public static Weapon[] DefaultWeapons
        {
            get
            {
                return _DefaultWeapons;
            }
        }

        private static WeaponMaterialModifier[] _Materials =
        {
            new WeaponMaterialModifier(WeaponMaterial.ADAMANTIUM, 1, 5, 0.9f, 7.0f, 5.0f, true),
            new WeaponMaterialModifier(WeaponMaterial.CHITIN, -1, -5, 0.6f, 1, 0.7f, false),
            new WeaponMaterialModifier(WeaponMaterial.DAEDRIC, 5, 10, 1.6f, 10, 50, true),
            new WeaponMaterialModifier(WeaponMaterial.DRAGONBONE, 5, 7, 1.6f, 9, 100, false),
            new WeaponMaterialModifier(WeaponMaterial.DWEMER, 1, 3, 1.3f, 4, 3, false),
            new WeaponMaterialModifier(WeaponMaterial.EBONY, 5, 5, 1.5f, 9, 8, true),
            new WeaponMaterialModifier(WeaponMaterial.IRON, -1, -5, 1.2f, 2, 0.5f, false),
            new WeaponMaterialModifier(WeaponMaterial.MALACHITE, 2, 5, 0.6f, 6, 6, true),
            new WeaponMaterialModifier(WeaponMaterial.MOONSTONE, 0, 3, 0.8f, 5, 5, false),
            new WeaponMaterialModifier(WeaponMaterial.ORICHALCUM, 0, 5, 1.2f, 4, 2.5f, false),
            new WeaponMaterialModifier(WeaponMaterial.SILVER, -1, 0, 1, 3, 1.8f, true),
            new WeaponMaterialModifier(WeaponMaterial.STAHLRIM, 3, 5, 1.2f, 8, 6.5f, true),
            new WeaponMaterialModifier(WeaponMaterial.STEEL, 0, 0, 1, 3, 1, false),
            new WeaponMaterialModifier(WeaponMaterial.WOOD, -5, -5, 0.6f, 0.5f, 0.2f, false)
        };

        public static WeaponMaterialModifier[] Materials
        {
            get
            {
                return _Materials;
            }
        }
    }

    public enum WeaponType
    {
        CUSTOM,
        DAI_KATANA,
        GLAIVE,
        GRAND_MACE,
        GREAT_AXE,
        GREAT_CLUB,
        GREAT_FLAIL,
        GREAT_SWORD,
        HALBERD,
        LONGSPEAR,
        MAUL,
        QUARTERSTAFF,
        BATTLE_AXE,
        KATANA,
        LONGSWORD,
        WARHAMMER,
        BROADSWORD,
        CLAWS,
        CLUB,
        DAGGER,
        FLAIL,
        HATCHET,
        HOOK_SWORD,
        JAVELIN,
        KNUCKLES,
        LANCE,
        MACE,
        NET,
        PARRYING_DAGGER,
        PUNCH_DAGGER,
        RAPIER,
        SABRE,
        SCIMITAR,
        SHORTSPEAR,
        SHORTSWORD,
        TANTO,
        THROWING_DAGGER,
        TRIDENT,
        WAKIZASHI,
        WAR_AXE,
        MAX
    }

    public enum WeaponHandedness
    {
        ONE,
        HAND_AND_A_HALF,
        TWO,
        MAX
    }

    public enum WeaponSize
    {
        SMALL,
        MEDIUM,
        LARGE,
        HUGE,
        ENORMOUS,
        MAX
    }

    public enum WeaponReach
    {
        TOUCH,
        SHORT,
        MEDIUM,
        LONG,
        VERY_LONG,
        MAX
    }

    public enum WeaponQuality
    {
        TERRIBLE,
        POOR,
        COMMON,
        EXPENSIVE,
        EXTRAVAGANT,
        EXQUISITE,
        MAX
    }

    public enum WeaponMaterial
    {
        ADAMANTIUM,
        CHITIN,
        DAEDRIC,
        DRAGONBONE,
        DWEMER,
        EBONY,
        IRON,
        MALACHITE,
        MOONSTONE,
        ORICHALCUM,
        SILVER,
        STAHLRIM,
        STEEL,
        WOOD,
        MAX
    }
}


// Not a perfect solution, but...
// https://regex101.com

// Regex used: ^(?'type'[a-z|A-Z|\/|\s|-]+)\s(?'NumOfDice'\d+)d(?'DiceSides'\d+)\+?(?'DamageMod'-?\d)?\s(?'DamageType'[R|I|H])?\s?(?'Pen'\d+)\s(?'Size'[A-Z])\s(?'Reach'[A-Z]+)\s[a-z|A-Z|\s|,]+\s(?'Enc'\d+)?\s?(?'EnchLvl'\d+)\s(?'Price'\d+)$

// Substitution used: new Weapon(${NumOfDice}, ${DiceSides}, ${DamageMod}, ${Pen}, ${Enc}, ${EnchLvl}, ${Price}, WeaponType.${type}, WeaponReach.${Reach}, WeaponHandedness., WeaponSize.${Size}),
