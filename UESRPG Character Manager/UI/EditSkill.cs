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
    public partial class EditSkill : Form
    {
        private Character _character;

        public EditSkill (Character character)
        {
            InitializeComponent ();

            _character = character;

            skillCharacteristicsClb.Sorted = false;
            foreach (string characteristic in Characteristics.CharacteristicNames)
            {
                skillCharacteristicsClb.Items.Add (characteristic);
            }
        }

        private void confirmBt_Click (object sender, EventArgs e)
        {
            Skill s = new Skill ();
            s.Name = skillNameTb.Text;
            s.Characteristics = new int[skillCharacteristicsClb.CheckedIndices.Count];
            for (int i = 0; i < s.Characteristics.Length; i++)
            {
                s.Characteristics[i] = skillCharacteristicsClb.CheckedIndices[i];
            }
            s.Description = skillDescriptionRtb.Text;
            s.Rank = (int)skillRankNud.Value;

            _character.Skills.Add (s);

            Close ();
        }

        private void cancelBt_Click (object sender, EventArgs e)
        {
            Close ();
        }
    }
}
