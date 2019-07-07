using System;

using System.ComponentModel;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public delegate void CharacterChangedHandler( object sender, CharacterChangedEventArgs e );
        [Description("Fires when the Character changes.")]
        public event CharacterChangedHandler CharacterChanged;

        protected void onAttributeChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Attribute() );
        }

        protected void onCharacteristicChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Characteristic() );
        }

        protected void onSkillListChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Skill() );
        }

        protected void onSpellListChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Spell() );
        }

        protected void onTalentListChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Talent() );
        }

        protected void onTraitListChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Trait() );
        }

        protected void onPowerListChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Power() );
        }

        protected void onWeaponsChanged()
        {
            CharacterChanged?.Invoke( this, CharacterChangedEventArgs.Weapon() );
        }
    }
}
