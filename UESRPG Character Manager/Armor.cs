using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager
{
  public class Armor
  {
    public string Name { get; set; }
    public double AR { get; set; }
    public int Encumbrance { get; set; }
    public int Price { get; set; }
    public string[] Qualities { get; set; }
    public ArmorLocations Location { get; set; }

    public Armor(string n, double ar, int enc, int pri, ArmorLocations loc, string[] qual)
    {
      Name = n;
      AR = ar;
      Encumbrance = enc;
      Price = pri;
      Qualities = qual;
      Location = loc;
    }

    public static double CalculateAR(ArmorTypes t, ArmorMaterials mat, ArmorQualities q)
    {
      double result = 0;
      result += ArmorTypeData.Modifiers[(int)t];
      result += ArmorMaterialData.Modifiers[(int)mat];
      result += result * ArmorQualityData.Modifiers[(int)q];

      return result;
    }
  }
}
