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
using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.ActionViews
{
    public partial class WeaponDamageView : SelectedCharacterControl
    {
        public WeaponDamageView()
        {
            InitializeComponent();

            for(int i = 0; i < (int)WeaponMaterial.MAX; i++)
            {
                ammoCb.Items.Add((WeaponMaterial)i);
            }
            ammoCb.SelectedIndex = 0;

            toggleAllControls(false);
            aspectsToWatch.Add( CharacterAspect.EQUIPMENT_WEAPON );
        }

        protected override void updateView()
        {
            if (_selector.HasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
                weaponCb.DataSource = null;
                if (c.Weapons.Count > 0)
                {
                    weaponCb.DataSource = c.Weapons;
                }
            }
            else
            {
                weaponCb.DataSource = null;
            }
        }

        protected override void toggleAllControls(bool enabled)
        {
            if(!enabled)
            {
                weaponResultTb.Clear();
                weaponResultBreakdownTb.Clear();
            }
            weaponRollBt.Enabled = enabled;
            weaponCb.Enabled = enabled;
            weaponResultBreakdownTb.Enabled = enabled;
            weaponResultTb.Enabled = enabled;
            updateAmmoCb();
        }

        private void weaponRollBt_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            Weapon selectedWeapon = (Weapon)weaponCb.SelectedItem;
            int additionalMod = 0;
            int additionalPen = 0;
            if(selectedWeapon.Reach == WeaponReach.RANGED)
            {
                WeaponMaterial wm = (WeaponMaterial)ammoCb.SelectedItem;
                WeaponMaterialModifier wmm = WeaponTemplates.Materials[(int)wm];
                additionalMod = wmm.DamageMod;
                additionalPen = wmm.PenetrationMod;
            }
            int resultTotal = 0;
            string breakdownString = "";

            for (int i = 0; i < selectedWeapon.NumberOfDice; i++)
            {
                int roll = r.Next(1, selectedWeapon.DiceSides);
                breakdownString += string.Format("{0} + ", roll);
                resultTotal += roll;
            }

            Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
            breakdownString += string.Format("{0} + bonus {1}", selectedWeapon.DamageMod + additionalMod, c.DamageBonus);
            resultTotal += selectedWeapon.DamageMod;
            resultTotal += c.DamageBonus;

            weaponResultTb.Text = string.Format("{0} pen {1}", resultTotal, selectedWeapon.Penetration + additionalPen);
            weaponResultBreakdownTb.Text = breakdownString;
        }

        private void updateAmmoCb()
        {
            if(_selector != null && !_selector.HasCharacter)
            {
                weaponRollBt.Enabled = false;
            }
            else if (weaponCb.SelectedIndex > -1 && weaponCb.SelectedItem.GetType() == typeof(Weapon))
            {
                weaponRollBt.Enabled = true;

                Weapon w = (Weapon)weaponCb.SelectedItem;
                ammoCb.Enabled = w.Reach == WeaponReach.RANGED;
            }
            else
            {
                weaponRollBt.Enabled = false;
            }
        }

        private void weaponCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAmmoCb();
        }
    }
}
