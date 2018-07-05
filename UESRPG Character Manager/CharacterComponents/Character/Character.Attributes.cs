namespace UESRPG_Character_Manager.CharacterComponents
{
    partial class Character
    {
        public void SetModifier(int modifierIndex, int value)
        {
            if (modifierIndex >= 0 && modifierIndex < Modifiers.NUMBER_OF_MODIFIERS)
            {
                _modifiers[modifierIndex] = value;
                // As modifiers modify attributes, changing a modifier subsequently changes an attribute.
                onAttributeChanged();
            }
        }

        public int HealthMod
        {
            get { return _modifiers[Modifiers.HEALTH]; }
        }
        public int WoundThresholdMod
        {
            get { return _modifiers[Modifiers.WOUND_THRESHOLD]; }
        }
        public int StaminaMod
        {
            get { return _modifiers[Modifiers.STAMINA]; }
        }
        public int MagickaMod
        {
            get { return _modifiers[Modifiers.MAGICKA]; }
        }
        public int ActionPointsMod
        {
            get { return _modifiers[Modifiers.ACTION_POINTS]; }
        }
        public int MovementRatingMod
        {
            get { return _modifiers[Modifiers.MOVEMENT_RATING]; }
        }
        public int CarryRatingMod
        {
            get { return _modifiers[Modifiers.CARRY_RATING]; }
        }
        public int InitiativeRatingMod
        {
            get { return _modifiers[Modifiers.INITIATIVE_RATING]; }
        }
        public int DamageBonusMod
        {
            get { return _modifiers[Modifiers.DAMAGE_BONUS]; }
        }
        public int LuckPointsMod
        {
            get { return _modifiers[Modifiers.LUCK_POINTS]; }
        }

        private int _currentHealth;
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
                onAttributeChanged();
            }
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
                return (GetBonus(Endurance) + GetBonus(Strength)) + WoundThresholdMod;
            }
        }

        private int _currentStamina;
        public int CurrentStamina
        {
            get { return _currentStamina; }
            set
            {
                _currentStamina = value;
                onAttributeChanged();
            }
        }

        public int Stamina
        {
            get
            {
                float halfWillpowerBonus = (float)GetBonus(Willpower) / 2;
                halfWillpowerBonus += 0.5f; // round up
                return (GetBonus(Endurance) + (int)halfWillpowerBonus) + StaminaMod;
            }
        }

        private int _currentMagicka;
        public int CurrentMagicka
        {
            get { return _currentMagicka; }
            set
            {
                _currentMagicka = value;
                onAttributeChanged();
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
                return GetBonus(Agility) + MovementRatingMod;
            }
        }

        public int CarryRating
        {
            get
            {
                return ((2 * GetBonus(Strength)) + GetBonus(Endurance)) + CarryRatingMod;
            }
        }

        public uint Initiative { get; set; }

        public int InitiativeRating
        {
            get
            {
                return (GetBonus(Agility) + GetBonus(Perception)) + InitiativeRatingMod;
            }
        }

        private int _currentAp;
        public int CurrentAp
        {
            get { return _currentAp; }
            set
            {
                _currentAp = value;
                onAttributeChanged();
            }
        }

        public int MaximumAp
        {
            get
            {
                int value = GetBonus(Agility) + GetBonus(Intelligence) + GetBonus(Perception);
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
                return GetBonus(Strength) + DamageBonusMod;
            }
        }

        private int _currentLuckPoints;
        public int CurrentLuckPoints
        {
            get { return _currentLuckPoints; }
            set
            {
                _currentLuckPoints = value;
                onAttributeChanged();
            }
        }

        public int MaximumLuckPoints
        {
            get
            {
                return GetBonus(Luck) + LuckPointsMod;
            }
        }
    }
}
