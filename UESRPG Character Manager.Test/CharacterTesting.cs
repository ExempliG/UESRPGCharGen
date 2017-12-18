using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

using System.Collections.Generic;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.UI.CharacterViews;
using UESRPG_Character_Manager.UI.MainWindow;
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
        public void Character_Equals_EqualCharacter()
        {
            Character a = new Character();
            a.Name = "Freddy Test";
            a.Notes = "Notes about Freddy Test";
            a.AddArmorPiece(new Items.Armor());
            a.AddSkill(new Skill());
            a.AddWeapon(new Items.Weapon());
            a.AddSpell(new Spell());

            Random r = new Random();
            for(int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                a.SetCharacteristic(i, r.Next(1, 100));
            }

            for(int i = 0; i < Modifiers.NUMBER_OF_MODIFIERS; i++)
            {
                a.SetModifier(i, r.Next(1, 10));
            }

            Character b = (Character)a.Clone();

            Assert.AreEqual(true, a.Equals(b));
            Assert.AreEqual(true, b.Equals(a));
        }

        [TestMethod]
        public void Character_Equals_InequalCharacter()
        {
            Character a = new Character();
            a.Name = "Freddy Test";
            a.Notes = "Notes about Freddy Test";
            a.AddArmorPiece(new Items.Armor());
            a.AddSkill(new Skill());
            a.AddWeapon(new Items.Weapon());
            a.AddSpell(new Spell());

            Random r = new Random();
            for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                a.SetCharacteristic(i, r.Next(1, 100));
            }

            for (int i = 0; i < Modifiers.NUMBER_OF_MODIFIERS; i++)
            {
                a.SetModifier(i, r.Next(1, 10));
            }

            Character b = (Character)a.Clone();

            Assert.AreEqual(true, a.Equals(b));
            Assert.AreEqual(true, b.Equals(a));

            b.Name = "Frederica Test";
            b.Notes = "Notes about Frederica Test";

            Assert.AreNotEqual(true, a.Equals(b));
            Assert.AreNotEqual(true, b.Equals(a));

            b.Name = "Freddy Test";
            b.Notes = "Notes about Freddy Test";

            Assert.AreEqual(true, a.Equals(b));
            Assert.AreEqual(true, b.Equals(a));

            b.AddArmorPiece(new Items.Armor("Glove", 0.1, 2, 3, ArmorLocations.LEFT_ARM, new string[0]));
            b.AddSkill(new Skill());
            b.AddWeapon(new Items.Weapon());
            b.AddSpell(new Spell());

            Assert.AreNotEqual(true, a.Equals(b));
            Assert.AreNotEqual(true, b.Equals(a));
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

            CharacterController.Instance.Reset();
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

            CharacterController.Instance.Reset();
        }

        [TestMethod]
        public void AttributesView_Bindings()
        {
            CharacterController.Instance.Reset();
            Character testCharacter = CharacterController.Instance.ActiveCharacter;
            AttributesView av = new AttributesView();
            PrivateObject obj = new PrivateObject(av);
            string[] attributeTbNames =
            {
                "maxHealthTb",
                "woundThresholdTb",
                "maxStaminaTb",
                "maxMagickaTb",
                "maxActionPointsTb",
                "movementRatingTb",
                "carryRatingTb",
                "initiativeRatingTb",
                "damageBonusTb",
                "maxLuckPointsTb"
            };

            for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
            {
                testCharacter.SetCharacteristic(i, 50);
            }

            int[] attributeValues =
            {
                testCharacter.MaxHealth,
                testCharacter.WoundThreshold,
                testCharacter.Stamina,
                testCharacter.MagickaPool,
                testCharacter.MaximumAp,
                testCharacter.MovementRating,
                testCharacter.CarryRating,
                testCharacter.InitiativeRating,
                testCharacter.DamageBonus,
                testCharacter.MaximumLuckPoints
            };

            for(int i = 0; i < attributeTbNames.Length; i++)
            {
                string attributeTbName = attributeTbNames[i];
                TextBox attributeTb = (TextBox)obj.GetField(attributeTbName);

                int value = 0;
                if(int.TryParse(attributeTb.Text, out value))
                {
                    Assert.AreEqual(value, attributeValues[i]);
                }
                else
                {
                    Assert.Fail("Invalid value in attribute TextBox.");
                }
            }

            CharacterController.Instance.Reset();
        }

        [TestMethod]
        public void Attributes_Values()
        {
            CharacterController.Instance.Reset();
            Character testCharacter = CharacterController.Instance.ActiveCharacter;
            AttributesView av = new AttributesView();
            PrivateObject obj = new PrivateObject(av);

            int[] characteristicValues = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };

            foreach (int value in characteristicValues)
            {
                for (int i = 0; i < Characteristics.NUMBER_OF_CHARACTERISTICS; i++)
                {
                    testCharacter.SetCharacteristic(i, value);
                }

                int calculatedHealth = testCharacter.Endurance;
                Assert.AreEqual(calculatedHealth, testCharacter.MaxHealth);
                int calculatedWounds = testCharacter.Endurance.GetBonus() + testCharacter.Strength.GetBonus();
                Assert.AreEqual(calculatedWounds, testCharacter.WoundThreshold);
                int calculatedStamina = Math.Max(testCharacter.Endurance.GetBonus() - 1, 2);
                Assert.AreEqual(calculatedStamina, testCharacter.Stamina);
                int calculatedMagicka = testCharacter.Intelligence;
                Assert.AreEqual(calculatedMagicka, testCharacter.MagickaPool);
                int calculatedMovement = testCharacter.Agility.GetBonus();
                Assert.AreEqual(calculatedMovement, testCharacter.MovementRating);
                int calculatedCarry = (testCharacter.Strength.GetBonus() * 2) + testCharacter.Endurance.GetBonus();
                Assert.AreEqual(calculatedCarry, testCharacter.CarryRating);
                int calculatedIntiative = testCharacter.Agility.GetBonus() + testCharacter.Perception.GetBonus();
                Assert.AreEqual(calculatedIntiative, testCharacter.InitiativeRating);
                int calculatedDamage = testCharacter.Strength.GetBonus();
                Assert.AreEqual(calculatedDamage, testCharacter.DamageBonus);
                int calculatedLuck = testCharacter.Luck.GetBonus();
                Assert.AreEqual(calculatedLuck, testCharacter.MaximumLuckPoints);
                int apScore = testCharacter.Agility.GetBonus() + testCharacter.Intelligence.GetBonus() + testCharacter.Perception.GetBonus();
                int calculatedAp = 1;
                if (apScore >= 7 && apScore <= 14)
                {
                    calculatedAp = 2;
                }
                else if (apScore >= 15)
                {
                    calculatedAp = 3;
                }
                Assert.AreEqual(calculatedAp, testCharacter.MaximumAp);
            }

            CharacterController.Instance.Reset();
        }

        [TestMethod]
        public void AttributesView_Modifiers_ValidValues()
        {
            CharacterController.Instance.Reset();
            Character testCharacter = CharacterController.Instance.ActiveCharacter;
            AttributesView av = new AttributesView();
            PrivateObject obj = new PrivateObject(av);

            string[] modifierNudNames =
            {
                "nbModHealth",
                "nbModWoundThreshold",
                "nbModStamina",
                "nbModMagicka",
                "nbModActionPoints",
                "nbModMovementRating",
                "nbModCarryRating",
                "nbModInitiativeRating",
                "nbModDamageBonus",
                "nbModLuck"
            };
            int[] modifierValues = { -99, -50 - 25, 0, 25, 50, 99 };

            for(int i = 0; i < Modifiers.NUMBER_OF_MODIFIERS; i++)
            {
                string modifierNudName = modifierNudNames[i];
                NumericUpDown modifierNud = (NumericUpDown)obj.GetField(modifierNudName);

                foreach (int value in modifierValues)
                {
                    testCharacter.SetModifier(i, value);
                    Assert.AreEqual(value, testCharacter.GetModifier(i));
                    Assert.AreEqual(value, (int)modifierNud.Value);
                }

                foreach (int value in modifierValues)
                {
                    modifierNud.Value = value;
                    Assert.AreEqual(value, (int)modifierNud.Value);
                    Assert.AreEqual(value, testCharacter.GetModifier(i));
                }
            }

            CharacterController.Instance.Reset();
        }

        [TestMethod]
        public void AttributesView_Modifiers_InvalidValues()
        {
            CharacterController.Instance.Reset();
            Character testCharacter = CharacterController.Instance.ActiveCharacter;
            AttributesView av = new AttributesView();
            PrivateObject obj = new PrivateObject(av);

            string[] modifierNudNames =
            {
                "nbModHealth",
                "nbModWoundThreshold",
                "nbModStamina",
                "nbModMagicka",
                "nbModActionPoints",
                "nbModMovementRating",
                "nbModCarryRating",
                "nbModInitiativeRating",
                "nbModDamageBonus",
                "nbModLuck"
            };
            int[] modifierValues = { -10000, -1000, -100, 100, 1000, 10000 };

            for (int i = 0; i < Modifiers.NUMBER_OF_MODIFIERS; i++)
            {
                string modifierNudName = modifierNudNames[i];
                NumericUpDown modifierNud = (NumericUpDown)obj.GetField(modifierNudName);

                foreach (int value in modifierValues)
                {
                    try
                    {
                        testCharacter.SetModifier(i, value);
                    }
                    catch(ArgumentOutOfRangeException e)
                    {
                        if(e.Message.StartsWith(CharacterExceptionMessages.ModifierValueOutOfRangeMessage))
                        {
                            Assert.AreNotEqual(value, (int)modifierNud.Value);
                            continue;
                        }
                        else
                        {
                            Assert.Fail("Incorrect exception thrown.");
                        }
                    }
                    Assert.Fail("No exception thrown.");
                }
            }

            CharacterController.Instance.Reset();
        }

        [TestMethod]
        public void CharacterSelector()
        {
            CharacterController.Instance.Reset();
            CharacterSelector cs = new CharacterSelector();
            PrivateObject obj = new PrivateObject(cs);

            ComboBox charactersCb = (ComboBox)obj.GetField("charactersCb");
            Assert.AreEqual(1, charactersCb.Items.Count);

            Character newCharacter = CharacterController.Instance.AddCharacter();
            Assert.AreEqual(2, charactersCb.Items.Count);

            newCharacter.Name = "Freddy Test";
            charactersCb.SelectedIndex = 0;
            Assert.AreEqual("Player", CharacterController.Instance.ActiveCharacter.Name);
            charactersCb.SelectedIndex = 1;
            Assert.AreEqual("Freddy Test", CharacterController.Instance.ActiveCharacter.Name);

            Button btAddCharacter = (Button)obj.GetField("btAddCharacter");
            btAddCharacter.PerformClick();
            Assert.AreEqual(3, charactersCb.Items.Count);
            charactersCb.SelectedIndex = 2;
            Assert.AreEqual("Player", CharacterController.Instance.ActiveCharacter.Name);

            CharacterController.Instance.Reset();
        }

        [TestMethod]
        public void Notes()
        {
            string notes1 = "Test character 1.";
            string notes2 = "Test character 2.";
            string notes3 = "Test character 3.";
            string notes4 = "Test character 4.";

            // Ensure that notes are correctly maintained/updated on Character swapping.
            CharacterController.Instance.Reset();
            Character testCharacter1 = CharacterController.Instance.ActiveCharacter;
            testCharacter1.Notes = notes1;
            Character testCharacter2 = CharacterController.Instance.AddCharacter();
            testCharacter2.Notes = notes2;

            MainWindow mw = new MainWindow();
            PrivateObject obj = new PrivateObject(mw);
            RichTextBox characterNotesRtb = (RichTextBox)obj.GetField("characterNotesRtb");

            CharacterController.Instance.SelectCharacter(0);
            Assert.AreEqual(notes1, testCharacter1.Notes);
            Assert.AreEqual(testCharacter1.Notes, characterNotesRtb.Text);

            CharacterController.Instance.SelectCharacter(1);
            Assert.AreEqual(notes2, testCharacter2.Notes);
            Assert.AreEqual(testCharacter2.Notes, characterNotesRtb.Text);

            // Create a new Character list and swap it in, simulating a save file load.
            PrivateObject controllerObj = new PrivateObject(CharacterController.Instance);

            Character testCharacter3 = new Character();
            testCharacter3.Notes = notes3;
            Character testCharacter4 = new Character();
            testCharacter4.Notes = notes4;
            List<Character> newList = new List<Character>();
            newList.Add(testCharacter3);
            newList.Add(testCharacter4);
            controllerObj.SetField("_characterList", newList);
            controllerObj.Invoke("onSelectedCharacterChanged");
            controllerObj.Invoke("onCharacterListChanged");

            CharacterController.Instance.SelectCharacter(0);
            Assert.AreEqual(notes3, testCharacter3.Notes);
            Assert.AreEqual(testCharacter3.Notes, characterNotesRtb.Text);

            CharacterController.Instance.SelectCharacter(1);
            Assert.AreEqual(notes4, testCharacter4.Notes);
            Assert.AreEqual(testCharacter4.Notes, characterNotesRtb.Text);

            CharacterController.Instance.Reset();
        }
    }
}
