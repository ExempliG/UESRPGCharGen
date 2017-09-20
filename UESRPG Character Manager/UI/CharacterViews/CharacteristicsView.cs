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

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class CharacteristicsView : UserControl
    {
        public delegate void CharacteristicChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Characteristics is changed by the user.")]
        public event CharacteristicChangedHandler CharacteristicChanged;

        private Character _activeCharacter;
        private bool _characteristicMutex;

        public CharacteristicsView()
        {
            InitializeComponent();
            _characteristicMutex = false;
        }

        public void OnSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();

            UpdateView();
        }

        public void UpdateView()
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                nbStrength.Value = _activeCharacter.Strength;
                nbEndurance.Value = _activeCharacter.Endurance;
                nbAgility.Value = _activeCharacter.Agility;
                nbIntelligence.Value = _activeCharacter.Intelligence;
                nbWillpower.Value = _activeCharacter.Willpower;
                nbPerception.Value = _activeCharacter.Perception;
                nbPersonality.Value = _activeCharacter.Personality;
                nbLuck.Value = _activeCharacter.Luck;
                _characteristicMutex = false;
            }
        }

        private void nbStrength_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Strength = (int)nbStrength.Value; });
        }

        private void nbEndurance_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Endurance = (int)nbEndurance.Value; });
        }

        private void nbAgility_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Agility = (int)nbAgility.Value; });
        }

        private void nbIntelligence_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Intelligence = (int)nbIntelligence.Value; });
        }

        private void nbWillpower_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Willpower = (int)nbWillpower.Value; });
        }

        private void nbPerception_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Perception = (int)nbPerception.Value; });
        }

        private void nbPersonality_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { _activeCharacter.Personality = (int)nbPersonality.Value; });
        }

        private void nbLuck_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate() { _activeCharacter.Luck = (int)nbLuck.Value; });
        }

        private void changeCharacteristic(Action characteristicChange)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                characteristicChange();
                _characteristicMutex = false;

                onCharacteristicChanged();
            }
        }

        protected void onCharacteristicChanged()
        {
            // Invoke the event if subscribers exist
            CharacteristicChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
