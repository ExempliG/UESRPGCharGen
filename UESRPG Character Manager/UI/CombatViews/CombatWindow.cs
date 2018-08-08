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
            weaponDamageView_action.SelectorId = SelectorId;
            weaponDamageView_reaction.SelectorId = SelectorId;
            checkRollView_action.SelectorId = SelectorId;
            checkRollView_reaction.SelectorId = SelectorId;
            spellDamageView_action.SelectorId = SelectorId;
            characterHealthView.SelectorId = SelectorId;
            receivedDamageView_reaction.SelectorId = SelectorId;

            this.FormClosed += onClosed;
            this.Shown += onShown;
            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            GameController.Instance.ActiveCombatsChanged += onActiveCombatsChanged;
        }

        protected void onSelectedCharacterChanged(object sender, SelectedCharacterChangedEventArgs e)
        {
        }

        protected void onActiveCombatsChanged(object sender, ActiveCombatsChangedEventArgs e)
        {
            switch(e.EventType)
            {
                case ActiveCombatsChangedEvent.ENDED_COMBAT:
                    if(e.CombatId == _combatId)
                    {
                        Close();
                    }
                    break;
                case ActiveCombatsChangedEvent.END_ALL_COMBATS:
                    Close();
                    break;
                case ActiveCombatsChangedEvent.NEW_COMBAT:
                    // do nothing
                    break;
                case ActiveCombatsChangedEvent.NEW_DICT:
                    // do nothing
                    break;
                default:
                    throw new ArgumentOutOfRangeException("e.EventType", "todo: You stink");
            }
        }

        protected void onClosed(object sender, EventArgs e)
        {
            // The combat may have already ended!
            if (GameController.Instance.CombatIsActive(_combatId))
            {
                GameController.Instance.EndCombat(_combatId);
            }
            CharacterController.Instance.EndSelector(SelectorId);
        }

        protected void onShown(object sender, EventArgs e)
        {
            combatantsListView.UpdateView();
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
