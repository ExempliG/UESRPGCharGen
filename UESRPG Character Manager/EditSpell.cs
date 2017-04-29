using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UESRPG_Character_Manager
{
    public partial class EditSpell : Form
    {
        private Character _selectedChar;

        public EditSpell (Character selectedChar)
        {
            InitializeComponent ();
            _selectedChar = selectedChar;

            foreach (Skill s in _selectedChar.Skills)
            {
                associatedSkillCb.Items.Add (s);
            }
        }

        private void damageCb_CheckedChanged (object sender, EventArgs e)
        {
            numberOfDiceNud.Enabled = damageCb.Checked;
            diceSidesNud.Enabled = damageCb.Checked;
            penNud.Enabled = damageCb.Checked;
        }

        private void confirmBt_Click (object sender, EventArgs e)
        {
            Spell s = new Spell ();
            s.Name = spellNameTb.Text;
            s.Cost = (int)costNud.Value;
            s.Difficulty = (int)difficultyNud.Value;
            s.Level = (int)spellLevelNud.Value;
            s.AssociatedSkill = ((Skill)associatedSkillCb.SelectedItem).Name;
            s.Description = spellDescriptionRtb.Text;
            s.DoesDamage = damageCb.Checked;
            if (s.DoesDamage)
            {
                s.NumberOfDice = (int)numberOfDiceNud.Value;
                s.DiceSides = (int)diceSidesNud.Value;
                s.Penetration = (int)penNud.Value;
            }
            _selectedChar.Spells.Add (s);
            Close ();
        }

        private void cancelBt_Click (object sender, EventArgs e)
        {
            Close ();
        }
    }
}
