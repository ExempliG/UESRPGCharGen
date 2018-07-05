using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using UESRPG_Character_Manager.GameComponents;
using UESRPG_Character_Manager.Items;

namespace UESRPG_Character_Manager.CharacterComponents
{
    //[XmlRoot("Character", IsNullable = false)]
    public partial class Character : ICloneable, ICombatant
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

        private Character (uint characterId) : this()
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

        public string ApString
        {
            get
            {
                return CurrentAp.ToString();
            }
        }

        public void PassTurn()
        {

        }

        public void TakeAction()
        {
            CurrentAp--;
        }

        public void NewRound()
        {
            CurrentAp = MaximumAp;
        }

        public bool CanAct()
        {
            return CurrentAp > 0;
        }

        public object Clone ()
        {
            Character c = new Character(CharacterId)
            {
                Name = Name,
                Notes = Notes,
                _characteristics = (int[])_characteristics.Clone(),
                _modifiers = (int[])_modifiers.Clone(),

                _armorPieces = new List<Armor>()
            };
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

        public Character CopyChar()
        {
            Character c = (Character)Clone();
            c.CharacterId = NextAvailableId;
            NextAvailableId++;
            return c;
        }

        public override string ToString()
        {
            return Name;
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
