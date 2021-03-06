﻿using System;
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

namespace UESRPG_Character_Manager.UI.ActionViews
{
    public partial class CheckRollView : UserControl
    {
        private Character _activeCharacter;

        public CheckRollView()
        {
            InitializeComponent();

            rollResultTb.TextChanged += softRoll;

            foreach (string characteristic in Characteristics.s_characteristicNames)
            {
                characteristicCb.Items.Add(characteristic);
            }

            characteristicCb.SelectedIndex = 0;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.SkillListChanged += onSkillListChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;

            updateView();
        }

        protected void onSkillListChanged(object sender, EventArgs e)
        {
            updateView();
        }

        public void OnSelectedSpellChanged(object sender, EventArgs e)
        {
            Spell activeSpell = ((SpellDamageView)sender).GetActiveSpell();

            skillRb.Checked = true;
            IEnumerable<Skill> skillSearch = from skill in _activeCharacter.Skills
                                             where skill.Name == activeSpell.AssociatedSkill
                                             select skill;
            if (skillSearch.Count() == 1)
            {
                int skillIndex = skillsCb.Items.IndexOf(skillSearch.ElementAt(0));
                skillsCb.SelectedIndex = skillIndex;
                extraDifficultyNud.Value = activeSpell.Difficulty;
            }
        }

        private void updateView()
        {
            int selectedIndex = skillsCb.SelectedIndex;
            skillsCb.Items.Clear();

            for (int i = 0; i < _activeCharacter.Skills.Count; i++)
            {
                Skill skill = _activeCharacter.Skills[i];
                skillsCb.Items.Add(skill);
            }
            if (selectedIndex < skillsCb.Items.Count && selectedIndex != -1)
            {
                skillsCb.SelectedIndex = selectedIndex;
            }
            else if (skillsCb.Items.Count >= 1)
            {
                skillsCb.SelectedIndex = 0;
            }
            else
            {
                // do nothing
            }
        }

        /// <summary>
        /// A soft roll performs all of the calculations of a regular roll, but does not change the roll result.
        /// This is useful for using outside roll values with the app, since we don't want to replace the player's
        /// entered roll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void softRoll(object sender, EventArgs e)
        {
            int extraDifficulty = (int)extraDifficultyNud.Value;
            softRoll(sender, e, extraDifficulty);
        }

        /// <summary>
        /// A soft roll performs all of the calculations of a regular roll, but does not change the roll result.
        /// This is useful for using outside roll values with the app, since we don't want to replace the player's
        /// entered roll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <todo> This functionality should mostly be contained within GameController.</todo>
        private void softRoll(object sender, EventArgs e, int extraDifficulty)
        {
            bool isSkillRoll = skillRb.Checked;
            bool success = true;

            if (int.TryParse(rollResultTb.Text, out int result))
            {
                updateCriticalLabel(result);
                updateHitLocationLabel(result);

                int difference = 0;

                int characteristicIndex = 0;
                int characteristic = 0;

                if (isSkillRoll)
                {
                    if (skillsCb.Items.Count >= 1)
                    {
                        Skill skill = (Skill)skillsCb.SelectedItem;

                        characteristicIndex = skill.Characteristics[characteristicCb.SelectedIndex];
                        characteristic = _activeCharacter.GetCharacteristic(characteristicIndex);

                        int skillLevel = skill.Rank;
                        rollBreakdownTb.Text = string.Format("({0} + skill {1} + diff {2}) - {3} =",
                                                             characteristic,
                                                             skillLevel * 10,
                                                             extraDifficulty,
                                                             result);
                        characteristic = (characteristic + (skillLevel * 10) + extraDifficulty);
                    }
                    else
                    {
                        success = false;
                    }
                }
                else   // Otherwise it's a Characteristic roll
                {
                    characteristicIndex = characteristicCb.SelectedIndex;
                    characteristic = _activeCharacter.GetCharacteristic(characteristicIndex);
                    rollBreakdownTb.Text = string.Format("({0} + diff {1}) - {2} =",
                                                         characteristic,
                                                         extraDifficulty,
                                                         result);
                    characteristic += extraDifficulty;
                }

                if (success)
                {
                    difference = (characteristic - result);

                    int successes = _activeCharacter.GetBonus(difference);

                    rollBreakdownTb.Text += String.Format("{0}", difference);
                    rollSuccessesTb.Text = "" + successes;
                }
                else
                {
                    rollBreakdownTb.Text = "No skill selected!";
                }
            }
        }

        /// <summary>
        /// Will update the "Critical" label for a given rollResult based on the currently-selected Character.
        /// </summary>
        /// <param name="rollResult">The roll result used to update.</param>
        private void updateCriticalLabel(int rollResult)
        {
            int luck = _activeCharacter.Luck;
            if (rollResult <= _activeCharacter.GetBonus(luck))
            {
                successOrFailLb.Text = "Critical success!";
                successOrFailLb.Visible = true;
            }
            else if (rollResult >= (95 + _activeCharacter.GetBonus(luck)))
            {
                successOrFailLb.Text = "Critical failure!";
                successOrFailLb.Visible = true;
            }
            else
            {
                successOrFailLb.Visible = false;
            }
        }

        private void updateHitLocationLabel(int rollResult)
        {
            int tensDigit = (rollResult / 10);
            int tensComponent = tensDigit * 10;
            int onesComponent = rollResult - tensComponent;

            if (onesComponent == 0)
            {
                hitLocationLb.Text = "Head!";
            }
            else if (onesComponent >= 1 && onesComponent <= 2)
            {
                hitLocationLb.Text = "Right Arm!";
            }
            else if (onesComponent >= 3 && onesComponent <= 4)
            {
                hitLocationLb.Text = "Left Arm!";
            }
            else if (onesComponent >= 5 && onesComponent <= 7)
            {
                hitLocationLb.Text = "Body!";
            }
            else if (onesComponent == 8)
            {
                hitLocationLb.Text = "Right Leg!";
            }
            else if (onesComponent == 9)
            {
                hitLocationLb.Text = "Left Leg!";
            }
            hitLocationLb.Visible = true;
        }

        /// <summary>
        /// Will filter the Characteristic combobox for the selected skill and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillRb_CheckedChanged(object sender, EventArgs e)
        {
            updateCharacteristicCb();
            extraDifficultyNud.Value = 0;

            softRoll(sender, e);
        }

        /// <summary>
        /// Will filter the Characteristic combobox for the selected skill and perform a soft roll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void characteristicRb_CheckedChanged(object sender, EventArgs e)
        {
            updateCharacteristicCb();
            extraDifficultyNud.Value = 0;

            softRoll(sender, e);
        }

        /// <summary>
        /// Rolls against selected parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="extraDifficulty">An extra difficulty modifier, in case a particular check is harder or easier</param>
        private void rollBt_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            int result = r.Next(1, 100);
            rollResultTb.Text = "" + result;

            softRoll(sender, e);
        }

        /// <summary>
        /// This function will determine which Characteristics govern the selected skill and remove all other Characteristics from the Characteristic CB.
        /// </summary>
        private void updateCharacteristicCb()
        {
            object selectedItem = skillsCb.SelectedItem;
            if (selectedItem != null && skillRb.Checked)
            {
                Skill skill = (Skill)selectedItem;
                characteristicCb.Items.Clear();
                foreach (int characteristic in skill.Characteristics)
                {
                    characteristicCb.Items.Add(Characteristics.s_characteristicNames[characteristic]);
                }
                if (characteristicCb.Items.Count > 0)
                {
                    characteristicCb.SelectedIndex = 0;
                }
            }
            else
            {
                reloadCharacteristicCb();
            }
        }

        /// <summary>
        /// Restores the Characteristics CB to include all Characteristics.
        /// </summary>
        private void reloadCharacteristicCb()
        {
            characteristicCb.Items.Clear();
            foreach (string characteristic in Characteristics.s_characteristicNames)
            {
                characteristicCb.Items.Add(characteristic);
            }
            characteristicCb.SelectedIndex = 0;
        }

        private void characteristicCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            softRoll(sender, e);
        }

        private void skillsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skillRb.Checked)
            {
                updateCharacteristicCb();
            }
        }

        private void rollResultTb_TextChanged(object sender, EventArgs e)
        {
            softRoll(sender, e);
        }

        private void extraDifficultyNud_ValueChanged(object sender, EventArgs e)
        {
            softRoll(sender, e);
        }
    }
}
