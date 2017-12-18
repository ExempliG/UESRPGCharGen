using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.UI.MainWindow;
using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class AttributesView : UserControl
    {
        private bool _attributesMutex;
        private bool _modifierMutex;

        public AttributesView()
        {
            InitializeComponent();
            _attributesMutex = false;
            _modifierMutex = false;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.CharacteristicChanged += onCharacteristicChanged;
            Character.AttributeChanged += onAttributeChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        protected void onCharacteristicChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        public void UpdateView()
        {
            if (!_attributesMutex)
            {
                _attributesMutex = true;

                maxHealthTb.Text = "" + (CharacterController.Instance.ActiveCharacter.MaxHealth);
                woundThresholdTb.Text = "" + (CharacterController.Instance.ActiveCharacter.WoundThreshold);
                maxStaminaTb.Text = "" + (CharacterController.Instance.ActiveCharacter.Stamina);
                maxMagickaTb.Text = "" + (CharacterController.Instance.ActiveCharacter.MagickaPool);
                maxActionPointsTb.Text = "" + (CharacterController.Instance.ActiveCharacter.MaximumAp);
                movementRatingTb.Text = "" + (CharacterController.Instance.ActiveCharacter.MovementRating);
                carryRatingTb.Text = "" + (CharacterController.Instance.ActiveCharacter.CarryRating);
                initiativeRatingTb.Text = "" + (CharacterController.Instance.ActiveCharacter.InitiativeRating);
                damageBonusTb.Text = "" + (CharacterController.Instance.ActiveCharacter.DamageBonus);
                maxLuckPointsTb.Text = "" + (CharacterController.Instance.ActiveCharacter.MaximumLuckPoints);

                nbModHealth.Value = CharacterController.Instance.ActiveCharacter.HealthMod;
                nbModWoundThreshold.Value = CharacterController.Instance.ActiveCharacter.WoundThresholdMod;
                nbModStamina.Value = CharacterController.Instance.ActiveCharacter.StaminaMod;
                nbModMagicka.Value = CharacterController.Instance.ActiveCharacter.MagickaMod;
                nbModActionPoints.Value = CharacterController.Instance.ActiveCharacter.ActionPointsMod;
                nbModMovementRating.Value = CharacterController.Instance.ActiveCharacter.MovementRatingMod;
                nbModCarryRating.Value = CharacterController.Instance.ActiveCharacter.CarryRatingMod;
                nbModInitiativeRating.Value = CharacterController.Instance.ActiveCharacter.InitiativeRatingMod;
                nbModDamageBonus.Value = CharacterController.Instance.ActiveCharacter.DamageBonusMod;
                nbModLuck.Value = CharacterController.Instance.ActiveCharacter.LuckPointsMod;


                healthTb.Text = "" + (CharacterController.Instance.ActiveCharacter.CurrentHealth);
                staminaTb.Text = "" + (CharacterController.Instance.ActiveCharacter.CurrentStamina);
                magickaTb.Text = "" + (CharacterController.Instance.ActiveCharacter.CurrentMagicka);
                actionPointsTb.Text = "" + (CharacterController.Instance.ActiveCharacter.CurrentAp);
                luckPointsTb.Text = "" + (CharacterController.Instance.ActiveCharacter.CurrentLuckPoints);
                
                _attributesMutex = false;
            }
        }

        #region Attribute Event Handlers
        private void healthTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeHealth(tryParseAttribute(healthTb.Text)); });
        }

        private void staminaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeStamina(tryParseAttribute(staminaTb.Text)); });
        }

        private void magickaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeMagicka(tryParseAttribute(magickaTb.Text)); });
        }

        private void actionPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeAP(tryParseAttribute(actionPointsTb.Text)); });
        }

        private void luckPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute( delegate() { CharacterController.Instance.ChangeLuck(tryParseAttribute(luckPointsTb.Text)); });
        }
        #endregion

        #region Modifier Event Handlers
        private void nbModHealth_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.HEALTH, (int)nbModHealth.Value); });
        }

        private void nbModWoundThreshold_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.WOUND_THRESHOLD, (int)nbModWoundThreshold.Value); });
        }

        private void nbModStamina_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.STAMINA, (int)nbModStamina.Value); });
        }

        private void nbModMagicka_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.MAGICKA, (int)nbModMagicka.Value); });
        }

        private void nbModActionPoints_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.ACTION_POINTS, (int)nbModActionPoints.Value); });
        }

        private void nbModMovementRating_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.MOVEMENT_RATING, (int)nbModMovementRating.Value); });
        }

        private void nbModCarryRating_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.CARRY_RATING, (int)nbModCarryRating.Value); });
        }

        private void nbModInitiativeRating_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.INITIATIVE_RATING, (int)nbModInitiativeRating.Value); });
        }

        private void nbModDamageBonus_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.DAMAGE_BONUS, (int)nbModDamageBonus.Value); });
        }

        private void nbModLuck_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(Modifiers.LUCK_POINTS, (int)nbModLuck.Value); });
        }
        #endregion

        private int tryParseAttribute(string textVal)
        {
            if (int.TryParse(textVal, out int value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        private void changeAttribute(Action attributeChange)
        {
            if (!_attributesMutex)
            {
                _attributesMutex = true;
                attributeChange();
                _attributesMutex = false;
            }
        }

        private void changeModifier(Action modifierChange)
        {
            if (!_modifierMutex)
            {
                _modifierMutex = true;
                modifierChange();
                _modifierMutex = false;
            }
        }

        private void onAttributeChanged(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
