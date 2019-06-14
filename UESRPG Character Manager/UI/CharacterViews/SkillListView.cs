using System;
using System.ComponentModel;
using System.Windows.Forms;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class SkillListView : SelectedCharacterControl
    {
        public SkillListView()
        {
            InitializeComponent();

            skillsDgv.SelectionChanged += skillsDgv_SelectionChanged;
            aspectsToWatch.Add( CharacterAspect.SKILL );
        }

        public delegate void SelectedSkill(object sender, int skillIndex);
        [Description("Fires when a skill has been selected via use of this SkillListView.")]
        public event SelectedSkill OnSelectedSkill;
        
        protected void onSelectedSkill(int skillIndex)
        {
            OnSelectedSkill?.Invoke(this, skillIndex);
        }

        protected override void updateView()
        {
            if (_selector.HasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
                skillsDgv.DataSource = null;
                if (c.Skills.Count > 0)
                {
                    skillsDgv.DataSource = c.Skills;
                }
            }
        }

        protected override void toggleAllControls(bool enabled)
        {
            if(!enabled)
            {
                skillsDgv.DataSource = null;
            }
            addSkillBt.Enabled = enabled;
            editSkillBt.Enabled = enabled;
        }

        private void addSkillBt_Click(object sender, EventArgs e)
        {
            EditSkill es = new EditSkill();
            es.ShowDialog();

            if (es.GetSkill(out Skill newSkill))
            {
                CharacterController.Instance.AddSkill(_selector.GetCharacterGuid(), newSkill);
            }
        }

        private void editSkillBt_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
                int selectedIndex = theRows[0].Index;
                EditSkill es = new EditSkill(c.Guid, c.Skills[selectedIndex]);
                es.ShowDialog();

                if ( es.GetSkill( out Skill newSkill ) )
                {
                    CharacterController.Instance.EditSkill( _selector.GetCharacterGuid(), newSkill );
                }
            }

            updateView();
        }

        private void skillsDgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
                int selectedIndex = theRows[0].Index;
                Skill selectedSkill = c.Skills[selectedIndex];
                bool canEdit = !(selectedSkill.isDefaultSkill);

                editSkillBt.Enabled = canEdit;
                onSelectedSkill(selectedIndex);
            }
            else
            {
                editSkillBt.Enabled = false;
            }
        }
    }
}
