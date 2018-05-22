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
    public partial class EditSkill : Form
    {
        private Skill _skill;

        public EditSkill ( )
        {
            InitializeComponent ();

            // Don't allow the user to delete a skill that doesn't exist
            deleteBt.Enabled = false;

            _skill = new Skill();

            skillCharacteristicsClb.Sorted = false;
            foreach (string characteristic in Characteristics.s_characteristicNames)
            {
                skillCharacteristicsClb.Items.Add (characteristic);
            }
        }

        public EditSkill (Skill skill)
        {
            InitializeComponent();

            _skill = (Skill)skill.Clone();

            skillCharacteristicsClb.Sorted = false;
            foreach (string characteristic in Characteristics.s_characteristicNames)
            {
                skillCharacteristicsClb.Items.Add(characteristic);
            }

            skillNameTb.Text = _skill.Name;
            for (int i = 0; i < _skill.Characteristics.Length; i++)
            {
                int characteristicIndex = _skill.Characteristics[i];
                skillCharacteristicsClb.SetItemChecked(characteristicIndex, true);
            }
            skillRankNud.Value = _skill.Rank;

            skillDescriptionRtb.Text = _skill.Description;
        }

        public bool GetSkill(out Skill theSkill)
        {
            bool result = false;

            if(DialogResult == DialogResult.OK)
            {
                result = true;
                theSkill = _skill;
            }
            else
            {
                theSkill = null;
            }

            return result;
        }

        private void confirmBt_Click (object sender, EventArgs e)
        {
            _skill.Name = skillNameTb.Text;
            _skill.Characteristics = new int[skillCharacteristicsClb.CheckedIndices.Count];
            for (int i = 0; i < _skill.Characteristics.Length; i++)
            {
                _skill.Characteristics[i] = skillCharacteristicsClb.CheckedIndices[i];
            }
            _skill.Description = skillDescriptionRtb.Text;
            _skill.Rank = (int)skillRankNud.Value;

            CharacterController.Instance.EditSkill(_skill);

            DialogResult = DialogResult.OK;

            Close ();
        }

        private void cancelBt_Click (object sender, EventArgs e)
        {
            Close ();
        }

        private void deleteBt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                                                  string.Format("Are you sure you wish to delete the skill \"{0}\"?", skillNameTb.Text),
                                                  "Warning!",
                                                  MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                CharacterController.Instance.DeleteSkill(_skill);
                MessageBox.Show("Skill deleted!");

                Close();
            }
        }
    }
}
