using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager
{
    public class Weapon : IComparable
    {
        public string Name { get; set; }
        public int NumberOfDice { get; set; }
        public int DiceSides { get; set; }
        public int DamageMod { get; set; }
        public int Penetration { get; set; }
        public float EncumbranceValue { get; set; }
        public int EnchantmentLevel { get; set; }
        public int Price { get; set; }
        public WeaponType Type { get; set; }
        public WeaponReach Reach { get; set; }
        public WeaponHandedness Handedness { get; set; }
        public WeaponSize Size { get; set; }
        public WeaponQuality Quality { get; set; }
        public WeaponMaterial Material { get; set; }
        public bool IsDire { get; set; }

        /// <summary>
        /// This empty default constructor exists only because XmlSerializer requires a default constructor.
        /// </summary>
        public Weapon ()
        {

        }

        public Weapon (int NumberOfDice, int DiceSides, int DamageMod, int Penetration,
                       float EncumbranceValue, int EnchantmentLevel, int Price, WeaponType Type,
                       WeaponReach Reach, WeaponHandedness Handedness, WeaponSize Size)
        {
            this.NumberOfDice = NumberOfDice;
            this.DiceSides = DiceSides;
            this.DamageMod = DamageMod;
            this.Penetration = Penetration;
            this.EncumbranceValue = EncumbranceValue;
            this.EnchantmentLevel = EnchantmentLevel;
            this.Price = Price;
            this.Type = Type;
            this.Reach = Reach;
            this.Handedness = Handedness;
            this.Size = Size;
            IsDire = false;
            Quality = WeaponQuality.MAX;
            Material = WeaponMaterial.MAX;
        }

        /// <summary>
        /// Adjust a weapon's stats by a Material Modifier.
        /// </summary>
        /// <param name="a">The weapon</param>
        /// <param name="b">The material modifier</param>
        /// <returns>The adjusted weapon</returns>
        /// <todo>This doesn't need to be an operator. You just thought it would be cool.</todo>
        public static Weapon operator * (Weapon a, WeaponMaterialModifier b)
        {
            Weapon result = new Weapon ();
            result.NumberOfDice = a.NumberOfDice;
            result.DiceSides = a.DiceSides;
            result.DamageMod = a.DamageMod;
            result.Penetration = a.Penetration;
            result.EncumbranceValue = a.EncumbranceValue;
            result.EnchantmentLevel = a.EnchantmentLevel;
            result.Price = a.Price;
            result.Type = a.Type;
            result.Reach = a.Reach;
            result.Handedness = a.Handedness;
            result.Size = a.Size;
            result.DamageMod = a.DamageMod + b.DamageMod;
            result.Penetration = a.Penetration + b.PenetrationMod;
            result.EncumbranceValue = a.EncumbranceValue * b.EncumbranceMod;
            float enchLev = a.EnchantmentLevel;
            result.EnchantmentLevel = (int)((enchLev * b.EnchantMod) + 0.5);
            float price = a.Price;
            result.Price = (int)((price * b.PriceMod) + 0.5);
            result.IsDire = b.IsDire;
            result.Material = b.Material;
            return result;
        }

        /// <summary>
        /// Material adjustment is commutative.
        /// </summary>
        /// <todo>Will be obsolete when the operator is changed to a Real Function(TM)</todo>
        public static Weapon operator * (WeaponMaterialModifier a, Weapon b)
        {
            return (b * a);
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
        static bool IsLoaded = false;

        private static Weapon[] _DefaultWeapons =
        {
            new Weapon(3, 10, 5, 2, 3, 200, 310, WeaponType.DAI_KATANA, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(2, 10, 10, 5, 3, 175, 250, WeaponType.GLAIVE, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.LARGE),
            new Weapon(2, 10, 5, 15, 3, 175, 180, WeaponType.GRAND_MACE, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(3, 10, 5, 10, 3, 200, 260, WeaponType.GREAT_AXE, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(2, 10, 0, 5, 3, 175, 90, WeaponType.GREAT_CLUB, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(2, 10, 0, 10, 3, 175, 100, WeaponType.GREAT_FLAIL, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(3, 10, 5, 5, 4, 225, 300, WeaponType.GREAT_SWORD, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(2, 10, 4, 15, 4, 180, 200, WeaponType.HALBERD, WeaponReach.VERY_LONG, WeaponHandedness.TWO, WeaponSize.LARGE),
            new Weapon(3, 10, 0, 10, 3, 175, 140, WeaponType.LONGSPEAR, WeaponReach.VERY_LONG, WeaponHandedness.TWO, WeaponSize.LARGE),
            new Weapon(3, 10, 2, 25, 4, 200, 230, WeaponType.MAUL, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.HUGE),
            new Weapon(1, 10, 3, 5, 2, 200, 30, WeaponType.QUARTERSTAFF, WeaponReach.LONG, WeaponHandedness.TWO, WeaponSize.MEDIUM),
            new Weapon(2, 10, 6, 10, 2, 175, 210, WeaponType.BATTLE_AXE, WeaponReach.LONG, WeaponHandedness.HAND_AND_A_HALF, WeaponSize.MEDIUM),
            new Weapon(2, 10, 5, 2, 2, 175, 260, WeaponType.KATANA, WeaponReach.LONG, WeaponHandedness.HAND_AND_A_HALF, WeaponSize.MEDIUM),
            new Weapon(2, 10, 5, 5, 2, 175, 250, WeaponType.LONGSWORD, WeaponReach.LONG, WeaponHandedness.HAND_AND_A_HALF, WeaponSize.MEDIUM),
            new Weapon(1, 10, 2, 15, 2, 175, 165, WeaponType.WARHAMMER, WeaponReach.MEDIUM, WeaponHandedness.HAND_AND_A_HALF, WeaponSize.MEDIUM),
            new Weapon(2, 10, 2, 5, 2, 150, 175, WeaponType.BROADSWORD, WeaponReach.MEDIUM, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(1, 10, 1, 5, 1, 50, 85, WeaponType.CLAWS, WeaponReach.TOUCH, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(1, 10, 0, 5, 1, 100, 40, WeaponType.CLUB, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(1, 10, 2, 5, 1, 100, 70, WeaponType.DAGGER, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(1, 10, 0, 10, 1, 140, 50, WeaponType.FLAIL, WeaponReach.MEDIUM, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(2, 10, 0, 10, 1, 125, 90, WeaponType.HATCHET, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(2, 10, 0, 0, 1, 140, 160, WeaponType.HOOK_SWORD, WeaponReach.MEDIUM, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(2, 10, 1, 10, 1, 125, 80, WeaponType.JAVELIN, WeaponReach.LONG, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(1, 10, -1, 5, 1, 50, 40, WeaponType.KNUCKLES, WeaponReach.TOUCH, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(2, 10, 5, 10, 3, 175, 150, WeaponType.LANCE, WeaponReach.VERY_LONG, WeaponHandedness.ONE, WeaponSize.HUGE),
            new Weapon(1, 10, 5, 15, 2, 140, 125, WeaponType.MACE, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(0, 0, 0, 0, 1, 0, 25, WeaponType.NET, WeaponReach.LONG, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(1, 5, 0, 2, 1, 50, 100, WeaponType.PARRYING_DAGGER, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(1, 10, 0, 5, 0, 75, 50, WeaponType.PUNCH_DAGGER, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(2, 10, 1, 5, 1, 140, 125, WeaponType.RAPIER, WeaponReach.LONG, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(2, 10, 2, 2, 1, 150, 200, WeaponType.SABRE, WeaponReach.MEDIUM, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(2, 10, 3, 2, 2, 160, 225, WeaponType.SCIMITAR, WeaponReach.MEDIUM, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(2, 10, 3, 10, 2, 140, 70, WeaponType.SHORTSPEAR, WeaponReach.LONG, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(1, 10, 5, 5, 1, 125, 125, WeaponType.SHORTSWORD, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(1, 10, 2, 2, 1, 100, 75, WeaponType.TANTO, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(1, 10, 1, 5, 0, 75, 90, WeaponType.THROWING_DAGGER, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.SMALL),
            new Weapon(2, 10, 1, 10, 2, 150, 160, WeaponType.TRIDENT, WeaponReach.LONG, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(1, 10, 5, 2, 1, 125, 130, WeaponType.WAKIZASHI, WeaponReach.SHORT, WeaponHandedness.ONE, WeaponSize.MEDIUM),
            new Weapon(2, 10, 3, 10, 2, 150, 175, WeaponType.WAR_AXE, WeaponReach.MEDIUM, WeaponHandedness.ONE, WeaponSize.MEDIUM)
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
