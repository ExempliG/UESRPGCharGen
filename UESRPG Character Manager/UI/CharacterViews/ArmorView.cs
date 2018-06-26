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
    public partial class ArmorView : UserControl
    {
        public delegate void ArmorChangedHandler(object sender, EventArgs e);
        [Description("Fires when an Armor is changed by the user.")]
        public event ArmorChangedHandler ArmorChanged;

        private uint _activeCharacter;
        private bool _hasCharacter;
        public uint SelectorId { get; set; }

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

        private void updateView()
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
                armorDgv.DataSource = null;
                if (c.ArmorPieces.Count > 0)
                {
                    armorDgv.DataSource = c.ArmorPieces;
                }
            }
            else
            {
                ///<todo>Do it</todo>
            }
        }

        private void toggleAllControls(bool enabled)
        {

        }

        private void addNewArmorBt_Click(object sender, EventArgs e)
        {
            /// <todo>Update this when Inventory is implemented; violation of MVC</todo>
            Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
            double ar = Armor.CalculateAR((ArmorTypes)armorMaterialCb.SelectedIndex,
                               (ArmorMaterials)armorQualityCb.SelectedIndex,
                               (ArmorQualities)armorTypeCb.SelectedIndex);
            c.AddArmorPiece(new Armor(armorNameTb.Text, ar, 0, 0, (ArmorLocations)armorLocationCb.SelectedIndex, null));
            updateView();

            onArmorChanged(this, new System.EventArgs());
        }

        protected void onArmorChanged(object sender, EventArgs e)
        {
            ArmorChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
