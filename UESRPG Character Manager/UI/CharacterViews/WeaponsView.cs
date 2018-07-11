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
        private uint _activeCharacter;
        private bool _hasCharacter;
        public uint SelectorId { get; set; }

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

            updateMaterialsList();

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

        private void updateMaterialsList()
        {
            WeaponType wt = (WeaponType)weaponTypeCb.SelectedItem;
            Weapon w = WeaponTemplates.DefaultWeapons[(int)wt];
            updateMaterialsList(w.Reach == WeaponReach.RANGED);
        }

        private void updateMaterialsList(bool isRanged)
        {
            weaponMaterialCb.Items.Clear();

            if(isRanged)
            {
                for (int i = 0; i < (int)RangedWeaponMaterial.MAX; i++)
                {
                    weaponMaterialCb.Items.Add((RangedWeaponMaterial)i);
                }
                weaponMaterialCb.SelectedIndex = 0;
            }
            else
            {
                for (int i = 0; i < (int)WeaponMaterial.MAX; i++)
                {
                    weaponMaterialCb.Items.Add((WeaponMaterial)i);
                }
                weaponMaterialCb.SelectedIndex = 0;
            }
        }

        private void updateView()
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                weaponsDgv.DataSource = null;
                if (c.Weapons.Count > 0)
                {
                    weaponsDgv.DataSource = c.Weapons;
                }
            }
            else
            {
                weaponsDgv.DataSource = null;
            }
        }

        private void toggleAllControls(bool enabled)
        {
            ///<todo>Do it</todo>
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
            addNewWeapon();
        }

        private void addNewWeapon()
        {
            Weapon result;
            WeaponType type = (WeaponType)weaponTypeCb.SelectedItem;
            Weapon template = WeaponTemplates.DefaultWeapons[(int)type];
            bool isRanged = template.Reach == WeaponReach.RANGED;

            if (isRanged)
            {
                RangedWeaponMaterial material = (RangedWeaponMaterial)weaponMaterialCb.SelectedItem;
                RangedWeaponMaterialModifier modifier = WeaponTemplates.RangedMaterials[(int)material];

                result = Weapon.ApplyMaterial(template, modifier);
            }
            else
            {
                WeaponMaterial material = (WeaponMaterial)weaponMaterialCb.SelectedItem;
                WeaponMaterialModifier modifier = WeaponTemplates.Materials[(int)material];

                result = Weapon.ApplyMaterial(template, modifier);
            }

            result.Name = weaponNameTb.Text;

            CharacterController.Instance.AddWeapon(_activeCharacter, result);
            updateView();
        }

        private void editWeaponBt_Click(object sender, EventArgs e)
        {
            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            int weaponIndex = weaponsDgv.SelectedRows[0].Index;
            EditWeapon ew = new EditWeapon(c.Id, c.Weapons[weaponIndex]);
            ew.ShowDialog();
        }

        private void deleteWeaponBt_Click(object sender, EventArgs e)
        {
            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            int weaponIndex = weaponsDgv.SelectedRows[0].Index;
            CharacterController.Instance.DeleteWeapon(_activeCharacter, c.Weapons[weaponIndex]);
        }

        private void weaponTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateMaterialsList();
        }
    }
}
