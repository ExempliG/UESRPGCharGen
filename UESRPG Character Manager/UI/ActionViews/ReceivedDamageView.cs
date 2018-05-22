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
using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.ActionViews
{
    public partial class ReceivedDamageView : UserControl
    {
        private string[] _woundsText = new string[]
        {
            "",
            "Minor wound (Wound Treshold trauma or greater)\n" +
            "Shock Eﬀects\n" +
            "•  The character must pass a +30 Endurance test or lose an\n" +
            "action point. If they have none remaining, they begin the\n" +
            "next round with one less.\n" +
            "Passive Eﬀects\n" +
            "•  The character suﬀers a -5 penalty to all tests and a -1 to all\n" +
            "future initiative rolls while they have this wound.",

            "Major wound (2*Wound Treshold trauma or greater)\n" +
            "Shock Eﬀects\n" +
            "•  The character must pass a +10 Endurance test or lose an\n" +
            "action point. If they have none remaining, they begin the\n" +
            "next round with one less.\n" +
            "•  If the wound is to a limb, the character falls prone (leg),\n" +
            "drops item held (arm), or is stunned for one round (head).\n" +
            "Passive Eﬀects\n" +
            "•  The character suﬀers a -10 penalty to all tests and a -2 to\n" +
            "all future initiative rolls while they have this wound.\n" +
            "Lingering Eﬀects\n" +
            "•  The character gains the blood loss (1d5-3, min 1) condition",

            "Crippling wound (3*Wound Treshold trauma or greater)\n" +
            "Shock Eﬀects\n" +
            "•  The character must pass a -10 Endurance test or suﬀer\n" +
            "the lost body part condition as is appropriate for the hit\n" +
            "location.\n" +
            "•  If the wound is to a limb, the character falls prone (leg),\n" +
            "drops item held (arm), or is stunned for one round (head).\n" +
            "•  The character loses an action point. If they have none\n" +
            "remaining, they begin the next round with one less.\n" +
            "Passive Eﬀects\n" +
            "•  The character suﬀers a -20 penalty to all tests and a -3 to\n" +
            "all future initiative rolls while they have this wound.\n" +
            "Lingering Eﬀects\n" +
            "•  The character gains the blood loss (1d5-2, min 1) and crippled\n" +
            "body part (for the appropriate hit location) conditions.",

            "Severe wound (4*Wound Treshold trauma or greater)\n" +
            "Shock Eﬀects\n" +
            "•  The character must pass a -30 Endurance test or fall unconscious\n" +
            "for rounds equal to their degrees of failure.\n" +
            "•  The character suﬀers the lost body part condition as is\n" +
            "appropriate for the hit location.\n" +
            "•  The character loses an action point. If they have none\n" +
            "remaining, they begin the next round with one less.\n" +
            "Passive Eﬀects\n" +
            "•  The character suﬀers a -40 penalty to all tests and a -4 to\n" +
            "all future initiative rolls while they have this wound.\n" +
            "Lingering Eﬀects\n" +
            "•  The character gains the blood loss (1d5) condition."
        };

        Character _activeCharacter;

        public ReceivedDamageView()
        {
            InitializeComponent();

            hitLocationCb.DataSource = ArmorLocationsData.s_names;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.AttributeChanged += onAttributeChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;

            updateView();
        }

        public void OnCurrentHealthChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            healthLb.Text = string.Format( "Health: {0}", _activeCharacter.CurrentHealth );
        }

        private void receivedDamageTb_TextChanged(object sender, EventArgs e)
        {
            updateDamage();
        }

        private void receivedPenTb_TextChanged(object sender, EventArgs e)
        {
            updateDamage();
        }

        private void hitLocationCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDamage();
        }

        /// <summary>
        /// Calculate the total damage received to a particular location.
        /// </summary>
        private void updateDamage()
        {
            ArmorLocations location = (ArmorLocations)hitLocationCb.SelectedIndex;

            if (int.TryParse(receivedDamageTb.Text, out int damage) &&
                int.TryParse(receivedPenTb.Text, out int pen) &&
                _activeCharacter != null)
            {
                Armor selectedPiece = _activeCharacter.GetArmorPiece(location);
                double armorMitigation = (selectedPiece != null) ? selectedPiece.AR : 0;
                armorMitigation = Math.Max(armorMitigation - pen, 0);                 // Pen reduces armorMitigation to a lower limit of zero.
                damage = Math.Max(damage - (int)armorMitigation, 0);                  // armorMitigation then reduces received damage to a lower limit of zero.

                finalDamageReceivedTb.Text = damage.ToString();
            }
        }

        private void applyDamageBt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(finalDamageReceivedTb.Text, out int damage))
            {
                CharacterController.Instance.ChangeHealth(_activeCharacter.CurrentHealth - damage);

                int woundLevel = damage / CharacterController.Instance.ActiveCharacter.WoundThreshold;
                if (woundLevel > 0)
                {
                    MessageBox.Show(_woundsText[woundLevel]);
                }

                updateView();
            }
        }

        private void onAttributeChanged(object sender, EventArgs e)
        {
            updateView();
        }
    }
}
