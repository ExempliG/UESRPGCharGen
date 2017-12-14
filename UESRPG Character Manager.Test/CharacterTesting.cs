using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.UI.CharacterViews;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.Test
{
    [TestClass]
    public class CharacterTesting
    {
        [TestMethod]
        public void SetCharacteristic_ValidCharacteristics_ValidValue()
        {
            Random r = new Random();
            Character testCharacter = new Character();

            for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                int characteristicValue = r.Next(Characteristics.MIN, Characteristics.MAX);
                testCharacter.SetCharacteristic(i, characteristicValue);
                Assert.AreEqual(characteristicValue, testCharacter.GetCharacteristic(i), string.Format("Checking Characteristic: {0}.", i));
            }
        }

        [TestMethod]
        public void SetCharacteristic_InvalidCharacteristics_ValidValue()
        {
            Random r = new Random();
            Character testCharacter = new Character();

            int[] invalidCharacteristics = new int[] { 9, 25, 82, -1, -24, 100 };

            foreach(int characteristicIndex in invalidCharacteristics)
            {
                int value = r.Next(Characteristics.MIN, Characteristics.MAX);
                try
                {
                    testCharacter.SetCharacteristic(characteristicIndex, value);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    if (e.Message.StartsWith(CharacterExceptionMessages.SetUnsupportedCharacteristicMessage))
                    {
                        continue;
                    }
                    else
                    {
                        Assert.Fail(string.Format("Incorrect exception for Characteristic: {0}, Value: {1}.", characteristicIndex, value));
                    }
                }
                Assert.Fail( string.Format("No exception for Characteristic: {0}, Value: {1}.", characteristicIndex, value));
            }
        }

        [TestMethod]
        public void SetCharacteristic_ValidCharacteristics_InvalidValue()
        {
            int[] invalidValues = new int[] { -1, 101, 500, 5000, 12000 };
            Character testCharacter = new Character();

            for(int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                foreach (int value in invalidValues)
                {
                    try
                    {
                        testCharacter.SetCharacteristic(i, value);
                    }
                    catch(ArgumentOutOfRangeException e)
                    {
                        if (e.Message.StartsWith(CharacterExceptionMessages.CharacteristicValueOutOfRangeMessage))
                        {
                            continue;
                        }
                        else
                        {
                            Assert.Fail(string.Format("Incorrect exception for Characteristic: {0}, Value: {1}.", i, value));
                        }
                    }
                    Assert.Fail(string.Format("No exception for Characteristic: {0}, Value: {1}.", i, value));
                }
            }
        }

        [TestMethod]
        public void SetCharacteristic_InvalidCharacteristics_InvalidValue()
        {
            int[] invalidValues = new int[] { -1, 101, 500, 5000, 12000 };
            int[] invalidCharacteristics = new int[] { 9, 25, 82, -1, -24, 100 };
            Character testCharacter = new Character();

            foreach(int index in invalidCharacteristics)
            {
                foreach(int value in invalidValues)
                {
                    try
                    {
                        testCharacter.SetCharacteristic(index, value);
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                    Assert.Fail(string.Format("No exception for Characteristic: {0}, Value: {1}.", index, value));
                }
            }
        }

        [TestMethod]
        public void CharacteristicsView_ValidValues()
        {
            CharacterController.Instance.Reset();
            Character testCharacter = CharacterController.Instance.ActiveCharacter;

            CharacteristicsView cv = new CharacteristicsView();
            PrivateObject pcv = new PrivateObject(cv);

            int[] characteristicValues = new int[] { 0, 10, 20, 50, 75, 100 };
            string[] characteristicNudNames = new string[]
            {
                "nbStrength",
                "nbEndurance",
                "nbAgility",
                "nbIntelligence",
                "nbWillpower",
                "nbPerception",
                "nbPersonality",
                "nbLuck"
            };

            for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                NumericUpDown nb = (NumericUpDown)pcv.GetField(characteristicNudNames[i]);

                for (int j = 0; j < characteristicValues.Length; j++)
                {
                    int value = characteristicValues[j];
                    int nextValue = characteristicValues[(j + 1) % characteristicValues.Length];
                    Assert.AreEqual(testCharacter.GetCharacteristic(i), nb.Value);

                    nb.Value = nextValue;
                    Assert.AreNotEqual(value, testCharacter.GetCharacteristic(i));
                    Assert.AreEqual(testCharacter.GetCharacteristic(i), nb.Value);

                    CharacterController.Instance.ChangeCharacteristic(i, value);
                    Assert.AreEqual(value, testCharacter.GetCharacteristic(i));
                    Assert.AreEqual(testCharacter.GetCharacteristic(i), nb.Value);
                }
            }
        }

        [TestMethod]
        public void CharacteristicsView_InvalidValues()
        {
            CharacterController.Instance.Reset();
            Character testCharacter = CharacterController.Instance.ActiveCharacter;

            CharacteristicsView cv = new CharacteristicsView();
            PrivateObject pcv = new PrivateObject(cv);

            int[] characteristicValues = new int[] { -1, 101, 102, 400 };
            string[] characteristicNudNames = new string[]
            {
                "nbStrength",
                "nbEndurance",
                "nbAgility",
                "nbIntelligence",
                "nbWillpower",
                "nbPerception",
                "nbPersonality",
                "nbLuck"
            };

            for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                NumericUpDown nb = (NumericUpDown)pcv.GetField(characteristicNudNames[i]);

                for (int j = 0; j < characteristicValues.Length; j++)
                {
                    int value = characteristicValues[j];
                    Assert.AreEqual(testCharacter.GetCharacteristic(i), nb.Value);

                    try
                    {
                        nb.Value = value;
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        // do nothing
                    }
                    Assert.AreNotEqual(value, testCharacter.GetCharacteristic(i));
                    Assert.AreEqual(testCharacter.GetCharacteristic(i), nb.Value);
                }
            }
        }
    }
}
