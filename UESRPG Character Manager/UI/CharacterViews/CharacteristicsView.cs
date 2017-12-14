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
using UESRPG_Character_Manager.CharacterComponents;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class CharacteristicsView : UserControl
    {
        private bool _characteristicMutex;

        public CharacteristicsView()
        {
            InitializeComponent();
            _characteristicMutex = false;

            CharacterController.Instance.SelectedCharacterChanged += onSelectedCharacterChanged;
            Character.CharacteristicChanged += onCharacteristicChanged;
        }

        protected void onSelectedCharacterChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        protected void onCharacteristicChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        public void UpdateView()
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                nbStrength.Value = CharacterController.Instance.ActiveCharacter.Strength;
                nbEndurance.Value = CharacterController.Instance.ActiveCharacter.Endurance;
                nbAgility.Value = CharacterController.Instance.ActiveCharacter.Agility;
                nbIntelligence.Value = CharacterController.Instance.ActiveCharacter.Intelligence;
                nbWillpower.Value = CharacterController.Instance.ActiveCharacter.Willpower;
                nbPerception.Value = CharacterController.Instance.ActiveCharacter.Perception;
                nbPersonality.Value = CharacterController.Instance.ActiveCharacter.Personality;
                nbLuck.Value = CharacterController.Instance.ActiveCharacter.Luck;
                _characteristicMutex = false;
            }
        }

        private void nbStrength_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.STRENGTH, (int)nbStrength.Value); });
        }

        private void nbEndurance_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.ENDURANCE, (int)nbEndurance.Value); });
        }

        private void nbAgility_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.AGILITY, (int)nbAgility.Value); });
        }

        private void nbIntelligence_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.INTELLIGENCE, (int)nbIntelligence.Value); });
        }

        private void nbWillpower_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.WILLPOWER, (int)nbWillpower.Value); });
        }

        private void nbPerception_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.PERCEPTION, (int)nbPerception.Value); });
        }

        private void nbPersonality_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.PERSONALITY, (int)nbPersonality.Value); });
        }

        private void nbLuck_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(Characteristics.LUCK, (int)nbLuck.Value); });
        }

        private void changeCharacteristic(Action characteristicChange)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                characteristicChange();
                _characteristicMutex = false;
            }
        }
    }
}
