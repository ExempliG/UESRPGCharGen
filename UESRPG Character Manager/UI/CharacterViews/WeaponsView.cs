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

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class WeaponsView : UserControl
    {
        public delegate void WeaponsChangedHandler(object sender, EventArgs e);
        [Description("Fires when a Weapon is changed or added by the user.")]
        public event WeaponsChangedHandler WeaponsChanged;

        private Character _activeCharacter;

        public WeaponsView()
        {
            InitializeComponent();

            weaponsDgv.CellValueChanged += onWeaponsChanged;

            for (int i = 0; i < (int)WeaponType.MAX; i++)
            {
                weaponTypeCb.Items.Add((WeaponType)i);
            }
            weaponTypeCb.SelectedIndex = 0;

            for (int i = 0; i < (int)WeaponMaterial.MAX; i++)
            {
                weaponMaterialCb.Items.Add((WeaponMaterial)i);
            }
            weaponMaterialCb.SelectedIndex = 0;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;

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

        private void addNewWeaponBt_Click(object sender, EventArgs e)
        {
            WeaponType type = (WeaponType)weaponTypeCb.SelectedItem;
            WeaponMaterial material = (WeaponMaterial)weaponMaterialCb.SelectedItem;

            Weapon template = WeaponTemplates.DefaultWeapons[(int)type];
            WeaponMaterialModifier modifier = WeaponTemplates.Materials[(int)material];

            Weapon result = (template * modifier);
            result.Name = weaponNameTb.Text;

            _activeCharacter.Weapons.Add(result);
            updateView();

            onWeaponsChanged(this, new System.EventArgs());
        }

        protected void onWeaponsChanged(object sender, EventArgs e)
        {
            WeaponsChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
