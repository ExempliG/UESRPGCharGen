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
        public Dictionary<string, int> _characteristics;
        public Dictionary<string, int> _modifiers;

        public Character ()
        {
            _characteristics = new Dictionary<string, int> ();
            _characteristics.Add ("Strength", 0);
            _characteristics.Add ("Endurance", 0);
            _characteristics.Add ("Agility", 0);
            _characteristics.Add ("Intelligence", 0);
            _characteristics.Add ("Willpower", 0);
            _characteristics.Add ("Perception", 0);
            _characteristics.Add ("Personality", 0);
            _characteristics.Add ("Luck", 0);

            _modifiers = new Dictionary<string, int> ();
            _modifiers.Add ("Health", 0);
            _modifiers.Add ("WoundThreshold", 0);
            _modifiers.Add ("Stamina", 0);
            _modifiers.Add ("Magicka", 0);
            _modifiers.Add ("ActionPoints", 0);
            _modifiers.Add ("MovementRating", 0);
            _modifiers.Add ("CarryRating", 0);
            _modifiers.Add ("InitiativeRating", 0);
            _modifiers.Add ("DamageBonus", 0);
            _modifiers.Add ("LuckPoints", 0);
        }

        public int GetBonus (int attribute)
        {
            return attribute / 10;
        }


/******************
 * CHARACTERISTICS
 *****************/
        public int Strength
        {
            get { return _characteristics["Strength"]; }
            set { _characteristics["Strength"] = value; }
        }
        public int Endurance
        {
            get { return _characteristics["Endurance"]; }
            set { _characteristics["Endurance"] = value; }
        }
        public int Agility
        {
            get { return _characteristics["Agility"]; }
            set { _characteristics["Agility"] = value; }
        }
        public int Intelligence
        {
            get { return _characteristics["Intelligence"]; }
            set { _characteristics["Intelligence"] = value; }
        }
        public int Willpower
        {
            get { return _characteristics["Willpower"]; }
            set { _characteristics["Willpower"] = value; }
        }
        public int Perception
        {
            get { return _characteristics["Perception"]; }
            set { _characteristics["Perception"] = value; }
        }
        public int Personality
        {
            get { return _characteristics["Personality"]; }
            set { _characteristics["Personality"] = value; }
        }
        public int Luck
        {
            get { return _characteristics["Luck"]; }
            set { _characteristics["Luck"] = value; }
        }

/************
 * MODIFIERS
 ***********/
        public int HealthMod
        {
            get { return _modifiers["Health"]; }
            set { _modifiers["Heatlh"] = value; }
        }
        public int WoundThresholdMod
        {
            get { return _modifiers["WoundThreshold"]; }
            set { _modifiers["WoundThreshold"] = value; }
        }
        public int StaminaMod
        {
            get { return _modifiers["Stamina"]; }
            set { _modifiers["Stamina"] = value; }
        }
        public int MagickaMod
        {
            get { return _modifiers["Magicka"]; }
            set { _modifiers["Magicka"] = value; }
        }
        public int ActionPointsMod
        {
            get { return _modifiers["ActionPoints"]; }
            set { _modifiers["ActionPoints"] = value; }
        }
        public int MovementRatingMod
        {
            get { return _modifiers["MovementRating"]; }
            set { _modifiers["MovementRating"] = value; }
        }
        public int CarryRatingMod
        {
            get { return _modifiers["CarryRating"]; }
            set { _modifiers["CarryRating"] = value; }
        }
        public int InitiativeRatingMod
        {
            get { return _modifiers["InitiativeRating"]; }
            set { _modifiers["InitiativeRating"] = value; }
        }
        public int DamageBonusMod
        {
            get { return _modifiers["DamageBonus"]; }
            set { _modifiers["DamageBonus"] = value; }
        }
        public int LuckPointsMod
        {
            get { return _modifiers["LuckPoints"]; }
            set { _modifiers["LuckPoints"] = value; }
        }

        public int MaxHealth
        {
            get
            {
                return Endurance + HealthMod;
            }
        }

        public int WoundThreshold
        {
            get
            {
                return (GetBonus (Endurance) + GetBonus (Strength)) + WoundThresholdMod;
            }
        }

        public int Stamina
        {
            get
            {
                float halfWillpowerBonus = (float)GetBonus (Willpower) / 2;
                halfWillpowerBonus += 0.5f; // round up
                return (GetBonus (Endurance) + (int)halfWillpowerBonus) + StaminaMod;
            }
        }

        public int MagickaPool
        {
            get
            {
                return Intelligence + MagickaMod;
            }
        }

        public int MovementRating
        {
            get
            {
                return GetBonus (Agility) + MovementRatingMod;
            }
        }

        public int CarryRating
        {
            get
            {
                return ((2 * GetBonus (Strength)) + GetBonus (Endurance)) + CarryRatingMod;
            }
        }

        public int InitiativeRating
        {
            get
            {
                return (GetBonus (Agility) + GetBonus (Perception)) + InitiativeRatingMod;
            }
        }

        public int MaximumAp
        {
            get
            {
                int value = GetBonus (Agility) + GetBonus (Intelligence) + GetBonus (Perception);
                int ap = 0;
                if (value <= 6)
                {
                    ap = 1;
                }
                else if (value >= 7 && value <= 10)
                {
                    ap = 2;
                }
                else if (value >= 11 && value <= 14)
                {
                    ap = 3;
                }
                else if (value >= 15 && value <= 18)
                {

                    ap = 4;
                }
                else // 19+
                {
                    ap = 5;
                }

                return ap + ActionPointsMod;
            }
        }

        public int DamageBonus
        {
            get
            {
                return GetBonus (Strength) + DamageBonusMod;
            }
        }

        public int MaximumLuckPoints
        {
            get
            {
                return GetBonus (Luck) + LuckPointsMod;
            }
        }
    }
}
