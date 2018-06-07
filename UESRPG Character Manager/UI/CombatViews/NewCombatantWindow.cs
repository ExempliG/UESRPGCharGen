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
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.UI.CombatViews
{
    public partial class NewCombatantWindow : Form
    {
        private uint _combatId;

        private NewCombatantWindow()
        {
            InitializeComponent();

            characterCb.DataSource = CharacterController.Instance.CharacterList;
        }

        public NewCombatantWindow(uint combatId) : this()
        {
            _combatId = combatId;
        }

        private void npcRb_CheckedChanged(object sender, EventArgs e)
        {
            characterCb.Enabled = characterRb.Checked;
        }

        private void characterRb_CheckedChanged(object sender, EventArgs e)
        {
            characterCb.Enabled = characterRb.Checked;
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            if (npcRb.Checked)
            {
                RemoteCombatant rc = new RemoteCombatant();
                GameController.Instance.AddCombatant(_combatId, rc);
            }
            else
            {
                Character c = (Character)characterCb.SelectedItem;
                GameController.Instance.AddCombatant(_combatId, c);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
