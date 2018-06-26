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
using UESRPG_Character_Manager.GameComponents;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.CombatViews
{
    public partial class CombatWindow : Form
    {
        private uint _activeCharacter;
        private bool _hasCharacter;
        private uint _combatId;
        public uint SelectorId { get; set; }

        public CombatWindow()
        {
            InitializeComponent();
            _hasCharacter = false;
        }

        public CombatWindow( uint combatId ) : this()
        {
            _combatId = combatId;
            combatantsListView._combatId = _combatId;

            SelectorId = combatantsListView.SelectorId;
            weaponDamageView.SelectorId = SelectorId;
            checkRollView.SelectorId = SelectorId;
            spellDamageView.SelectorId = SelectorId;
            characterHealthView.SelectorId = SelectorId;
            receivedDamageView.SelectorId = SelectorId;

            this.FormClosed += onClosed;
        }

        protected void onClosed(object sender, EventArgs e)
        {
            GameController.Instance.EndCombat(_combatId);
            CharacterController.Instance.EndSelector(SelectorId);
        }

        private void actBt_Click(object sender, EventArgs e)
        {
            GameController.Instance.StepCombat(_combatId, true);
        }

        private void passBt_Click(object sender, EventArgs e)
        {
            GameController.Instance.StepCombat(_combatId, false);
        }

        private void newRoundBt_Click(object sender, EventArgs e)
        {
            GameController.Instance.NewRound(_combatId);
        }
    }
}
