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
        RIGHT_LEG,
        MAX
    }
    public static class ArmorLocationsData
    {

        public static string[] s_names =
        {
            "Head",
            "Left Arm",
            "Right Arm",
            "Body",
            "Left Leg",
            "Right Leg"
        };
    }

    public enum ArmorQualities
    {
        TERRIBLE = 0,
        POOR,
        COMMON,
        EXPENSIVE,
        EXTRAVAGANT,
        EXQUISITE
    }

    public static class ArmorQualityData
    {
        public static string[] s_names =
        {
            "Terrible",
            "Poor", 
            "Common",
            "Expensive",
            "Extravagant",
            "Exquisite"
        };

        public static double[] s_modifiers =
        {
            -.20,
            -.10,
            0,
            .10,
            .15,
            .20
        };
    }

    public enum ArmorTypes
    {
        NATURAL_CURRED = 0,
        PADDED_QUILTED,
        RINGMAIL,
        SCALED,
        PARTIAL_PLATE,
        MAIL,
        PLATED_MAIL,
        FULL_PLATE
    }

    public static class ArmorTypeData
    {
        public static string[] s_names =
        {
            "Natural/Cured",
            "Padded/Quilted",
            "Ringmail",
            "Scaled",
            "Partial Plate",
            "Mail",
            "Plated Mail",
            "Full Plate"
        };

        public static double[] s_modifiers =
        {
            8,
            12,
            15,
            18,
            20,
            23,
            25,
            30
        };
    }

    public enum ArmorMaterials
    {
        ADAMANTIUM = 0,
        BONE,
        BONEMOLD,
        CHITIN,
        DAEDRIC,
        DRAGONBONE,
        DREUGH_HIDE,
        DWEMER,
        EBONY,
        FUR,
        IRON,
        LEATHER,
        MALACHITE,
        MOONSTONE,
        ORICHALCUM,
        STALHRIM,
        STEEL
    }

    public static class ArmorMaterialData
    {
        public static string[] s_names =
        {
            "Adamantium",
            "Bone",
            "Bonemold",
            "Chitin",
            "Daedric",
            "Dragonbone",
            "Dreugh Hide",
            "Dwemer",
            "Ebony",
            "Fur",
            "Iron",
            "Leather",
            "Malachite",
            "Moonstone",
            "Orichalcum",
            "Stalhrim",
            "Steel"
        };

        public static double[] s_modifiers =
        {
            6,
            -10,
            -2,
            -6,
            15,
            12,
            10,
            4,
            10,
            0,
            -3,
            0,
            7,
            3,
            5,
            8,
            0
        };
    }
}
