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
using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class CharacteristicsView : SelectedCharacterControl
    {
        private bool _characteristicMutex;

        public CharacteristicsView()
        {
            InitializeComponent();
            _characteristicMutex = false;


            toggleAllControls(false);
            aspectsToWatch.Add( CharacterAspect.CHARACTERISTIC );
        }

        protected override void updateView()
        {
            if (_selector.HasCharacter)
            {
                if (!_characteristicMutex)
                {
                    _characteristicMutex = true;
                    Character c          = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
                    nbStrength.Value     = c.Strength;
                    nbEndurance.Value    = c.Endurance;
                    nbAgility.Value      = c.Agility;
                    nbIntelligence.Value = c.Intelligence;
                    nbWillpower.Value    = c.Willpower;
                    nbPerception.Value   = c.Perception;
                    nbPersonality.Value  = c.Personality;
                    nbLuck.Value         = c.Luck;
                    _characteristicMutex = false;
                }
            }
            else
            {
                clearAllControls();
            }
        }

        private void clearAllControls()
        {
            if (!_characteristicMutex)
            {
                _characteristicMutex = true;
                nbStrength.Value     = 0;
                nbEndurance.Value    = 0;
                nbAgility.Value      = 0;
                nbIntelligence.Value = 0;
                nbWillpower.Value    = 0;
                nbPerception.Value   = 0;
                nbPersonality.Value  = 0;
                nbLuck.Value         = 0;
                _characteristicMutex = false;
            }
        }

        protected override void toggleAllControls(bool enabled)
        {
            nbStrength.Enabled     = enabled;
            nbEndurance.Enabled    = enabled;
            nbAgility.Enabled      = enabled;
            nbIntelligence.Enabled = enabled;
            nbWillpower.Enabled    = enabled;
            nbPerception.Enabled   = enabled;
            nbPersonality.Enabled  = enabled;
            nbLuck.Enabled         = enabled;
        }

        private void nbStrength_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.STRENGTH, (int)nbStrength.Value); });
        }

        private void nbEndurance_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.ENDURANCE, (int)nbEndurance.Value); });
        }

        private void nbAgility_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.AGILITY, (int)nbAgility.Value); });
        }

        private void nbIntelligence_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.INTELLIGENCE, (int)nbIntelligence.Value); });
        }

        private void nbWillpower_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.WILLPOWER, (int)nbWillpower.Value); });
        }

        private void nbPerception_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.PERCEPTION, (int)nbPerception.Value); });
        }

        private void nbPersonality_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.PERSONALITY, (int)nbPersonality.Value); });
        }

        private void nbLuck_ValueChanged(object sender, EventArgs e)
        {
            changeCharacteristic(delegate () { CharacterController.Instance.ChangeCharacteristic(_selector.GetCharacterGuid(), Characteristics.LUCK, (int)nbLuck.Value); });
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
