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

        public static string GetName( ArmorLocations location )
        {
            return s_names[(int)location];
        }

        private static string[] s_pieceNames =
        {
            "Helm",
            "Left Gauntlet",
            "Right Gauntlet",
            "Hauberk",
            "Left Boot",
            "Right Boot"
        };

        public static string GetPieceName( ArmorLocations location )
        {
            return s_pieceNames[(int)location];
        }
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

        public static string GetName( ArmorQualities quality )
        {
            return s_names[(int)quality];
        }

        private static double[] s_arModifiers =
        {
            -.20,
            -.10,
            0,
            .10,
            .15,
            .20
        };

        public static double GetArModifier( ArmorQualities quality )
        {
            return s_arModifiers[(int)quality];
        }

        // Note: These encumbrance modifiers are different from the book.
        // The book specifies a price percentage to add, whereas these
        // are multiplicative percentages. This is for ease of use at the
        // expense of some readability.
        private static float[] s_encumbranceModifiers =
        {
            1.10f, // Terrible
            1.00f, // Poor
            1.00f, // Common
            1.00f, // Expensive
            0.90f, // Extravagant
            0.85f, // Exquisite
        };

        public static float GetEncumbranceModifier( ArmorQualities quality )
        {
            return s_encumbranceModifiers[(int)quality];
        }

        // Note: These price modifiers are different from the book.
        // The book specifies a price percentage to add, whereas these
        // are multiplicative percentages. This is for ease of use at the
        // expense of some readability.
        private static double[] s_priceModifiers =
        {
            0.50, // Terrible
            0.75, // Poor
            1.00, // Common
            1.50, // Expensive
            2.00, // Extravagant
            3.00  // Exquisite
        };

        public static double GetPriceModifier( ArmorQualities quality )
        {
            return s_priceModifiers[(int)quality];
        }
    }

    public enum ArmorTypes
    {
        NATURAL_CURED = 0,
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

        public static string GetName( ArmorTypes type )
        {
            return s_names[(int)type];
        }

        private static int[][] s_encumbranceModifiers =
        {
            //          H LA RA   B LL RL
            new int[] { 1, 2, 2,  3, 2, 2 }, // Natural/Cured
            new int[] { 1, 1, 1,  3, 1, 1 }, // Padded/Quilted
            new int[] { 1, 2, 2,  5, 2, 2 }, // Ringmail
            new int[] { 2, 3, 3,  6, 4, 4 }, // Scaled
            new int[] { 2, 4, 4,  7, 5, 5 }, // Partial Plate
            new int[] { 3, 5, 5,  7, 5, 5 }, // Mail
            new int[] { 4, 6, 6, 10, 7, 7 }, // Plated Mail
            new int[] { 6, 7, 7, 12, 8, 8 }, // Full Plate
        };

        public static int GetEncumbranceModifier( ArmorTypes type, ArmorLocations location )
        {
            return s_encumbranceModifiers[(int)type][(int)location];
        }

        private static int[][] s_elModifiers =
        {
            //            H   LA   RA    B   LL   RL
            new int[] {  75, 100, 100, 150, 100, 100 }, // Natural/Cured
            new int[] {  75, 100, 100, 150, 100, 100 }, // Padded/Quilted
            new int[] {  75, 100, 100, 150, 100, 100 }, // Ringmail
            new int[] {  75, 100, 100, 150, 100, 100 }, // Scaled
            new int[] { 100, 125, 125, 175, 125, 125 }, // Partial Plate
            new int[] { 125, 150, 150, 200, 150, 150 }, // Mail
            new int[] { 150, 175, 175, 225, 175, 175 }, // Plated Mail
            new int[] { 175, 200, 200, 250, 200, 200 }, // Full Plate
        };

        public static int GetElModifier( ArmorTypes type, ArmorLocations location )
        {
            return s_elModifiers[(int)type][(int)location];
        }

        private static double[] s_arModifiers =
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

        public static double GetArModifier( ArmorTypes type )
        {
            return s_arModifiers[(int)type];
        }

        private static int[] s_priceModifiers =
        {
            40,
            80,
            125,
            200,
            300,
            400,
            500,
            800
        };

        public static int GetPriceModifier( ArmorTypes type )
        {
            return s_priceModifiers[(int)type];
        }
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

        public static string GetName( ArmorMaterials material )
        {
            return s_names[(int)material];
        }

        private static double[] s_arModifiers =
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

        public static double GetArModifier( ArmorMaterials material )
        {
            return s_arModifiers[(int)material];
        }

        private static float[] s_encumbranceModifiers =
        {
            0.9f,
            1.3f,
            0.9f,
            0.6f,
            1.6f,
            1.6f,
            1.5f,
            1.3f,
            1.5f,
            1.4f,
            1.5f,
            1.0f,
            0.6f,
            0.8f,
            1.2f,
            1.2f,
            1.0f
        };

        public static float GetEncumbranceModifier( ArmorMaterials material )
        {
            return s_encumbranceModifiers[(int)material];
        }

        private static double[] s_elModifiers =
        {
            7.0,
            1.0,
            2.0,
            1.0,
            10.0,
            9.0,
            3.0,
            4.0,
            9.0,
            1.0,
            2.0,
            3.0,
            6.0,
            5.0,
            4.0,
            8.0,
            3.0
        };

        public static double GetElModifier( ArmorMaterials material )
        {
            return s_elModifiers[(int)material];
        }

        private static double[] s_priceModifiers =
        {
            7.0,
            0.2,
            0.9,
            0.7,
            20.0,
            50.0,
            6.0,
            5.0,
            10.0,
            1.0,
            0.7,
            1.5,
            8.0,
            6.0,
            4.0,
            9.0,
            1.0
        };

        public static double GetPriceModifier( ArmorMaterials material )
        {
            return s_priceModifiers[(int)material];
        }
    }
}
