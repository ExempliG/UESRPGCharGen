using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.Test
{
    [TestClass]
    public class RaceTesting
    {
        [TestMethod]
        public void NewRace_ValidCharacteristics()
        {
            try
            {
                Race testRace = new Race(new int[Characteristics.NUMBER_OF_CHARACTERISTICS], new List<Trait>(), new List<Power>());
            }
            catch( ArgumentOutOfRangeException )
            {
                Assert.Fail("Valid number of Characteristics resulted in exception.");
            }
        }

        [TestMethod]
        public void NewRace_InvalidCharacteristics()
        {
            try
            {
                Race testRace = new Race(new int[Characteristics.NUMBER_OF_CHARACTERISTICS + 1], new List<Trait>(), new List<Power>());
            }
            catch( ArgumentOutOfRangeException e )
            {
                if (!e.Message.StartsWith(RaceExceptionMessages.IncorrectCharacteristicsCount))
                {
                    Assert.Fail("Invalid number of Characteristics resulted in wrong exception.");
                }
                else
                {
                    return;
                }
            }
            Assert.Fail("Invalid number of Characteristics resulted in no exception.");
        }

        [TestMethod]
        public void Get_Characteristics()
        {
            int[] characteristics = new int[Characteristics.NUMBER_OF_CHARACTERISTICS];
            for( int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++ )
            {
                characteristics[i] = i;
            }

            Race testRace = new Race(characteristics, new List<Trait>(), new List<Power>());

            Assert.AreEqual(testRace.Strength, characteristics[0]);
            Assert.AreEqual(testRace.Endurance, characteristics[1]);
            Assert.AreEqual(testRace.Agility, characteristics[2]);
            Assert.AreEqual(testRace.Intelligence, characteristics[3]);
            Assert.AreEqual(testRace.Willpower, characteristics[4]);
            Assert.AreEqual(testRace.Perception, characteristics[5]);
            Assert.AreEqual(testRace.Personality, characteristics[6]);
            Assert.AreEqual(testRace.Luck, characteristics[7]);
        }

        [TestMethod]
        public void Races_Init()
        {
            try
            {
                Races.InitRaces();
            }
            catch( ArgumentOutOfRangeException )
            {
                Assert.Fail("Exception in InitRaces.");
            }
        }

        [TestMethod]
        public void GetRace_Invalid()
        {
            int[] invalidRaceIndices = new int[] { -1, (int)RaceId.NUMBER_OF_RACES + 1, 100 };

            foreach (int index in invalidRaceIndices)
            {
                try
                {
                    Races.GetRace(index);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    if (!e.Message.StartsWith(RaceExceptionMessages.InvalidRaceIndex))
                    {
                        Assert.Fail(string.Format("Incorrect exception message for Invalid Race Index: {0}.", index));
                    }
                    else
                    {
                        continue;
                    }
                }
                Assert.Fail(string.Format("Incorrect/no exception for Invalid Race Index: {0}.", index));
            }
        }

        [TestMethod]
        public void Character_GetAggregateTraits()
        {
            Character c = new Character();

            for (int i = 0; i < (int)RaceId.NUMBER_OF_RACES; i++)
            {
                c.RaceId = (RaceId)i;
                Race race = Races.GetRace((RaceId)i);
                for (int j = 0; j < race.Traits.Count; j++)
                {
                    Assert.AreEqual(c.AggregateTraits[j].Id, race.Traits[j].Id);
                }
            }
        }

        [TestMethod]
        public void Character_GetAggregratePowers()
        {
            Character c = new Character();

            for (int i = 0; i < (int)RaceId.NUMBER_OF_RACES; i++)
            {
                c.RaceId = (RaceId)i;
                Race race = Races.GetRace((RaceId)i);
                for(int j = 0; j < race.Powers.Count; j++)
                {
                    Assert.AreEqual(c.AggregatePowers[j].Id, race.Powers[j].Id);
                }
            }
        }
    }
}
