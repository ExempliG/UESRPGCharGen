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
        private uint _activeCharacter;
        private bool _hasCharacter;
        public uint SelectorId { get; set; }

        public SkillListView()
        {
            InitializeComponent();

            skillsDgv.SelectionChanged += skillsDgv_SelectionChanged;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.SkillListChanged += onSkillListChanged;
        }

        protected void onSelectedCharacterChanged(object sender, SelectedCharacterChangedEventArgs e)
        {
            if (e.SelectorId == SelectorId)
            {
                switch (e.EventType)
                {
                    case CharacterSelectionEvent.NEW_CHARACTER:
                        _activeCharacter = e.CharacterId;
                        _hasCharacter = true;
                        break;
                    case CharacterSelectionEvent.NO_CHARACTER:
                        _hasCharacter = false;
                        break;
                    case CharacterSelectionEvent.SAME_CHARACTER:
                        break;

                }

                toggleAllControls(_hasCharacter);

                updateView();
            }
        }

        protected void onSkillListChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                skillsDgv.DataSource = null;
                if (c.Skills.Count > 0)
                {
                    skillsDgv.DataSource = c.Skills;
                }
            }
        }

        private void toggleAllControls(bool enabled)
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
                CharacterController.Instance.AddSkill(_activeCharacter, newSkill);
            }
        }

        /// <todo>Do this properly so that it must go through the CharacterController to achieve the skill change.</todo>
        private void editSkillBt_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                int selectedIndex = theRows[0].Index;
                EditSkill es = new EditSkill(c.Id, c.Skills[selectedIndex]);
                es.ShowDialog();
            }

            updateView();
        }

        private void skillsDgv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection theRows = skillsDgv.SelectedRows;
            if (theRows.Count == 1)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                int selectedIndex = theRows[0].Index;
                bool canEdit = !(c.Skills[selectedIndex].isDefaultSkill);

                editSkillBt.Enabled = canEdit;
            }
            else
            {
                editSkillBt.Enabled = false;
            }
        }
    }
}
