using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager
{
    static class Characteristics
    {
        public const int Strength = 0;
        public const int Endurance = 1;
        public const int Agility = 2;
        public const int Intelligence = 3;
        public const int Willpower = 4;
        public const int Perception = 5;
        public const int Personality = 6;
        public const int Luck = 7;
        public const int NumberOfCharacteristics = 8;
        public static string[] CharacteristicNames = { "Strength", "Endurance", "Agility", "Intelligence",
                                                       "Willpower", "Perception", "Personality", "Luck"};
    }
}
