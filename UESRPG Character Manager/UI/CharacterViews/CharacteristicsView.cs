using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UESRPG_Character_Manager.UI
{
    public partial class CharacteristicsView : UserControl
    {
        private Character _activeCharacter;

        public CharacteristicsView()
        {
            InitializeComponent();
        }

        public void SetActiveCharacter(Character c)
        {
            _activeCharacter = c;

            UpdateView();
        }

        public void UpdateView()
        {
            nbStrength.Value     = _activeCharacter.Strength;
            nbEndurance.Value    = _activeCharacter.Endurance;
            nbAgility.Value      = _activeCharacter.Agility;
            nbIntelligence.Value = _activeCharacter.Intelligence;
            nbWillpower.Value    = _activeCharacter.Willpower;
            nbPerception.Value   = _activeCharacter.Perception;
            nbPersonality.Value  = _activeCharacter.Personality;
            nbLuck.Value         = _activeCharacter.Luck;
        }

        private void nbStrength_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Strength = (int)nbStrength.Value;
        }

        private void nbEndurance_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Endurance = (int)nbEndurance.Value;
        }

        private void nbAgility_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Agility = (int)nbAgility.Value;
        }

        private void nbIntelligence_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Intelligence = (int)nbIntelligence.Value;
        }

        private void nbWillpower_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Willpower = (int)nbWillpower.Value;
        }

        private void nbPerception_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Perception = (int)nbPerception.Value;
        }

        private void nbPersonality_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Personality = (int)nbPersonality.Value;
        }

        private void nbLuck_ValueChanged(object sender, EventArgs e)
        {
            _activeCharacter.Luck = (int)nbLuck.Value;
        }
    }
}
