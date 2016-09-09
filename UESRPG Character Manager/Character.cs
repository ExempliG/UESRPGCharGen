using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace UESRPG_Character_Manager
{
    class Character
    {
        public Dictionary<string, int> Characteristics;

        public Character ()
        {
            Characteristics = new Dictionary<string, int> ();
            Characteristics.Add ("Strength", 0);
            Characteristics.Add ("Endurance", 0);
            Characteristics.Add ("Agility", 0);
            Characteristics.Add ("Intelligence", 0);
            Characteristics.Add ("Willpower", 0);
            Characteristics.Add ("Perception", 0);
            Characteristics.Add ("Personality", 0);
            Characteristics.Add ("Luck", 0);
        }

        public int GetBonus (int attribute)
        {
            return attribute / 10;
        }

        public int Strength
        {
            get { return Characteristics["Strength"]; }
            set { Characteristics["Strength"] = value; }
        }
        public int Endurance
        {
            get { return Characteristics["Endurance"]; }
            set { Characteristics["Endurance"] = value; }
        }
        public int Agility
        {
            get { return Characteristics["Agility"]; }
            set { Characteristics["Agility"] = value; }
        }
        public int Intelligence
        {
            get { return Characteristics["Intelligence"]; }
            set { Characteristics["Intelligence"] = value; }
        }
        public int Willpower
        {
            get { return Characteristics["Willpower"]; }
            set { Characteristics["Willpower"] = value; }
        }
        public int Perception
        {
            get { return Characteristics["Perception"]; }
            set { Characteristics["Perception"] = value; }
        }
        public int Personality
        {
            get { return Characteristics["Personality"]; }
            set { Characteristics["Personality"] = value; }
        }
        public int Luck
        {
            get { return Characteristics["Luck"]; }
            set { Characteristics["Luck"] = value; }
        }

        public int MaxHealth
        {
            get
            {
                return Endurance;
            }
        }

        public int WoundThreshold
        {
            get
            {
                return GetBonus (Endurance) + GetBonus (Strength);
            }
        }

        public int Stamina
        {
            get
            {
                float halfWillpowerBonus = (float)GetBonus (Willpower) / 2;
                halfWillpowerBonus += 0.5f; // round up
                return GetBonus (Endurance) + (int)halfWillpowerBonus;
            }
        }

        public int MagickaPool
        {
            get
            {
                return Intelligence;
            }
        }

        public int MovementRating
        {
            get
            {
                return GetBonus (Agility);
            }
        }

        public int CarryRating
        {
            get
            {
                return (2 * GetBonus (Strength)) + GetBonus (Endurance);
            }
        }

        public int InitiativeRating
        {
            get
            {
                return GetBonus (Agility) + GetBonus (Perception);
            }
        }

        public int MaximumAp
        {
            get
            {
                int value = GetBonus (Agility) + GetBonus (Intelligence) + GetBonus (Perception);
                if (value <= 6)
                {
                    return 1;
                }
                else if (value >= 7 && value <= 10)
                {
                    return 2;
                }
                else if (value >= 11 && value <= 14)
                {
                    return 3;
                }
                else if (value >= 15 && value <= 18)
                {

                    return 4;
                }
                else // 19+
                {
                    return 5;
                }
            }
        }

        public int DamageBonus
        {
            get
            {
                return GetBonus (Strength);
            }
        }

        public int MaximumLuckPoints
        {
            get
            {
                return GetBonus (Luck);
            }
        }
    }
}
