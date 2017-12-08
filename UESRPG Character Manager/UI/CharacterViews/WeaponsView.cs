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

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class WeaponsView : UserControl
    {
        private Character _activeCharacter;

        public WeaponsView()
        {
            InitializeComponent();

            List<WeaponType> types = new List<WeaponType>();
            for (int i = 0; i < (int)WeaponType.MAX; i++)
            {
                types.Add((WeaponType)i);
            }

            types.Sort(delegate (WeaponType a, WeaponType b)
            {
                return String.Compare(a.ToString(), b.ToString());
            });

            foreach(WeaponType type in types)
            {
                weaponTypeCb.Items.Add(type);
            }

            weaponTypeCb.SelectedIndex = 0;

            for (int i = 0; i < (int)WeaponMaterial.MAX; i++)
            {
                weaponMaterialCb.Items.Add((WeaponMaterial)i);
            }
            weaponMaterialCb.SelectedIndex = 0;

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
            weaponsDgv.DataSource = null;
            if (_activeCharacter.Weapons.Count > 0)
            {
                weaponsDgv.DataSource = _activeCharacter.Weapons;
            }
        }

        private void weaponsDgv_SelectionChanged(object sender, EventArgs e)
        {
            if(weaponsDgv.SelectedRows.Count == 1)
            {
                editWeaponBt.Enabled = true;
                deleteWeaponBt.Enabled = true;
            }
            else
            {
                editWeaponBt.Enabled = false;
                deleteWeaponBt.Enabled = false;
            }
        }

        private void addNewWeaponBt_Click(object sender, EventArgs e)
        {
            WeaponType type = (WeaponType)weaponTypeCb.SelectedItem;
            WeaponMaterial material = (WeaponMaterial)weaponMaterialCb.SelectedItem;

            Weapon template = WeaponTemplates.DefaultWeapons[(int)type];
            WeaponMaterialModifier modifier = WeaponTemplates.Materials[(int)material];

            Weapon result = Weapon.ApplyMaterial(template, modifier);
            result.Name = weaponNameTb.Text;

            CharacterController.Instance.AddWeapon(result);
            updateView();
        }

        private void editWeaponBt_Click(object sender, EventArgs e)
        {
            int weaponIndex = weaponsDgv.SelectedRows[0].Index;
            EditWeapon ew = new EditWeapon(CharacterController.Instance.ActiveCharacter.Weapons[weaponIndex]);
            ew.ShowDialog();
        }

        private void deleteWeaponBt_Click(object sender, EventArgs e)
        {
            int weaponIndex = weaponsDgv.SelectedRows[0].Index;
            CharacterController.Instance.DeleteWeapon(CharacterController.Instance.ActiveCharacter.Weapons[weaponIndex]);
        }
    }
}
