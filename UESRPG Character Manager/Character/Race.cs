using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager
{
    public class Race
    {
        public enum RaceName
        {
            IMPERIAL,
            ORC,
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
                _raceList = new Race[(int)RaceName.MAX];
            }
        }

        public int Strength
        {
            get; set;
        }
        public int Endurance
        {
            get; set;
        }
        public int Agility
        {
            get; set;
        }
        public int Intelligence
        {
            get; set;
        }
        public int Willpower
        {
            get; set;
        }
        public int Perception
        {
            get; set;
        }
        public int Personality
        {
            get; set;
        }
        public int Luck
        {
            get; set;
        }
    }
}
