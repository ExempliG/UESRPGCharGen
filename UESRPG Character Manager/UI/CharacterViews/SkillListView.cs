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

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class SkillListView : UserControl
    {
        public delegate void SkillListChangedHandler(object sender, EventArgs e);
        [Description("Fires when a skill is added, removed, or edited.")]
        public event SkillListChangedHandler SkillListChanged;

        private Character _activeCharacter;

        public SkillListView()
        {
            InitializeComponent();

            skillsDgv.SelectionChanged += skillsDgv_SelectionChanged;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;

            updateView();
        }

        protected void onSkillListChanged()
        {
            SkillListChanged?.Invoke(this, new System.EventArgs());
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
                _activeCharacter.Skills.Add(newSkill);
            }

            updateView();
            onSkillListChanged();
        }

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
            onSkillListChanged();
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
