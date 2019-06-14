using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.UI.CharacterViews;
using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.ActionViews
{
    public partial class SpellDamageView : SelectedCharacterControl
    {
        public delegate void SelectedSpellChangedHandler(object sender, int spellIndex);
        [Description("Fires when the selected spell changes.")]
        public event SelectedSpellChangedHandler SelectedSpellChanged;

        Spell _activeSpell;
        bool _updatingView = false;

        public SpellDamageView()
        {
            InitializeComponent();

            toggleAllControls(false);
            aspectsToWatch.Add( CharacterAspect.SPELL );
        }

        protected override void toggleAllControls(bool enabled)
        {
            if(!enabled)
            {
                spellResultBreakdownTb.Clear();
                spellResultTb.Clear();
            }
            spellRollBt.Enabled = enabled;
            spellsCb.Enabled = enabled;
            spellResultBreakdownTb.Enabled = enabled;
            spellResultTb.Enabled = enabled;
        }

        protected void onSpellListChanged(object sender, EventArgs e)
        {
            updateView();
        }

        protected override void updateView()
        {
            if (!_updatingView)
            {
                _updatingView = true;

                if (_selector.HasCharacter)
                {
                    Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
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
                        onSelectedSpellChanged(spellsCb.SelectedIndex);
                    }

                    allowRoll = _activeSpell.DoesDamage;
                }
            }

            spellRollBt.Enabled = allowRoll;
        }

        private void onSelectedSpellChanged(int spellIndex)
        {
            SelectedSpellChanged?.Invoke(this, spellIndex);
        }

        public Spell GetActiveSpell()
        {
            return _activeSpell;
        }
    }
}
