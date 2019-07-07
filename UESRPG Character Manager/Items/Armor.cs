using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.Items
{
    public class Armor : Item, IComparable, ICloneable
    {
        public double AR { get; set; }
        public double MaxAR { get; set; }
        public ArmorQualities Quality { get; set; }
        public ArmorLocations Location { get; set; }
        public ArmorMaterials Material { get; set; }
        public ArmorTypes Type { get; set; }
        public double EnchantLevel { get; set; }

        public Armor () : base("", "", 0, 0)
        {
            AR = 0.0;
            MaxAR = 0.0;
            Quality = ArmorQualities.TERRIBLE;
            Location = ArmorLocations.MAX;
            _isEquippable = true;
            Classification = ItemClass.ARMOR;
        }

        public Armor( string name,
                      double ar,
                      int encumbrance,
                      int price,
                      ArmorLocations location,
                      ArmorMaterials material,
                      ArmorTypes type,
                      ArmorQualities quality ) :
            base( name, "", encumbrance, price )
        {
            AR = ar;
            MaxAR = AR;
            Type = type;
            Material = material;
            Quality = quality;
            Location = location;
            _isEquippable = true;
            _equipSlots = new List<string> { location.ToString() };
            Classification = ItemClass.ARMOR;
        }

        public Armor( ArmorLocations location, ArmorMaterials material, ArmorTypes type, ArmorQualities quality ) : this()
        {
            Type = type;
            Material = material;
            Quality = quality;
            Location = location;

            double calcAr = 0;
            calcAr += ArmorTypeData.GetArModifier( type );
            calcAr += ArmorMaterialData.GetArModifier( material );
            calcAr += calcAr * ArmorQualityData.GetArModifier( quality );
            AR = calcAr;
            MaxAR = AR;

            double el = ArmorTypeData.GetElModifier( type, location );
            el *= ArmorMaterialData.GetElModifier( material );
            EnchantLevel = el;

            float encumbrance = ArmorTypeData.GetEncumbranceModifier( type, location );
            encumbrance *= ArmorMaterialData.GetEncumbranceModifier( material );
            encumbrance *= ArmorQualityData.GetEncumbranceModifier( quality );
            Encumbrance = encumbrance;

            double price = ArmorTypeData.GetPriceModifier( type );
            price *= ArmorMaterialData.GetPriceModifier( material );
            price *= ArmorQualityData.GetPriceModifier( quality );
            Price = (int)Math.Round( price );

            Name = string.Format( "{0} {1} {2} {3}",
                                  ArmorQualityData.GetName( quality ),
                                  ArmorTypeData.GetName( type ),
                                  ArmorMaterialData.GetName( material ),
                                  ArmorLocationsData.GetPieceName( location ) );
        }

        public int CompareTo (object obj)
        {
            return ((IComparable)Location).CompareTo (((Armor)obj).Location);
        }

        public object Clone()
        {
            Armor newArmor = new Armor();

            newArmor.Name = Name;
            newArmor.Price = Price;
            newArmor.Encumbrance = Encumbrance;
            newArmor.Description = Description;
            newArmor.AR = AR;
            newArmor.Quality = Quality;
            newArmor.Location = Location;

            return newArmor;
        }
    }
}
