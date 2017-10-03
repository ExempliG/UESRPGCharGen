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

namespace UESRPG_Character_Manager.UI
{
    public partial class AttributesView : UserControl
    {
        private Character _activeCharacter;
        private bool _attributesMutex;
        private bool _modifierMutex;

        public AttributesView()
        {
            InitializeComponent();
            _attributesMutex = false;
            _modifierMutex = false;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            CharacterController.Instance.CharacteristicChanged += onCharacteristicChanged;
            CharacterController.Instance.AttributeChanged += onAttributeChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;
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

                maxHealthTb.Text = "" + (_activeCharacter.MaxHealth);
                woundThresholdTb.Text = "" + (_activeCharacter.WoundThreshold);
                maxStaminaTb.Text = "" + (_activeCharacter.Stamina);
                maxMagickaTb.Text = "" + (_activeCharacter.MagickaPool);
                maxActionPointsTb.Text = "" + (_activeCharacter.MaximumAp);
                movementRatingTb.Text = "" + (_activeCharacter.MovementRating);
                carryRatingTb.Text = "" + (_activeCharacter.CarryRating);
                initiativeRatingTb.Text = "" + (_activeCharacter.InitiativeRating);
                damageBonusTb.Text = "" + (_activeCharacter.DamageBonus);
                maxLuckPointsTb.Text = "" + (_activeCharacter.MaximumLuckPoints);

                nbModHealth.Value = _activeCharacter.HealthMod;
                nbModWoundThreshold.Value = _activeCharacter.WoundThresholdMod;
                nbModStamina.Value = _activeCharacter.StaminaMod;
                nbModMagicka.Value = _activeCharacter.MagickaMod;
                nbModActionPoints.Value = _activeCharacter.ActionPointsMod;
                nbModMovementRating.Value = _activeCharacter.MovementRatingMod;
                nbModCarryRating.Value = _activeCharacter.CarryRatingMod;
                nbModInitiativeRating.Value = _activeCharacter.InitiativeRatingMod;
                nbModDamageBonus.Value = _activeCharacter.DamageBonusMod;
                nbModLuck.Value = _activeCharacter.LuckPointsMod;


                healthTb.Text = "" + (_activeCharacter.CurrentHealth);
                staminaTb.Text = "" + (_activeCharacter.CurrentStamina);
                magickaTb.Text = "" + (_activeCharacter.CurrentMagicka);
                actionPointsTb.Text = "" + (_activeCharacter.CurrentAp);
                luckPointsTb.Text = "" + (_activeCharacter.CurrentLuckPoints);
                
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
