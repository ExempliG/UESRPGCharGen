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

namespace UESRPG_Character_Manager.UI
{
    public partial class AttributesView : UserControl
    {
        private uint _activeCharacter;
        private bool _hasCharacter;
        public uint SelectorId { get; set; }
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

            toggleAllControls(false);
        }

        protected void onSelectedCharacterChanged(object sender, SelectedCharacterChangedEventArgs e)
        {
            if (e.SelectorId == SelectorId)
            {
                switch (e.EventType)
                {
                    case CharacterSelectionEvent.NEW_CHARACTER:
                        _activeCharacter = e.CharacterId;
                        _hasCharacter = true;
                        break;
                    case CharacterSelectionEvent.NO_CHARACTER:
                        _hasCharacter = false;
                        break;
                    case CharacterSelectionEvent.SAME_CHARACTER:
                        break;

                }

                toggleAllControls(_hasCharacter);

                updateView();
            }
        }

        protected void onCharacteristicChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            if (_hasCharacter)
            {
                if (!_attributesMutex)
                {
                    _attributesMutex = true;

                    Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                    maxHealthTb.Text = "" + (c.MaxHealth);
                    woundThresholdTb.Text = "" + (c.WoundThreshold);
                    maxStaminaTb.Text = "" + (c.Stamina);
                    maxMagickaTb.Text = "" + (c.MagickaPool);
                    maxActionPointsTb.Text = "" + (c.MaximumAp);
                    movementRatingTb.Text = "" + (c.MovementRating);
                    carryRatingTb.Text = "" + (c.CarryRating);
                    initiativeRatingTb.Text = "" + (c.InitiativeRating);
                    damageBonusTb.Text = "" + (c.DamageBonus);
                    maxLuckPointsTb.Text = "" + (c.MaximumLuckPoints);

                    nbModHealth.Value = c.HealthMod;
                    nbModWoundThreshold.Value = c.WoundThresholdMod;
                    nbModStamina.Value = c.StaminaMod;
                    nbModMagicka.Value = c.MagickaMod;
                    nbModActionPoints.Value = c.ActionPointsMod;
                    nbModMovementRating.Value = c.MovementRatingMod;
                    nbModCarryRating.Value = c.CarryRatingMod;
                    nbModInitiativeRating.Value = c.InitiativeRatingMod;
                    nbModDamageBonus.Value = c.DamageBonusMod;
                    nbModLuck.Value = c.LuckPointsMod;


                    healthTb.Text = "" + (c.CurrentHealth);
                    staminaTb.Text = "" + (c.CurrentStamina);
                    magickaTb.Text = "" + (c.CurrentMagicka);
                    actionPointsTb.Text = "" + (c.CurrentAp);
                    luckPointsTb.Text = "" + (c.CurrentLuckPoints);

                    _attributesMutex = false;
                }
            }
            else
            {
                clearAllControls();
            }
        }

        private void clearAllControls()
        {
            if (!_attributesMutex)
            {
                _attributesMutex = true;

                maxHealthTb.Clear();
                woundThresholdTb.Clear();
                maxStaminaTb.Clear();
                maxMagickaTb.Clear();
                maxActionPointsTb.Clear();
                movementRatingTb.Clear();
                carryRatingTb.Clear();
                initiativeRatingTb.Clear();
                damageBonusTb.Clear();
                maxLuckPointsTb.Clear();

                nbModHealth.Value = 0;
                nbModWoundThreshold.Value = 0;
                nbModStamina.Value = 0;
                nbModMagicka.Value = 0;
                nbModActionPoints.Value = 0;
                nbModMovementRating.Value = 0;
                nbModCarryRating.Value = 0;
                nbModInitiativeRating.Value = 0;
                nbModDamageBonus.Value = 0;
                nbModLuck.Value = 0;


                healthTb.Clear();
                staminaTb.Clear();
                magickaTb.Clear();
                actionPointsTb.Clear();
                luckPointsTb.Clear();

                _attributesMutex = false;
            }
        }

        private void toggleAllControls(bool enabled)
        {
            if(!enabled)
            {
                clearAllControls();
            }
            maxHealthTb.Enabled = enabled;
            woundThresholdTb.Enabled = enabled;
            maxStaminaTb.Enabled = enabled;
            maxMagickaTb.Enabled = enabled;
            maxActionPointsTb.Enabled = enabled;
            movementRatingTb.Enabled = enabled;
            carryRatingTb.Enabled = enabled;
            initiativeRatingTb.Enabled = enabled;
            damageBonusTb.Enabled = enabled;
            maxLuckPointsTb.Enabled = enabled;

            nbModHealth.Enabled = enabled;
            nbModWoundThreshold.Enabled = enabled;
            nbModStamina.Enabled = enabled;
            nbModMagicka.Enabled = enabled;
            nbModActionPoints.Enabled = enabled;
            nbModMovementRating.Enabled = enabled;
            nbModCarryRating.Enabled = enabled;
            nbModInitiativeRating.Enabled = enabled;
            nbModDamageBonus.Enabled = enabled;
            nbModLuck.Enabled = enabled;

            healthTb.Enabled = enabled;
            staminaTb.Enabled = enabled;
            magickaTb.Enabled = enabled;
            actionPointsTb.Enabled = enabled;
            luckPointsTb.Enabled = enabled;
        }

        #region Attribute Event Handlers
        private void healthTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeHealth(_activeCharacter, tryParseAttribute(healthTb.Text)); });
        }

        private void staminaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeStamina(_activeCharacter, tryParseAttribute(staminaTb.Text)); });
        }

        private void magickaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeMagicka(_activeCharacter, tryParseAttribute(magickaTb.Text)); });
        }

        private void actionPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeAP(_activeCharacter, tryParseAttribute(actionPointsTb.Text)); });
        }

        private void luckPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute( delegate() { CharacterController.Instance.ChangeLuck(_activeCharacter, tryParseAttribute(luckPointsTb.Text)); });
        }
        #endregion

        #region Modifier Event Handlers
        private void nbModHealth_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.HEALTH, (int)nbModHealth.Value); });
        }

        private void nbModWoundThreshold_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.WOUND_THRESHOLD, (int)nbModWoundThreshold.Value); });
        }

        private void nbModStamina_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.STAMINA, (int)nbModStamina.Value); });
        }

        private void nbModMagicka_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.MAGICKA, (int)nbModMagicka.Value); });
        }

        private void nbModActionPoints_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.ACTION_POINTS, (int)nbModActionPoints.Value); });
        }

        private void nbModMovementRating_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.MOVEMENT_RATING, (int)nbModMovementRating.Value); });
        }

        private void nbModCarryRating_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.CARRY_RATING, (int)nbModCarryRating.Value); });
        }

        private void nbModInitiativeRating_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.INITIATIVE_RATING, (int)nbModInitiativeRating.Value); });
        }

        private void nbModDamageBonus_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.DAMAGE_BONUS, (int)nbModDamageBonus.Value); });
        }

        private void nbModLuck_ValueChanged(object sender, EventArgs e)
        {
            changeModifier(delegate () { CharacterController.Instance.ChangeModifier(_activeCharacter, Modifiers.LUCK_POINTS, (int)nbModLuck.Value); });
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
            updateView();
        }
    }
}
