using System;

using System.ComponentModel;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public delegate void CharacterChangedHandler( object sender, CharacterChangedEventArgs e );
        [Description("Fires when the Character changes.")]
        public event CharacterChangedHandler CharacterChanged;

        public delegate void CharacteristicChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Characteristics is changed by the user.")]
        public static event CharacteristicChangedHandler CharacteristicChanged;

        public delegate void AttributeChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Attributes is changed by the user.")]
        public static event AttributeChangedHandler AttributeChanged;

        public delegate void SkillListChangedHandler(object sender, EventArgs e);
        [Description("Fires when a skill is added, removed, or edited.")]
        public static event SkillListChangedHandler SkillListChanged;

        public delegate void SpellListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the spell list changes via adding or renaming a spell.")]
        public static event SpellListChangedHandler SpellListChanged;

        public delegate void TalentListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the talent list changes via adding, renaming, or deleting a talent.")]
        public static event TalentListChangedHandler TalentListChanged;

        public delegate void TraitListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the trait list changes via adding, renaming, or deleting a trait.")]
        public static event TraitListChangedHandler TraitListChanged;

        public delegate void PowerListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the power list changes via adding, renaming, or deleting a power.")]
        public static event PowerListChangedHandler PowerListChanged;

        public delegate void WeaponsChangedHandler(object sender, EventArgs e);
        [Description("Fires when a Weapon is changed or added by the user.")]
        public static event WeaponsChangedHandler WeaponsChanged;

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
