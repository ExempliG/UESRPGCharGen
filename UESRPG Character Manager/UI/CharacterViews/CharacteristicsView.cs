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
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Strength = (int)nbStrength.Value;
                _characteristicMutex = false;
            }
        }

        private void nbEndurance_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Endurance = (int)nbEndurance.Value;
                _characteristicMutex = false;
            }
        }

        private void nbAgility_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Agility = (int)nbAgility.Value;
                _characteristicMutex = false;
            }
        }

        private void nbIntelligence_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Intelligence = (int)nbIntelligence.Value;
                _characteristicMutex = false;
            }
        }

        private void nbWillpower_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Willpower = (int)nbWillpower.Value;
                _characteristicMutex = false;
            }
        }

        private void nbPerception_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Perception = (int)nbPerception.Value;
                _characteristicMutex = false;
            }
        }

        private void nbPersonality_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Personality = (int)nbPersonality.Value;
                _characteristicMutex = false;
            }
        }

        private void nbLuck_ValueChanged(object sender, EventArgs e)
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                _activeCharacter.Luck = (int)nbLuck.Value;
                _characteristicMutex = false;
            }
        }
    }
}
