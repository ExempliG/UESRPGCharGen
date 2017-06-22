using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager
{
    public class Armor : IComparable
    {
        public string Name { get; set; }
        public double AR { get; set; }
        public int Encumbrance { get; set; }
        public int Price { get; set; }
        public string[] Qualities { get; set; }
        public ArmorLocations Location { get; set; }

        public Armor ()
        {
            Name = "";
            AR = 0.0;
            Encumbrance = 0;
            Price = 0;
            Qualities = new string[] { };
            Location = ArmorLocations.MAX;
        }

        public Armor(string name, double ar, int encumbrance, int price, ArmorLocations location, string[] qualities)
        {
            Name = name;
            AR = ar;
            Encumbrance = encumbrance;
            Price = price;
            Qualities = qualities;
            Location = location;
        }

        /// <todo>
        /// This could use some work. I dispute the notion that an Armor's material should not be a member variable,
        /// calling into question the need for this method.
        /// </todo>
        public static double CalculateAR(ArmorTypes type, ArmorMaterials material, ArmorQualities quality)
        {
            double result = 0;
            result += ArmorTypeData.Modifiers[(int)type];
            result += ArmorMaterialData.Modifiers[(int)material];
            result += result * ArmorQualityData.Modifiers[(int)quality];

            return result;
        }

        public int CompareTo (object obj)
        {
            return ((IComparable)Location).CompareTo (((Armor)obj).Location);
        }
    }
}
