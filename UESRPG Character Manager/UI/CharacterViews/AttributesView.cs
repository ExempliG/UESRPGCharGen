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

namespace UESRPG_Character_Manager.UI
{
    public partial class AttributesView : UserControl
    {
        private Character _activeCharacter;
        private bool _attributesMutex;

        public AttributesView()
        {
            InitializeComponent();
            _attributesMutex = false;
        }

        public void OnSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();
            UpdateView();
        }

        public void OnCharacteristicChanged(object sender, EventArgs e)
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
            changeAttribute(delegate () { _activeCharacter.CurrentHealth = tryParseAttribute(healthTb.Text); });
        }

        private void staminaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.CurrentStamina = tryParseAttribute(staminaTb.Text); });
        }

        private void magickaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.CurrentMagicka = tryParseAttribute(magickaTb.Text); });
        }

        private void actionPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.CurrentAp = tryParseAttribute(actionPointsTb.Text); });
        }

        private void luckPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute( delegate() { _activeCharacter.CurrentLuckPoints = tryParseAttribute(luckPointsTb.Text); });
        }
        #endregion

        #region Modifier Event Handlers
        private void nbModHealth_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.HealthMod = (int)nbModHealth.Value; });
        }

        private void nbModWoundThreshold_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.WoundThresholdMod = (int)nbModWoundThreshold.Value; });
        }

        private void nbModStamina_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.StaminaMod = (int)nbModStamina.Value; });
        }

        private void nbModMagicka_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.MagickaMod = (int)nbModMagicka.Value; });
        }

        private void nbModActionPoints_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.ActionPointsMod = (int)nbModActionPoints.Value; });
        }

        private void nbModMovementRating_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.MovementRatingMod = (int)nbModMovementRating.Value; });
        }

        private void nbModCarryRating_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.CarryRatingMod = (int)nbModCarryRating.Value; });
        }

        private void nbModInitiativeRating_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.InitiativeRatingMod = (int)nbModInitiativeRating.Value; });
        }

        private void nbModDamageBonus_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.DamageBonusMod = (int)nbModDamageBonus.Value; });
        }

        private void nbModLuck_ValueChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { _activeCharacter.LuckPointsMod = (int)nbModLuck.Value; });
        }
        #endregion

        private int tryParseAttribute(string textVal)
        {
            int value = 0;
            int.TryParse(textVal, out value);
            return value;
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
    }
}
