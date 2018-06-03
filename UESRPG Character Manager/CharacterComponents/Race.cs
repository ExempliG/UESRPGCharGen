using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public enum RaceId
    {
        NA,
        ALTMER,
        ARGONIAN,
        BOSMER,
        BRETON,
        DUNMER,
        IMPERIAL,
        KHAJIIT,
        NORD,
        ORSIMER,
        REDGUARD,
        NUMBER_OF_RACES
    }

    public class Race
    {
        private int[] _characteristics;
        private List<Trait> _traits;
        private List<Power> _powers;

        public Race(int[] characteristics, List<Trait> traits, List<Power> powers)
        {
            if( characteristics.Length != Characteristics.NUMBER_OF_CHARACTERISTICS )
            {
                throw new ArgumentOutOfRangeException("characteristics.Length", characteristics.Length, "you stink");
            }
            _characteristics = characteristics;

            _traits = traits;
            _powers = powers;
        }

        /******************
         * CHARACTERISTICS
         *****************/
        public int Strength
        {
            get { return _characteristics[Characteristics.STRENGTH]; }
        }

        public int Endurance
        {
            get { return _characteristics[Characteristics.ENDURANCE]; }
        }

        public int Agility
        {
            get { return _characteristics[Characteristics.AGILITY]; }
        }

        public int Intelligence
        {
            get { return _characteristics[Characteristics.INTELLIGENCE]; }
        }

        public int Willpower
        {
            get { return _characteristics[Characteristics.WILLPOWER]; }
        }

        public int Perception
        {
            get { return _characteristics[Characteristics.PERCEPTION]; }
        }

        public int Personality
        {
            get { return _characteristics[Characteristics.PERSONALITY]; }
        }

        public int Luck
        {
            get { return _characteristics[Characteristics.LUCK]; }
        }

        public List<Trait> Traits
        {
            get         { return _traits; }
            private set { _traits = value; }
        }

        public List<Power> Powers
        {
            get         { return _powers; }
            private set { _powers = value; }
        }
    }
}
