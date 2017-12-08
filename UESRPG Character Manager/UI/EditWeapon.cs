using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI
{
    public partial class EditWeapon : Form
    {
        private Weapon _weapon;

        public EditWeapon(Weapon weaponToEdit)
        {
            InitializeComponent();

            _weapon = (Weapon)weaponToEdit.Clone();

            List<WeaponType> types = new List<WeaponType>();
            for (int i = 0; i < (int)WeaponType.MAX; i++)
            {
                types.Add((WeaponType)i);
            }

            types.Sort(delegate (WeaponType a, WeaponType b)
            {
                return String.Compare(a.ToString(), b.ToString());
            });

            foreach (WeaponType type in types)
            {
                weaponTypeCb.Items.Add(type);
            }

            weaponTypeCb.SelectedIndex = weaponTypeCb.Items.IndexOf(_weapon.Type);

            for (int i = 0; i < (int)WeaponMaterial.MAX; i++)
            {
                weaponMaterialCb.Items.Add((WeaponMaterial)i);
            }
            weaponMaterialCb.SelectedIndex = weaponMaterialCb.Items.IndexOf(_weapon.Material);

            for (int i = 0; i < (int)WeaponHandedness.MAX; i++)
            {
                weaponHandednessCb.Items.Add((WeaponHandedness)i);
            }
            weaponHandednessCb.SelectedIndex = weaponHandednessCb.Items.IndexOf(_weapon.Handedness);

            for (int i = 0; i < (int)WeaponReach.MAX; i++)
            {
                weaponReachCb.Items.Add((WeaponReach)i);
            }
            weaponReachCb.SelectedIndex = weaponReachCb.Items.IndexOf(_weapon.Reach);

            for (int i = 0; i < (int)WeaponSize.MAX; i++)
            {
                weaponSizeCb.Items.Add((WeaponSize)i);
            }
            weaponSizeCb.SelectedIndex = weaponSizeCb.Items.IndexOf(_weapon.Size);

            for (int i = 0; i < (int)WeaponQuality.MAX; i++)
            {
                weaponQualityCb.Items.Add((WeaponQuality)i);
            }
            weaponQualityCb.SelectedIndex = weaponQualityCb.Items.IndexOf(_weapon.Quality);

            nameTb.Text = _weapon.Name;
            weaponDescriptionRtb.Text = _weapon.Description;
            damageModNud.Value = _weapon.DamageMod;
            numberOfDiceNud.Value = _weapon.NumberOfDice;
            diceSidesNud.Value = _weapon.DiceSides;
            penNud.Value = _weapon.Penetration;
            enchantmentLevelNud.Value = _weapon.EnchantmentLevel;
            encumbranceNud.Value = (decimal)_weapon.Encumbrance;
            priceNud.Value = _weapon.Price;
            direCb.Checked = _weapon.IsDire;
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            _weapon.Name = nameTb.Text;
            _weapon.Description = weaponDescriptionRtb.Text;
            _weapon.DamageMod = (int)damageModNud.Value;
            _weapon.NumberOfDice = (int)numberOfDiceNud.Value;
            _weapon.DiceSides = (int)diceSidesNud.Value;
            _weapon.Penetration = (int)penNud.Value;
            _weapon.EnchantmentLevel = (int)enchantmentLevelNud.Value;
            _weapon.Encumbrance = (float)encumbranceNud.Value;
            _weapon.Price = (int)priceNud.Value;
            _weapon.IsDire = direCb.Checked;
            _weapon.Type = (WeaponType)weaponTypeCb.SelectedItem;
            _weapon.Material = (WeaponMaterial)weaponMaterialCb.SelectedItem;
            _weapon.Quality = (WeaponQuality)weaponQualityCb.SelectedItem;
            _weapon.Size = (WeaponSize)weaponSizeCb.SelectedItem;
            _weapon.Handedness = (WeaponHandedness)weaponHandednessCb.SelectedItem;
            _weapon.Reach = (WeaponReach)weaponReachCb.SelectedItem;

            CharacterController.Instance.EditWeapon(_weapon);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
