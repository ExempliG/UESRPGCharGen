using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Xml.Serialization;
using System.ComponentModel;

using UESRPG_Character_Manager.Items;

namespace UESRPG_Character_Manager.CharacterComponents
{
    //[XmlRoot("Character", IsNullable = false)]
    public class Character : ICloneable
    {
        private int[] _characteristics;
        private int[] _modifiers;
        private List<Armor> _armorPieces;
        private List<Weapon> _weapons;
        private List<Spell> _spells;
        private List<Skill> _skills;
        private List<Talent> _talents;
        private List<Trait> _traits;
        private List<Trait> _aggregateTraits;
        private List<Power> _powers;
        private List<Power> _aggregatePowers;
        private RaceId _race;
        private string _notes;

        private int _engVersion = 0;
        private int _minorVersion = 0;
        private int _majorVersion = 0;

        private string _name = "Player";

        public static uint NextAvailableId { get; set; }
        [XmlIgnore(), Browsable(false)]
        public uint CharacterId { get; private set; }

        public Character ()
        {
            _characteristics = new int[Characteristics.NUMBER_OF_CHARACTERISTICS];
            _modifiers = new int[Modifiers.NUMBER_OF_MODIFIERS];
            _armorPieces = new List<Armor>();
            _weapons = new List<Weapon> ();
            _spells = new List<Spell> ();
            _skills = new List<Skill> ();
            _talents = new List<Talent>();
            _traits = new List<Trait>();
            _aggregateTraits = new List<Trait>();
            _powers = new List<Power>();
            _aggregatePowers = new List<Power>();
            _modifiers = new int[Modifiers.NUMBER_OF_MODIFIERS];

            // Assign each character a unique ID. This is used to refer to Characters directly.
            CharacterId = NextAvailableId;
            NextAvailableId++;
        }

        private Character (uint characterId) : base()
        {
            CharacterId = characterId;
        }

        public int GetBonus (int characteristic)
        {
            return characteristic / 10;
        }

        [XmlAttribute()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public RaceId RaceId
        {
            get { return _race; }
            set { _race = value; }
        }

        [XmlIgnore()]
        public Race Race
        {
            get { return Races.GetRace(RaceId); }
        }

        [XmlAttribute ()]
        public int EngVersion
        {
            get { return _engVersion; }
            set { _engVersion = value; }
        }

        [XmlAttribute ()]
        public int MinorVersion
        {
            get { return _minorVersion; }
            set { _minorVersion = value; }
        }

        [XmlAttribute ()]
        public int MajorVersion
        {
            get { return _majorVersion; }
            set { _majorVersion = value; }
        }

        public object Clone ()
        {
            Character c = new Character (this.CharacterId);

            c.Name = Name;
            c.Notes = Notes;
            c._characteristics = (int[])_characteristics.Clone ();
            c._modifiers = (int[])_modifiers.Clone ();

            c._armorPieces = new List<Armor> ();
            foreach (Armor piece in _armorPieces)
            {
                Armor newPiece = (Armor)piece.Clone();
                c._armorPieces.Add(newPiece);
            }

            c._weapons = new List<Weapon>();
            foreach (Weapon weapon in _weapons)
            {
                Weapon newWeapon = (Weapon)weapon.Clone();
                c._weapons.Add(newWeapon);
            }

            c._skills = new List<Skill>();
            foreach (Skill s in _skills)
            {
                Skill newSkill = (Skill)s.Clone();
                c._skills.Add(newSkill);
            }

            c._spells = new List<Spell>();
            foreach (Spell s in _spells)
            {
                Spell newSpell = (Spell)s.Clone();
                c._spells.Add(newSpell);
            }

            c._talents = new List<Talent>();
            foreach (Talent t in _talents)
            {
                Talent newTalent = (Talent)t.Clone();
                c._talents.Add(newTalent);
            }

            return c;
        }

<<<<<<< HEAD
        public Character CopyChar()
        {
            Character c = (Character)Clone();
            c.CharacterId = NextAvailableId;
            NextAvailableId++;
            return c;
        }

        /******************
         * EVENTS
         * ***************/
=======
/******************
 * EVENTS
 *****************/
>>>>>>> latest

        public delegate void CharacteristicChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Characteristics is changed by the user.")]
        public static event CharacteristicChangedHandler CharacteristicChanged;

        public delegate void AttributeChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Attributes is changed by the user.")]
        public static event AttributeChangedHandler AttributeChanged;

        public delegate void SkillListChangedHandler(object sender, EventArgs e);
        [Description("Fires when a skill is added, removed, or edited.")]
        public static event SkillListChangedHandler SkillListChanged;

        public delegate void SpellListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the spell list changes via adding or renaming a spell.")]
        public static event SpellListChangedHandler SpellListChanged;

        public delegate void TalentListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the talent list changes via adding, renaming, or deleting a talent.")]
        public static event TalentListChangedHandler TalentListChanged;

        public delegate void TraitListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the trait list changes via adding, renaming, or deleting a trait.")]
        public static event TraitListChangedHandler TraitListChanged;

        public delegate void PowerListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the power list changes via adding, renaming, or deleting a power.")]
        public static event PowerListChangedHandler PowerListChanged;

        public delegate void WeaponsChangedHandler(object sender, EventArgs e);
        [Description("Fires when a Weapon is changed or added by the user.")]
        public static event WeaponsChangedHandler WeaponsChanged;

        protected void onCharacteristicChanged()
        {
            CharacteristicChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onAttributeChanged()
        {
            AttributeChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onSkillListChanged()
        {
            SkillListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onSpellListChanged()
        {
            SpellListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onTalentListChanged()
        {
            TalentListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onTraitListChanged()
        {
            TraitListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onPowerListChanged()
        {
            PowerListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onWeaponsChanged()
        {
            WeaponsChanged?.Invoke(this, new System.EventArgs());
        }

/******************
 * CHARACTERISTICS
 *****************/
        public int Strength
        {
            get { return _characteristics[Characteristics.STRENGTH]; }
            set { _characteristics[Characteristics.STRENGTH] = value; }
        }
        public int Endurance
        {
            get { return _characteristics[Characteristics.ENDURANCE]; }
            set { _characteristics[Characteristics.ENDURANCE] = value; }
        }
        public int Agility
        {
            get { return _characteristics[Characteristics.AGILITY]; }
            set { _characteristics[Characteristics.AGILITY] = value; }
        }
        public int Intelligence
        {
            get { return _characteristics[Characteristics.INTELLIGENCE]; }
            set { _characteristics[Characteristics.INTELLIGENCE] = value; }
        }
        public int Willpower
        {
            get { return _characteristics[Characteristics.WILLPOWER]; }
            set { _characteristics[Characteristics.WILLPOWER] = value; }
        }
        public int Perception
        {
            get { return _characteristics[Characteristics.PERCEPTION]; }
            set { _characteristics[Characteristics.PERCEPTION] = value; }
        }
        public int Personality
        {
            get { return _characteristics[Characteristics.PERSONALITY]; }
            set { _characteristics[Characteristics.PERSONALITY] = value; }
        }
        public int Luck
        {
            get { return _characteristics[Characteristics.LUCK]; }
            set { _characteristics[Characteristics.LUCK] = value; }
        }

        public void SetCharacteristic (int index, int value)
        {
            if (value >= Characteristics.MIN && value <= Characteristics.MAX)
            {
                if (index >= 0 && index < Characteristics.NUMBER_OF_CHARACTERISTICS)
                {
                    _characteristics[index] = value;
                    onCharacteristicChanged();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("index", CharacterExceptionMessages.SetUnsupportedCharacteristicMessage);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("value", CharacterExceptionMessages.CharacteristicValueOutOfRangeMessage);
            }
        }

        public int GetCharacteristic (int index)
        {
            int result = -1;

            if (index >= 0 && index < Characteristics.NUMBER_OF_CHARACTERISTICS)
            {
                result = _characteristics[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Attempted to retrieve an unsupported Characteristic.");
            }

            return result;
        }

/************
 * EQUIPMENT
 ***********/
        public List<Armor> ArmorPieces
        {
            get { return  _armorPieces; }
            set { _armorPieces = value; }
        }

        /// <summary>
        /// Add a piece of armor, replacing any existing piece that belongs to the same body part
        /// </summary>
        /// <param name="piece">An Armor object to equip</param>
        /// <todo>
        /// Make this good (no but really, we should have an inventory
        /// instead of just blasting away Armor pieces)
        /// </todo>
        public void AddArmorPiece(Armor piece)
        {
            bool addNew = true;

            for (int i = 0; i < _armorPieces.Count; i++)
            {
                if (_armorPieces[i].Location == piece.Location)
                {
                    _armorPieces[i] = piece;
                    addNew = false;
                    break;
                }
            }

            if (addNew)
            {
                _armorPieces.Add (piece);
                _armorPieces.Sort ();
            }
        }

        public Armor GetArmorPiece (ArmorLocations location)
        {
            Armor result = new Armor();
            for (int i = 0; i < _armorPieces.Count; i++)
            {
                if (_armorPieces[i].Location == location)
                {
                    result = _armorPieces[i];
                    break;
                }
            }
            return result;
        }

        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public void AddWeapon(Weapon newWeapon)
        {
            Weapons.Add(newWeapon);
            onWeaponsChanged();
        }

        public void EditWeapon(Weapon newWeapon)
        {
            IEnumerable<Weapon> weaponSearch = from Weapon w in Weapons
                                               where w.WeaponId == newWeapon.WeaponId
                                               select w;
            if(weaponSearch.Count() == 1)
            {
                Weapon currentWeapon = weaponSearch.ElementAt(0);
                int weaponIndex = Weapons.IndexOf(currentWeapon);
                Weapons[weaponIndex] = newWeapon;

                onWeaponsChanged();
            }
        }

        public void DeleteWeapon(Weapon weaponToDelete)
        {
            Weapons.Remove(weaponToDelete);

            onWeaponsChanged();
        }

/*********
 * SPELLS
 *********/

        public List<Spell> Spells
        {
            get { return _spells; }
        }

        public void AddSpell(Spell newSpell)
        {
            Spells.Add(newSpell);
            onSpellListChanged();
        }

        public void EditSpell(Spell newSpell)
        {
            IEnumerable<Spell> spellSearch = from Spell s in Spells
                                             where s.SpellId == newSpell.SpellId
                                             select s;
            if (spellSearch.Count() == 1)
            {
                Spell currentSpell = spellSearch.ElementAt(0);
                int spellIndex = Spells.IndexOf(currentSpell);
                Spells[spellIndex] = newSpell;

                onSpellListChanged();
            }
        }

        public void DeleteSpell(Spell spellToDelete)
        {
            Spells.Remove(spellToDelete);

            onSpellListChanged();
        }

/**********
 * TALENTS 
 *********/

        public List<Talent> Talents
        {
            get { return _talents; }
        }

        public void AddTalent(Talent newTalent)
        {
            _talents.Add(newTalent);
        }

        public void EditTalent(Talent newTalent)
        {
            IEnumerable<Talent> talentSearch = from Talent t in _talents
                                               where t.TalentId == newTalent.TalentId
                                               select t;
            if (talentSearch.Count() == 1)
            {
                Talent currentTalent = talentSearch.ElementAt(0);
                int talentIndex = Talents.IndexOf(currentTalent);
                Talents[talentIndex] = newTalent;

                onTalentListChanged();
            }
        }

        public void DeleteTalent(Talent talentToDelete)
        {
            _talents.Remove(talentToDelete);

            onTalentListChanged();
        }

/*********
 * TRAITS
 ********/

        public List<Trait> Traits
        {
            get { return _traits; }
        }

        [XmlIgnore()]
        public List<Trait> AggregateTraits
        {
            get
            {
                _aggregateTraits = new List<Trait>();
                _aggregateTraits.AddRange(Race.Traits);
                _aggregateTraits.AddRange(_traits);
                return _aggregateTraits;
            }
        }

        public void AddTrait(Trait newTrait)
        {
            _traits.Add(newTrait);
        }

        public void EditTrait(Trait newTrait)
        {
            IEnumerable<Trait> traitSearch = from Trait t in _traits
                                             where t.TraitId == newTrait.TraitId
                                             select t;
            if (traitSearch.Count() == 1)
            {
                Trait currentTrait = traitSearch.ElementAt(0);
                int traitIndex = Traits.IndexOf(currentTrait);
                Traits[traitIndex] = newTrait;

                onTraitListChanged();
            }
        }

        public void DeleteTrait(Trait traitToDelete)
        {
            _traits.Remove(traitToDelete);

            onTraitListChanged();
        }

/*********
 * POWERS
 ********/

        public List<Power> Powers
        {
            get { return _powers; }
        }

        [XmlIgnore()]
        public List<Power> AggregatePowers
        {
            get
            {
                _aggregatePowers = new List<Power>();
                _aggregatePowers.AddRange(Race.Powers);
                _aggregatePowers.AddRange(_powers);
                return _aggregatePowers;
            }
        }

        public void AddPower(Power newPower)
        {
            _powers.Add(newPower);
        }

        public void EditPower(Power newPower)
        {
            IEnumerable<Power> powerSearch = from Power p in _powers
                                             where p.PowerId == newPower.PowerId
                                             select p;
            if (powerSearch.Count() == 1)
            {
                Power currentPower = powerSearch.ElementAt(0);
                int powerIndex = Powers.IndexOf(currentPower);
                Powers[powerIndex] = newPower;

                onPowerListChanged();
            }
        }

        public void DeletePower(Power powerToDelete)
        {
            _powers.Remove(powerToDelete);

            onPowerListChanged();
        }

/*********
 * SKILLS
 ********/

        public List<Skill> Skills
        {
            get { return _skills; }
        }

        public void AddSkill(Skill newSkill)
        {
            Skills.Add(newSkill);
            onSkillListChanged();
        }

        public void EditSkill(Skill newSkill)
        {
            IEnumerable<Skill> skillSearch = from Skill s in Skills
                                             where s.SkillId == newSkill.SkillId
                                             select s;
            if (skillSearch.Count() == 1)
            {
                Skill currentSkill = skillSearch.ElementAt(0);
                int skillIndex = Skills.IndexOf(currentSkill);
                updateSpellSkills(currentSkill.Name, newSkill.Name);
                Skills[skillIndex] = newSkill;

                onSkillListChanged();
            }
        }

        public void DeleteSkill(Skill skillToDelete)
        {
            updateSpellSkills(skillToDelete.Name, "Untrained");
            Skills.Remove(skillToDelete);

            onSkillListChanged();
        }

        private void updateSpellSkills(string oldSkillName, string newSkillName)
        {
            IEnumerable<Spell> relatedSpells = from Spell s in Spells
                                               where s.AssociatedSkill.Equals(oldSkillName)
                                               select s;
            foreach (Spell s in relatedSpells)
            {
                s.AssociatedSkill = newSkillName;
            }

            onSpellListChanged();
        }

/************
 * MODIFIERS
 ***********/

        public void SetModifier(int modifierIndex, int value)
        {
            if(modifierIndex >= 0 && modifierIndex < Modifiers.NUMBER_OF_MODIFIERS)
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
                return (GetBonus (Endurance) + GetBonus (Strength)) + WoundThresholdMod;
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
                float halfWillpowerBonus = (float)GetBonus (Willpower) / 2;
                halfWillpowerBonus += 0.5f; // round up
                return (GetBonus (Endurance) + (int)halfWillpowerBonus) + StaminaMod;
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
                return GetBonus (Luck) + LuckPointsMod;
            }
        }

        /// <summary>
        /// Perform necessary updates on a Character object based on its stored version.
        /// </summary>
        public void Update ()
        {
            if (MajorVersion <= 0 && MinorVersion <= 0 && EngVersion < 1)
            {
                // Skills were 1 point too high in version 0.0.0 because I forgot that "Trained" is rank 0.
                // We adjust for that here.
                foreach (Skill s in _skills)
                {
                    s.Rank -= 1;
                }
            }

            // We always want to ensure the presence of an "Untrained" skill for each character on Load.
            IEnumerable<Skill> untrainedSearch = from skill in _skills
                                                 where skill.Name == "Untrained"
                                                 where skill.Rank == -2
                                                 where skill.isDefaultSkill == true
                                                 where skill.Characteristics.Length == Characteristics.NUMBER_OF_CHARACTERISTICS
                                                 select skill;
            if (untrainedSearch.Count() == 0)
            {
                Skill untrainedSkill = new Skill()
                {
                    Name = "Untrained",
                    Rank = -2,
                    isDefaultSkill = true,
                    Characteristics = new int[Characteristics.NUMBER_OF_CHARACTERISTICS]
                };
                for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
                {
                    untrainedSkill.Characteristics[i] = i;
                }
                _skills.Insert(0, untrainedSkill);
            }
        }
    }
}
