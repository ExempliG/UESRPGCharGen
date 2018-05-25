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
            MAX
        }

        private static Race[] _raceList;
        private static bool _racesInitialized = false;

        public static Race[] RaceList
        {
            get
            {
                if (!_racesInitialized)
                {
                    InitRaces ();
                }
                return _raceList;
            }
        }

        public static void InitRaces ()
        {
            if (!_racesInitialized)
            {
                _raceList = new Race[(int)RaceId.MAX];

            }
        }

        private int[] _characteristics;

        public Race()
        {
            _characteristics = new int[Characteristics.MAX];
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
    }
}
