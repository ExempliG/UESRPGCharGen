using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;

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
            Spell s = new Spell()
            {
                Name = spellNameTb.Text,
                Cost = (int)costNud.Value,
                Difficulty = (int)difficultyNud.Value,
                Level = (int)spellLevelNud.Value,
                AssociatedSkill = ((Skill)associatedSkillCb.SelectedItem).Name,
                Description = spellDescriptionRtb.Text,
                DoesDamage = damageCb.Checked
            };
            if (s.DoesDamage)
            {
                s.NumberOfDice = (int)numberOfDiceNud.Value;
                s.DiceSides = (int)diceSidesNud.Value;
                s.Penetration = (int)penNud.Value;
            }
            CharacterController.Instance.AddSpell(s);
            Close ();
        }

        private void cancelBt_Click (object sender, EventArgs e)
        {
            Close ();
        }
    }
}
