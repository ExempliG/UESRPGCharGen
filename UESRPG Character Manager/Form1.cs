using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace UESRPG_Character_Manager
{
    public partial class Form1 : Form
    {
        private List<Character> _characterList;
        private Character _selectedChar;

        public Form1 ()
        {
            InitializeComponent ();
            _characterList = new List<Character> ();
            _selectedChar = new Character ();
            _characterList.Add (_selectedChar);

            foreach (string characteristic in _selectedChar._characteristics.Keys)
            {
                characteristicCb.Items.Add (characteristic);
            }

            characteristicCb.SelectedIndex = 0;
        }

        /// <summary>
        /// A characteristic changed, so we will update all the character's values/mods and re-calculate the calculated fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicChanged (object sender, EventArgs e)
        {
            _selectedChar.Strength     = (int)nbStrength.Value;
            _selectedChar.Endurance    = (int)nbEndurance.Value;
            _selectedChar.Agility      = (int)nbAgility.Value;
            _selectedChar.Intelligence = (int)nbIntelligence.Value;
            _selectedChar.Willpower    = (int)nbWillpower.Value;
            _selectedChar.Perception   = (int)nbPerception.Value;
            _selectedChar.Personality  = (int)nbPersonality.Value;
            _selectedChar.Luck         = (int)nbLuck.Value;

            _selectedChar.HealthMod           = (int)nbModHealth.Value;
            _selectedChar.WoundThresholdMod   = (int)nbModWoundThreshold.Value;
            _selectedChar.StaminaMod          = (int)nbModStamina.Value;
            _selectedChar.MagickaMod          = (int)nbModMagicka.Value;
            _selectedChar.ActionPointsMod     = (int)nbModActionPoints.Value;
            _selectedChar.MovementRatingMod   = (int)nbModMovementRating.Value;
            _selectedChar.CarryRatingMod      = (int)nbModCarryRating.Value;
            _selectedChar.InitiativeRatingMod = (int)nbModInitiativeRating.Value;
            _selectedChar.DamageBonusMod      = (int)nbModDamageBonus.Value;
            _selectedChar.LuckPointsMod       = (int)nbModLuck.Value;

            updateEverything ();
        }

        /// <summary>
        /// Updates all calculated fields.
        /// </summary>
        private void updateEverything ()
        {
            maxLuckPointsTb.Text = "" + (_selectedChar.MaximumLuckPoints);
            initiativeRatingTb.Text = "" + (_selectedChar.InitiativeRating);
            maxActionPointsTb.Text = "" + (_selectedChar.MaximumAp);
            maxStaminaTb.Text = "" + (_selectedChar.Stamina);
            maxMagickaTb.Text = "" + (_selectedChar.MagickaPool);
            movementRatingTb.Text = "" + (_selectedChar.MovementRating);
            carryRatingTb.Text = "" + (_selectedChar.CarryRating);
            woundThresholdTb.Text = "" + (_selectedChar.WoundThreshold);
            maxHealthTb.Text = "" + (_selectedChar.MaxHealth);
            damageBonusTb.Text = "" + (_selectedChar.DamageBonus);
        }

        /// <summary>
        /// Will disable the skillLevel textbox if a skill roll is not selected, and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillRb_CheckedChanged (object sender, EventArgs e)
        {
            bool isActive = skillRb.Checked;
            skillLevelTb.Enabled = isActive;

            softRoll (sender, e);
        }

        /// <summary>
        /// Will perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicRb_CheckedChanged (object sender, EventArgs e)
        {
            softRoll (sender, e);
        }

        /// <summary>
        /// Rolls against selected parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rollBt_Click (object sender, EventArgs e)
        {
            bool isSkillRoll = skillRb.Checked;

            Random r = new Random ();

            string characteristicName = (string)characteristicCb.SelectedItem;
            int characteristic = _selectedChar._characteristics[characteristicName];

            int result = r.Next (0, 100);
            rollResultTb.Text = "" + result;

            int difference = 0;

            if (isSkillRoll)
            {
                int skillLevel = 0;
                int.TryParse (skillLevelTb.Text, out skillLevel);

                characteristic = (characteristic + (skillLevel * 10));
            }

            difference = (characteristic - result);

            int successes = _selectedChar.GetBonus (difference);

            rollBreakdownTb.Text = String.Format ("{0} - {1} = {2}", result, characteristic, difference);
            rollSuccessesTb.Text = "" + successes;
        }

        /// <summary>
        /// A soft roll performs all of the calculations of a regular roll, but does not change the roll result.
        /// This is useful for using outside roll values with the app, since we don't want to replace the player's
        /// entered roll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void softRoll (object sender, EventArgs e)
        {
            bool isSkillRoll = skillRb.Checked;

            Random r = new Random ();

            string characteristicName = (string)characteristicCb.SelectedItem;
            int characteristic = _selectedChar._characteristics[characteristicName];

            int result = 0;
            if (int.TryParse (rollResultTb.Text, out result))
            {
                int difference = 0;

                if (isSkillRoll)
                {
                    int skillLevel = 0;
                    int.TryParse (skillLevelTb.Text, out skillLevel);

                    characteristic = (characteristic + (skillLevel * 10));
                }

                difference = (characteristic - result);

                int successes = _selectedChar.GetBonus (difference);

                rollBreakdownTb.Text = String.Format ("{0} - {1} = {2}", result, characteristic, difference);
                rollSuccessesTb.Text = "" + successes;
            }
        }
    }
}
