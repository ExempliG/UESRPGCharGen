using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    public enum CharacterAspect
    {
        NAME,
        ATTRIBUTE,
        CHARACTERISTIC,
        EQUIPMENT_ARMOR,
        EQUIPMENT_WEAPON,
        POWER,
        SKILL,
        SPELL,
        TALENT,
        TRAIT,
    }

    public class CharacterChangedEventArgs : EventArgs
    {
        public CharacterChangedEventArgs( CharacterAspect aspect )
        {
            Aspect = aspect;
        }

        public CharacterAspect Aspect { get; private set; }

        public static CharacterChangedEventArgs Attribute()
        {
            return new CharacterChangedEventArgs( CharacterAspect.ATTRIBUTE );
        }

        public static CharacterChangedEventArgs Characteristic()
        {
            return new CharacterChangedEventArgs( CharacterAspect.CHARACTERISTIC );
        }

        public static CharacterChangedEventArgs Armor()
        {
            return new CharacterChangedEventArgs( CharacterAspect.EQUIPMENT_ARMOR );
        }

        public static CharacterChangedEventArgs Weapon()
        {
            return new CharacterChangedEventArgs( CharacterAspect.EQUIPMENT_WEAPON );
        }

        public static CharacterChangedEventArgs Power()
        {
            return new CharacterChangedEventArgs( CharacterAspect.POWER );
        }

        public static CharacterChangedEventArgs Skill()
        {
            return new CharacterChangedEventArgs( CharacterAspect.SKILL );
        }

        public static CharacterChangedEventArgs Spell()
        {
            return new CharacterChangedEventArgs( CharacterAspect.SPELL );
        }

        public static CharacterChangedEventArgs Talent()
        {
            return new CharacterChangedEventArgs( CharacterAspect.TALENT );
        }

        public static CharacterChangedEventArgs Trait()
        {
            return new CharacterChangedEventArgs( CharacterAspect.TRAIT );
        }
    }
}
