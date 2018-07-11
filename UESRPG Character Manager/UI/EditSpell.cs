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
        private Spell _spell;
        private bool _isNewSpell;

        public EditSpell (Character selectedChar)
        {
            InitializeComponent ();
            _selectedChar = selectedChar;

            foreach (Skill s in _selectedChar.Skills)
            {
                associatedSkillCb.Items.Add (s);
            }

            _spell = new Spell();
            _isNewSpell = true;
        }

        public EditSpell (Character selectedChar, Spell spellToEdit) : this(selectedChar)
        {
            _isNewSpell = false;

            _spell = (Spell)spellToEdit.Clone();

            spellNameTb.Text = _spell.Name;
            costNud.Value = _spell.Cost;
            difficultyNud.Value = _spell.Difficulty;
            spellLevelNud.Value = _spell.Level;
            spellDescriptionRtb.Text = _spell.Description;

            IEnumerable<Skill> associatedSkills = from s in selectedChar.Skills
                                                  where s.Name == _spell.AssociatedSkill
                                                  select s;
            if(associatedSkills.Count() == 1)
            {
                int cbIndex = associatedSkillCb.Items.IndexOf(associatedSkills.ElementAt(0));
                associatedSkillCb.SelectedIndex = cbIndex;
            }

            damageCb.Checked = _spell.DoesDamage;

            if(_spell.DoesDamage)
            {
                numberOfDiceNud.Value = _spell.NumberOfDice;
                diceSidesNud.Value = _spell.DiceSides;
                penNud.Value = _spell.Penetration;
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
            _spell.Name = spellNameTb.Text;
            _spell.Cost = (int)costNud.Value;
            _spell.Difficulty = (int)difficultyNud.Value;
            _spell.Level = (int)spellLevelNud.Value;
            _spell.AssociatedSkill = ((Skill)associatedSkillCb.SelectedItem).Name;
            _spell.Description = spellDescriptionRtb.Text;

            _spell.DoesDamage = damageCb.Checked;
            if (_spell.DoesDamage)
            {
                _spell.NumberOfDice = (int)numberOfDiceNud.Value;
                _spell.DiceSides = (int)diceSidesNud.Value;
                _spell.Penetration = (int)penNud.Value;
            }

            if (_isNewSpell)
            {
                CharacterController.Instance.AddSpell(_selectedChar.Id, _spell);
            }
            else
            {
                CharacterController.Instance.EditSpell(_selectedChar.Id, _spell);
            }
            Close ();
        }

        private void cancelBt_Click (object sender, EventArgs e)
        {
            Close ();
        }
    }
}
