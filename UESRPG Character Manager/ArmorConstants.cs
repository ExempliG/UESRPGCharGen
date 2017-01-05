using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager
{
  public enum ArmorLocations
  {
    HEAD = 0,
    LEFT_ARM,
    RIGHT_ARM,
    BODY,
    LEFT_LEG,
    RIGHT_LEG
  }
  public static class ArmorLocationsData
  {

    public static string[] Names =
    {
      "Head",
      "Left Arm",
      "Right Arm",
      "Body",
      "Left Leg",
      "Right Leg"
    };
  }

  public enum ArmorQualitys
  {
     TERRIBLE = 0,
     POOR
  }

  public static class ArmorQualityData
  {
    public static string[] Names =
    {
      "Terrible",
      "Poor"
    };

    public static double[] Modifiers =
    {
      -.20,
      -.10
    };
  }

  public enum ArmorTypes
  {
    NATURAL_CURRED = 0,
    PADDED_QUILTED
  }

  public static class ArmorTypeData
  {
    public static string[] Names =
    {
      "Natural/Cured",
      "Padded/Quilted"
    };

    public static double[] Modifiers =
    {
      8,
      12
    };
  }

  public enum ArmorMaterials
  {
    ADAMANTIUM = 0,
    BONE
  }

  public static class ArmorMaterialData
  {
    public static string[] Names =
    {
      "Adamantium",
      "Bone"
    };

    public static double[] Modifiers =
    {
       6,
       -10
    };
  }
}
