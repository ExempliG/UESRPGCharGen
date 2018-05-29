using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public class Race
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

        private int[] _characteristics;
        private string[] _talents;

        public Race()
        {
            _characteristics = new int[Characteristics.NUMBER_OF_CHARACTERISTICS];
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

        public string GetTalent(int index)
        {
            if ( index < 0 || index > _talents.Length )
            {
                throw new IndexOutOfRangeException( CharacterExceptionMessages.GetRacialTalentOutOfRangeMessage );
            }
            else
            {
                return _talents[index];
            }
        }

        public int GetTalentsLength()
        {
            return _talents.Length;
        }
    }
}
