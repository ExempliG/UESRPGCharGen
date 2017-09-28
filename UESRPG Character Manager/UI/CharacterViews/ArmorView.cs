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
    public partial class ArmorView : UserControl
    {
        public delegate void ArmorChangedHandler(object sender, EventArgs e);
        [Description("Fires when an Armor is changed by the user.")]
        public event ArmorChangedHandler ArmorChanged;

        private Character _activeCharacter;

        public ArmorView()
        {
            InitializeComponent();

            armorDgv.CellValueChanged += onArmorChanged;

            armorLocationCb.DataSource = ArmorLocationsData.s_names;
            armorTypeCb.DataSource = ArmorQualityData.s_names;
            armorMaterialCb.DataSource = ArmorTypeData.s_names;
            armorQualityCb.DataSource = ArmorMaterialData.s_names;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = CharacterController.Instance.ActiveCharacter;

            updateView();
        }

        private void updateView()
        {
            armorDgv.DataSource = null;
            if (_activeCharacter.ArmorPieces.Count > 0)
            {
                armorDgv.DataSource = _activeCharacter.ArmorPieces;
            }
        }

        private void addNewArmorBt_Click(object sender, EventArgs e)
        {
            double ar = Armor.CalculateAR((ArmorTypes)armorMaterialCb.SelectedIndex,
                               (ArmorMaterials)armorQualityCb.SelectedIndex,
                               (ArmorQualities)armorTypeCb.SelectedIndex);
            _activeCharacter.AddArmorPiece(new Armor(armorNameTb.Text, ar, 0, 0, (ArmorLocations)armorLocationCb.SelectedIndex, null));
            updateView();

            onArmorChanged(this, new System.EventArgs());
        }

        protected void onArmorChanged(object sender, EventArgs e)
        {
            ArmorChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
