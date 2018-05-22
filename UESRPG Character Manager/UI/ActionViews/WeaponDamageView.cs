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
    public partial class WeaponDamageView : UserControl
    {
        Character _activeCharacter;

        public WeaponDamageView()
        {
            InitializeComponent();

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.WeaponsChanged += onWeaponsChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;

            updateView();
        }

        protected void onWeaponsChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            weaponCb.DataSource = null;
            if (_activeCharacter.Weapons.Count > 0)
            {
                weaponCb.DataSource = _activeCharacter.Weapons;
            }
        }

        private void weaponRollBt_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Weapon selectedWeapon = (Weapon)weaponCb.SelectedItem;
            int resultTotal = 0;
            string breakdownString = "";

            for (int i = 0; i < selectedWeapon.NumberOfDice; i++)
            {
                int roll = r.Next(1, selectedWeapon.DiceSides);
                breakdownString += string.Format("{0} + ", roll);
                resultTotal += roll;
            }

            breakdownString += string.Format("{0} + bonus {1}", selectedWeapon.DamageMod, _activeCharacter.DamageBonus);
            resultTotal += selectedWeapon.DamageMod;
            resultTotal += _activeCharacter.DamageBonus;

            weaponResultTb.Text = string.Format("{0} pen {1}", resultTotal, selectedWeapon.Penetration);
            weaponResultBreakdownTb.Text = breakdownString;
        }

        private void weaponCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weaponCb.SelectedIndex > -1 && weaponCb.SelectedItem.GetType() == typeof(Weapon))
            {
                weaponRollBt.Enabled = true;
            }
            else
            {
                weaponRollBt.Enabled = false;
            }
        }
    }
}
