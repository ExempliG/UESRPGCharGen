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

namespace UESRPG_Character_Manager.UI.ActionViews
{
    public partial class ReceivedDamageView : UserControl
    {
        Character _activeCharacter;

        public ReceivedDamageView()
        {
            InitializeComponent();

            hitLocationCb.DataSource = ArmorLocationsData.s_names;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            CharacterController.Instance.AttributeChanged += onAttributeChanged;
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

                updateView();
            }
        }

        private void onAttributeChanged(object sender, EventArgs e)
        {
            updateView();
        }
    }
}
