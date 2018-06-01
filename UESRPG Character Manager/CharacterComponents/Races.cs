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

                _raceList[(int)Race.RaceId.NA] = new Race(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new string[0], new List<Spell>());

                _raceList[(int)Race.RaceId.ALTMER] = new Race(
                    new int[] { 20, 23, 23, 30, 28, 25, 25, 0 },
                    new string[] { "Disease Resistance (50%)", "Power Well (100%)", "Weakness (Magic, 50%)", "(Racial)Mental Strength" },
                    new List<Spell> { });

                _raceList[(int)Race.RaceId.ARGONIAN] = new Race(
                    new int[] { 25, 24, 28, 27, 24, 25, 22, 0 },
                    new string[] { "Disease Resistance (75%)", "Immunity (Poison)", "Amphibious", "(Racial) Inscrutable" },
                    new List<Spell> { });

                Spell beastTongue = new Spell();
                // populate beast tongue
                _raceList[(int)Race.RaceId.BOSMER] = new Race(
                    new int[] { 21, 21, 31, 25, 23, 26, 24, 0 },
                    new string[] { "Disease Resistance (50%)", "Resistance (Poison, 25%)", "(Racial) Natural Archers" },
                    new List<Spell> { beastTongue });

                _raceList[(int)Race.RaceId.BRETON] = new Race(
                    new int[] { 23, 21, 22, 28, 30, 25, 25, 0 },
                    new string[] { "Resistance (Magic, 50%)", "Power Well (50%)" },
                    new List<Spell> { });

                Spell ancestorGuardian = new Spell();
                // populate ancestor guardian
                _raceList[(int)Race.RaceId.DUNMER] = new Race(
                    new int[] { 25, 24, 29, 25, 24, 25, 23, 0 },
                    new string[] { "Resistance (Fire, 75%)" },
                    new List<Spell> { ancestorGuardian });

                Spell voiceOfTheEmperor = new Spell();
                // populate voice of the emperor
                _raceList[(int)Race.RaceId.IMPERIAL] = new Race(
                    new int[] { 24, 23, 23, 27, 23, 25, 28, 0 },
                    new string[] { "(Racial) Star of the West" },
                    new List<Spell> { voiceOfTheEmperor });

                _raceList[(int)Race.RaceId.KHAJIIT] = new Race(
                    new int[] { 22, 22, 29, 25, 21, 28, 24, 0 },
                    new string[] { "Dark Sight", "Natural Weapons (1d10+1 R; Pen 0; S; T; Tearing" },
                    new List<Spell> { });

                Spell warCry = new Spell();
                // populate war cry
                _raceList[(int)Race.RaceId.NORD] = new Race(
                    new int[] { 30, 28, 23, 21, 24, 25, 23, 0 },
                    new string[] { "Tough (10%)", "Heavy Hitter (1)", "Resistance (Frost, 50%)", "Resistance (Shock, 25%)" },
                    new List<Spell> { warCry });
            }
        }
    }
}
