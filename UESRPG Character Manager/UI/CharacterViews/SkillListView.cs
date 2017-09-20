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

            this.skillsDgv.SelectionChanged += skillsDgv_SelectionChanged;
        }

        public void OnSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();

            UpdateView();
        }

        protected void OnSkillListChanged()
        {
            SkillListChanged?.Invoke(this, new System.EventArgs());
        }

        private void UpdateView()
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

            Skill newSkill;
            if (es.GetSkill(out newSkill))
            {
                _activeCharacter.Skills.Add(newSkill);
            }

            UpdateView();
        }

        private void editSkillBt_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                int selectedIndex = theRows[0].Index;
                EditSkill es = new EditSkill(_activeCharacter.Skills[selectedIndex]);
                es.Show();
            }

            UpdateView();
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
