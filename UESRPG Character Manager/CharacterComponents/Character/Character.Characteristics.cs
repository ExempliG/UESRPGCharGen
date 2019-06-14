using System;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public int Strength
        {
            get { return _characteristics[Characteristics.STRENGTH]; }
            set { _characteristics[Characteristics.STRENGTH] = value; }
        }
        public int Endurance
        {
            get { return _characteristics[Characteristics.ENDURANCE]; }
            set { _characteristics[Characteristics.ENDURANCE] = value; }
        }
        public int Agility
        {
            get { return _characteristics[Characteristics.AGILITY]; }
            set { _characteristics[Characteristics.AGILITY] = value; }
        }
        public int Intelligence
        {
            get { return _characteristics[Characteristics.INTELLIGENCE]; }
            set { _characteristics[Characteristics.INTELLIGENCE] = value; }
        }
        public int Willpower
        {
            get { return _characteristics[Characteristics.WILLPOWER]; }
            set { _characteristics[Characteristics.WILLPOWER] = value; }
        }
        public int Perception
        {
            get { return _characteristics[Characteristics.PERCEPTION]; }
            set { _characteristics[Characteristics.PERCEPTION] = value; }
        }
        public int Personality
        {
            get { return _characteristics[Characteristics.PERSONALITY]; }
            set { _characteristics[Characteristics.PERSONALITY] = value; }
        }
        public int Luck
        {
            get { return _characteristics[Characteristics.LUCK]; }
            set { _characteristics[Characteristics.LUCK] = value; }
        }

        public void SetCharacteristic(int index, int value)
        {
            if (value >= Characteristics.MIN && value <= Characteristics.MAX)
            {
                if (index >= 0 && index < Characteristics.NUMBER_OF_CHARACTERISTICS)
                {
                    _characteristics[index] = value;
                    onCharacteristicChanged();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("index", CharacterExceptionMessages.SetUnsupportedCharacteristicMessage);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("value", CharacterExceptionMessages.CharacteristicValueOutOfRangeMessage);
            }
        }

        public int GetCharacteristic(int index)
        {
            int result = -1;

            if (index >= 0 && index < Characteristics.NUMBER_OF_CHARACTERISTICS)
            {
                result = _characteristics[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Attempted to retrieve an unsupported Characteristic.");
            }

            return result;
        }
    }
}
