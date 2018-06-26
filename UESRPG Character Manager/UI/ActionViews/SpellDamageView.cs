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

namespace UESRPG_Character_Manager.UI.ActionViews
{
    public partial class SpellDamageView : UserControl
    {
        public delegate void SelectedSpellChangedHandler(object sender, EventArgs e);
        [Description("Fires when the selected spell changes.")]
        public event SelectedSpellChangedHandler SelectedSpellChanged;

        uint _activeCharacter;
        bool _hasCharacter;
        public uint SelectorId { get; set; }
        Spell _activeSpell;
        bool _updatingView = false;

        public SpellDamageView()
        {
            InitializeComponent();

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.SpellListChanged += onSpellListChanged;
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

        private void toggleAllControls(bool enabled)
        {
            spellRollBt.Enabled = enabled;
            spellsCb.Enabled = enabled;
        }

        protected void onSpellListChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            if (!_updatingView)
            {
                _updatingView = true;

                if (_hasCharacter)
                {
                    Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                    spellsCb.DataSource = null;
                    if (c.Spells.Count > 0)
                    {
                        spellsCb.DataSource = c.Spells;
                    }
                }
                else
                {
                    spellsCb.DataSource = null;
                }

                _updatingView = false;
            }
        }

        private void spellRollBt_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Spell selectedSpell = (Spell)spellsCb.SelectedItem;
            int resultTotal = 0;
            string breakdownString = "";

            for (int i = 0; i < selectedSpell.NumberOfDice; i++)
            {
                string formatString;

                if (i == selectedSpell.NumberOfDice - 1)
                {
                    formatString = "{0}";
                }
                else
                {
                    formatString = "{0} + ";
                }

                int roll = r.Next(1, selectedSpell.DiceSides);
                breakdownString += string.Format(formatString, roll);
                resultTotal += roll;
            }

            spellResultTb.Text = string.Format("{0} pen {1}", resultTotal, selectedSpell.Penetration);
            spellResultBreakdownTb.Text = breakdownString;
        }

        private void spellsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool allowRoll = false;

            if (spellsCb.Items.Count > 0)
            {
                if (spellsCb.SelectedItem != null && spellsCb.SelectedItem.GetType() == typeof(Spell))
                {
                    _activeSpell = (Spell)spellsCb.SelectedItem;

                    // Set up the skill roll for the user, assuming this event was not triggered in updateDataBindings.
                    // MIGHT BE UNNECESSARY WITH NEW STRUCTURE
                    if (!_updatingView)
                    {
                        onSelectedSpellChanged();
                    }

                    allowRoll = _activeSpell.DoesDamage;
                }
            }

            spellRollBt.Enabled = allowRoll;
        }

        private void onSelectedSpellChanged()
        {
            SelectedSpellChanged?.Invoke(this, new System.EventArgs());
        }

        public Spell GetActiveSpell()
        {
            return _activeSpell;
        }
    }
}
