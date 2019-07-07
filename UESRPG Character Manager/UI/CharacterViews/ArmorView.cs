using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.UI.Selectors;
using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class ArmorView : SelectedCharacterControl
    {
        public delegate void ArmorChangedHandler(object sender, EventArgs e);
        [Description("Fires when an Armor is changed by the user.")]
        public event ArmorChangedHandler ArmorChanged;

        public ArmorView()
        {
            InitializeComponent();

            armorDgv.CellValueChanged += onArmorChanged;

            armorLocationCb.DataSource = ArmorLocationsData.s_names;
            armorTypeCb.DataSource = ArmorQualityData.s_names;
            armorMaterialCb.DataSource = ArmorTypeData.s_names;
            armorQualityCb.DataSource = ArmorMaterialData.s_names;

            toggleAllControls(false);
            aspectsToWatch.Add( CharacterAspect.EQUIPMENT_ARMOR );
        }

        protected override void updateView()
        {
            if ( _selector.HasCharacter )
            {
                Character c = CharacterController.Instance.GetCharacterByGuid( _selector.GetCharacterGuid() );
                armorDgv.DataSource = null;
                if (c.EquippedArmorPieces.Count > 0)
                {
                    armorDgv.DataSource = c.EquippedArmorPieces;
                }
            }
            else
            {
                armorDgv.DataSource = null;
            }
        }

        protected override void toggleAllControls(bool enabled)
        {
            if(!enabled)
            {
                armorDgv.DataSource = null;
                armorNameTb.Clear();
            }
            addNewArmorBt.Enabled = enabled;
            armorLocationCb.Enabled = enabled;
            armorMaterialCb.Enabled = enabled;
            armorQualityCb.Enabled = enabled;
            armorTypeCb.Enabled = enabled;
            armorNameTb.Enabled = enabled;
        }

        private void addNewArmorBt_Click(object sender, EventArgs e)
        {
            /// <todo>Update this when Inventory is implemented; violation of MVC</todo>
            Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
            Armor a = new Armor((ArmorLocations)armorLocationCb.SelectedIndex,
                                (ArmorMaterials)armorMaterialCb.SelectedIndex,
                                (ArmorTypes)armorTypeCb.SelectedIndex,
                                (ArmorQualities)armorQualityCb.SelectedIndex);
            if( armorNameTb.Text != "" )
            {
                a.Name = armorNameTb.Text;
            }
            c.EquipNewArmor( a );
            updateView();

            onArmorChanged(this, new System.EventArgs());
        }

        protected void onArmorChanged(object sender, EventArgs e)
        {
            ArmorChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
