using System;

using System.ComponentModel;

namespace UESRPG_Character_Manager.CharacterComponents
{
    partial class Character
    {
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

        protected void onCharacteristicChanged()
        {
            CharacteristicChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onAttributeChanged()
        {
            AttributeChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onSkillListChanged()
        {
            SkillListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onSpellListChanged()
        {
            SpellListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onTalentListChanged()
        {
            TalentListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onTraitListChanged()
        {
            TraitListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onPowerListChanged()
        {
            PowerListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onWeaponsChanged()
        {
            WeaponsChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
