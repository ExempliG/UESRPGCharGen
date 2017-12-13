using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.CharacterComponents
{
    /// <summary>
    /// Holds constant data about Characteristics
    /// </summary>
    public static class Characteristics
    {
        public const int STRENGTH = 0;
        public const int ENDURANCE = 1;
        public const int AGILITY = 2;
        public const int INTELLIGENCE = 3;
        public const int WILLPOWER = 4;
        public const int PERCEPTION = 5;
        public const int PERSONALITY = 6;
        public const int LUCK = 7;
        public const int NUMBER_OF_CHARACTERISTICS = 8;
        public static string[] s_characteristicNames = { "Strength", "Endurance", "Agility", "Intelligence",
                                                       "Willpower", "Perception", "Personality", "Luck"};
    }
}
