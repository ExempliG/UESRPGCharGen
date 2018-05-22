using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.Test
{
    [TestClass]
    public class CharacterTesting
    {
        [TestMethod]
        public void SetCharacteristic_ValidCharacteristics()
        {
            Random r = new Random();
            Character testCharacter = new Character();

            for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                int characteristicValue = r.Next(1, 100);
                testCharacter.SetCharacteristic(i, characteristicValue);
                Assert.AreEqual(characteristicValue, testCharacter.GetCharacteristic(i), string.Format("Checking Characteristic: {0}.", i));
            }
        }

        [TestMethod]
        public void SetCharacteristic_InvalidCharacteristics()
        {
            Random r = new Random();
            Character testCharacter = new Character();

            int[] invalidCharacteristics = new int[] { 9, 25, 82, -1, -24, 100 };

            foreach(int characteristicIndex in invalidCharacteristics)
            {
                try
                {
                    testCharacter.SetCharacteristic(characteristicIndex, r.Next());
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                Assert.Fail( string.Format("No exception thrown for invalid Characteristic: {0}.", characteristicIndex));
            }
        }
    }
}
