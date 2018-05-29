using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.CharacterComponents
{
    static class Races
    {
        private static Race[] _raceList;
        private static bool _racesInitialized = false;

        public static Race[] RaceList
        {
            get
            {
                if (!_racesInitialized)
                {
                    InitRaces();
                }
                return _raceList;
            }
        }

        public static void InitRaces()
        {
            if (!_racesInitialized)
            {
                _raceList = new Race[(int)Race.RaceId.NUMBER_OF_RACES];

            }
        }
    }
}
