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
        public uint SelectorId { get; set; }
        uint _activeCharacter;
        bool _hasCharacter;

        public WeaponDamageView()
        {
            InitializeComponent();

            for(int i = 0; i < (int)WeaponMaterial.MAX; i++)
            {
                ammoCb.Items.Add((WeaponMaterial)i);
            }
            ammoCb.SelectedIndex = 0;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.WeaponsChanged += onWeaponsChanged;
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

        protected void onWeaponsChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void updateView()
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
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

        private void toggleAllControls(bool enabled)
        {
            weaponRollBt.Enabled = enabled;
            weaponCb.Enabled = enabled;
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

            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            breakdownString += string.Format("{0} + bonus {1}", selectedWeapon.DamageMod + additionalMod, c.DamageBonus);
            resultTotal += selectedWeapon.DamageMod;
            resultTotal += c.DamageBonus;

            weaponResultTb.Text = string.Format("{0} pen {1}", resultTotal, selectedWeapon.Penetration + additionalPen);
            weaponResultBreakdownTb.Text = breakdownString;
        }

        private void weaponCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weaponCb.SelectedIndex > -1 && weaponCb.SelectedItem.GetType() == typeof(Weapon))
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
    }
}
