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

        public static Race GetRace(int index)
        {
            return RaceList[index];
        }

        public static Race GetRace(RaceId id)
        {
            return RaceList[(int)id];
        }

        public static void InitRaces()
        {
            if (!_racesInitialized)
            {
                _raceList = new Race[(int)RaceId.NUMBER_OF_RACES];

                _raceList[(int)RaceId.NA] = new Race(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new List<Trait>(), new List<Power>());

                _raceList[(int)RaceId.ALTMER] = new Race(
                    new int[] { 20, 23, 23, 30, 28, 25, 25, 0 },
                    new List<Trait> {
                        new Trait("Disease Resistance (50%)", true, 0, TraitDescriptions.DiseaseResistance),
                        new Trait("Power Well (100%)", true, 0, TraitDescriptions.PowerWell),
                        new Trait("Weakness (Magic, 50%)", true, 0, TraitDescriptions.Weakness),
                        new Trait("(Racial)Mental Strength", true, 0, TraitDescriptions.RacialMentalStrength) },
                    new List<Power> { });

                _raceList[(int)RaceId.ARGONIAN] = new Race(
                    new int[] { 25, 24, 28, 27, 24, 25, 22, 0 },
                    new List<Trait> {
                        new Trait("Disease Resistance (75%)", true, 0, TraitDescriptions.DiseaseResistance),
                        new Trait("Immunity (Poison)", true, 0, TraitDescriptions.Immunity),
                        new Trait("Amphibious", true, 0, TraitDescriptions.Amphibious),
                        new Trait("(Racial) Inscrutable", true, 0, TraitDescriptions.RacialInscrutable)
                    },
                    new List<Power> { });

                Power beastTongue = new Power("Beast Tongue", PowerDescriptions.BeastTongue);
                _raceList[(int)RaceId.BOSMER] = new Race(
                    new int[] { 21, 21, 31, 25, 23, 26, 24, 0 },
                    new List<Trait> {
                        new Trait("Disease Resistance (50%)", true, 0, TraitDescriptions.DiseaseResistance),
                        new Trait("Resistance (Poison, 25%)", true, 0, TraitDescriptions.Resistance),
                        new Trait("(Racial) Natural Archers", true, 0, TraitDescriptions.RacialNaturalArchers) 
                    },
                    new List<Power> { beastTongue });

                _raceList[(int)RaceId.BRETON] = new Race(
                    new int[] { 23, 21, 22, 28, 30, 25, 25, 0 },
                    new List<Trait> {
                        new Trait("Resistance (Magic, 50%)", true, 0, TraitDescriptions.Resistance),
                        new Trait("Power Well (50%)", true, 0, TraitDescriptions.PowerWell) 
                    },
                    new List<Power> { });

                Power ancestorGuardian = new Power("Ancestor Guardian", PowerDescriptions.AncestorGuardian);
                _raceList[(int)RaceId.DUNMER] = new Race(
                    new int[] { 25, 24, 29, 25, 24, 25, 23, 0 },
                    new List<Trait> {
                        new Trait("Resistance (Fire, 75%)", true, 0, TraitDescriptions.Resistance) 
                    },
                    new List<Power> { ancestorGuardian });

                Power voiceOfTheEmperor = new Power("Voice of the Emperor", PowerDescriptions.VoiceOfTheEmperor);
                _raceList[(int)RaceId.IMPERIAL] = new Race(
                    new int[] { 24, 23, 23, 27, 23, 25, 28, 0 },
                    new List<Trait> {
                        new Trait("(Racial) Star of the West", true, 0, TraitDescriptions.RacialStarOfTheWest) 
                    },
                    new List<Power> { voiceOfTheEmperor });

                _raceList[(int)RaceId.KHAJIIT] = new Race(
                    new int[] { 22, 22, 29, 25, 21, 28, 24, 0 },
                    new List<Trait> {
                        new Trait("Dark Sight", true, 0, TraitDescriptions.DarkSight),
                        new Trait("Natural Weapons (1d10+1 R; Pen 0; S; T; Tearing", true, 0, "") 
                    },
                    new List<Power> { });

                Power warCry = new Power("War Cry", PowerDescriptions.WarCry);
                _raceList[(int)RaceId.NORD] = new Race(
                    new int[] { 30, 28, 23, 21, 24, 25, 23, 0 },
                    new List<Trait> {
                        new Trait("Tough (10%)", true, 0, TraitDescriptions.Tough),
                        new Trait("Heavy Hitter (1)", true, 0, TraitDescriptions.HeavyHitter),
                        new Trait("Resistance (Frost, 50%)", true, 0, TraitDescriptions.Resistance),
                        new Trait("Resistance (Shock, 25%)", true, 0, TraitDescriptions.Resistance) 
                    },
                    new List<Power> { warCry });
            }
        }
    }
}
