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
        private List<Character> CharacterList;
        private Character selectedChar;

        public Form1 ()
        {
            InitializeComponent ();
            CharacterList = new List<Character> ();
            selectedChar = new Character ();
            CharacterList.Add (selectedChar);

            foreach (string characteristic in selectedChar.Characteristics.Keys)
            {
                characteristicCb.Items.Add (characteristic);
            }

            characteristicCb.SelectedIndex = 0;
        }

        private void tabPage1_Click (object sender, EventArgs e)
        {

        }

        private void characteristicChanged (object sender, EventArgs e)
        {
            int skill;
            if (int.TryParse (strengthTb.Text, out skill))
            {
                selectedChar.Strength = skill;
            }
            if (int.TryParse (enduranceTb.Text, out skill))
            {
                selectedChar.Endurance = skill;
            }
            if (int.TryParse (agilityTb.Text, out skill))
            {
                selectedChar.Agility = skill;
            }
            if (int.TryParse (intelligenceTb.Text, out skill))
            {
                selectedChar.Intelligence = skill;
            }
            if (int.TryParse (willpowerTb.Text, out skill))
            {
                selectedChar.Willpower = skill;
            }
            if (int.TryParse (perceptionTb.Text, out skill))
            {
                selectedChar.Perception = skill;
            }
            if (int.TryParse (personalityTb.Text, out skill))
            {
                selectedChar.Personality = skill;
            }
            if (int.TryParse (luckTb.Text, out skill))
            {
                selectedChar.Luck = skill;
            }

            updateEverything ();
        }

        private void rollBt_Click (object sender, EventArgs e)
        {
            bool isSkillRoll = skillRb.Checked;

            Random r = new Random ();

            string characteristicName = (string)characteristicCb.SelectedItem;
            int characteristic = selectedChar.Characteristics[characteristicName];

            int result = r.Next (0, 100);
            rollResultTb.Text = "" + result;

            int difference = 0;

            if (isSkillRoll)
            {
                int skillLevel = 0;
                int.TryParse (skillLevelTb.Text, out skillLevel);

                characteristic = (characteristic + (skillLevel * 10));
                //difference = ((characteristic + (skillLevel * 10)) - result);
            }

            difference = (characteristic - result);

            int successes = selectedChar.GetBonus (difference);

            rollBreakdownTb.Text = String.Format("{0} - {1} = {2}", result, characteristic, difference);
            rollSuccessesTb.Text = "" + successes;
        }

        private void skillRb_CheckedChanged (object sender, EventArgs e)
        {
            bool isActive = skillRb.Checked;
            skillLevelTb.Enabled = isActive;

            softRoll (sender, e);
        }

        private void characteristicRb_CheckedChanged (object sender, EventArgs e)
        {
            //bool isActive = characteristicRb.Checked;
            //characteristicCb.Enabled = isActive;
            softRoll (sender, e);
        }

        private void groupBox3_Enter (object sender, EventArgs e)
        {

        }

        private void updateEverything ()
        {
            int mod = 0;
            int.TryParse (luckPointsModTb.Text, out mod);
            maxLuckPointsTb.Text = "" + (selectedChar.MaximumLuckPoints + mod);

            mod = 0;
            int.TryParse (initiativeRatingModTb.Text, out mod);
            initiativeRatingTb.Text = "" + (selectedChar.InitiativeRating + mod);

            mod = 0;
            int.TryParse (actionPointsModTb.Text, out mod);
            maxActionPointsTb.Text = "" + (selectedChar.MaximumAp + mod);

            mod = 0;
            int.TryParse (staminaModTb.Text, out mod);
            maxStaminaTb.Text = "" + (selectedChar.Stamina + mod);

            mod = 0;
            int.TryParse (magickaModTb.Text, out mod);
            maxMagickaTb.Text = "" + (selectedChar.MagickaPool + mod);

            mod = 0;
            int.TryParse (movementRatingModTb.Text, out mod);
            movementRatingTb.Text = "" + (selectedChar.MovementRating + mod);

            mod = 0;
            int.TryParse (carryRatingModTb.Text, out mod);
            carryRatingTb.Text = "" + (selectedChar.CarryRating + mod);

            mod = 0;
            int.TryParse (woundThresholdModTb.Text, out mod);
            woundThresholdTb.Text = "" + (selectedChar.WoundThreshold + mod);

            mod = 0;
            int.TryParse (healthModTb.Text, out mod);
            maxHealthTb.Text = "" + (selectedChar.MaxHealth + mod);

            mod = 0;
            int.TryParse (damageBonusModTb.Text, out mod);
            damageBonusTb.Text = "" + (selectedChar.DamageBonus + mod);
        }

        private void softRoll (object sender, EventArgs e)
        {
            bool isSkillRoll = skillRb.Checked;

            Random r = new Random ();

            string characteristicName = (string)characteristicCb.SelectedItem;
            int characteristic = selectedChar.Characteristics[characteristicName];

            int result = 0;
            if (int.TryParse (rollResultTb.Text, out result))
            {
                int difference = 0;

                if (isSkillRoll)
                {
                    int skillLevel = 0;
                    int.TryParse (skillLevelTb.Text, out skillLevel);

                    characteristic = (characteristic + (skillLevel * 10));
                    //difference = ((characteristic + (skillLevel * 10)) - result);
                }

                difference = (characteristic - result);

                int successes = selectedChar.GetBonus (difference);

                rollBreakdownTb.Text = String.Format ("{0} - {1} = {2}", result, characteristic, difference);
                rollSuccessesTb.Text = "" + successes;
            }
        }

        private void skillLevelTb_TextChanged (object sender, EventArgs e)
        {

        }
    }
}
