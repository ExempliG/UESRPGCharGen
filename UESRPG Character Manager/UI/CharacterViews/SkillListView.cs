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

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class SkillListView : UserControl
    {
        private Character _activeCharacter;

        public SkillListView()
        {
            InitializeComponent();

            skillsDgv.SelectionChanged += skillsDgv_SelectionChanged;

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

        private void updateView()
        {
            skillsDgv.DataSource = null;
            if (_activeCharacter.Skills.Count > 0)
            {
                skillsDgv.DataSource = _activeCharacter.Skills;
            }
        }

        private void addSkillBt_Click(object sender, EventArgs e)
        {
            EditSkill es = new EditSkill();
            es.ShowDialog();

            if (es.GetSkill(out Skill newSkill))
            {
                CharacterController.Instance.AddSkill(newSkill);
            }
        }

        /// <todo>Do this properly so that it must go through the CharacterController to achieve the skill change.</todo>
        private void editSkillBt_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                int selectedIndex = theRows[0].Index;
                EditSkill es = new EditSkill(_activeCharacter.Skills[selectedIndex]);
                es.ShowDialog();
            }

            updateView();
        }

        private void skillsDgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                int selectedIndex = theRows[0].Index;
                bool canEdit = !(_activeCharacter.Skills[selectedIndex].isDefaultSkill);

                editSkillBt.Enabled = canEdit;
            }
            else
            {
                editSkillBt.Enabled = false;
            }
        }
    }
}
