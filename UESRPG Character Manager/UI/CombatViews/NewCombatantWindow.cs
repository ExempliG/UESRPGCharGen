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

            List<Character> charList = new List<Character>();
            foreach(Character c in CharacterController.Instance.CharacterDict.Values)
            {
                charList.Add(c);
            }

            characterCb.DataSource = charList;
        }

        public NewCombatantWindow(uint combatId) : this()
        {
            _combatId = combatId;
        }

        private void npcRb_CheckedChanged(object sender, EventArgs e)
        {
            charOrNpcUpdate();
        }

        private void characterRb_CheckedChanged(object sender, EventArgs e)
        {
            charOrNpcUpdate();
        }

        private void charOrNpcUpdate()
        {
            characterCb.Enabled = characterRb.Checked;
            npcNameTb.Enabled = npcRb.Checked;

            okBt.Enabled = (characterCb.SelectedIndex >= 0);
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            if (npcRb.Checked)
            {
                RemoteCombatant rc = new RemoteCombatant();
                rc.Name = npcNameTb.Text;
                GameController.Instance.AddCombatant(_combatId, rc);
            }
            else
            {
                Character c = (Character)characterCb.SelectedItem;
                Random r = new Random();
                c.Initiative = (uint)(r.Next(1, 10) + c.InitiativeRating);
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

        private void characterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                okBt.Enabled = true;
            }
            else
            {
                okBt.Enabled = false;
            }
        }
    }
}
