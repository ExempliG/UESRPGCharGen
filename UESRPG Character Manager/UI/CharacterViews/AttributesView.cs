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

namespace UESRPG_Character_Manager.UI
{
    public partial class AttributesView : UserControl
    {
        private Character _activeCharacter;

        public AttributesView()
        {
            InitializeComponent();
        }

        public void OnSelectedCharacterChanged(object sender, EventArgs e)
        {
            _activeCharacter = ((CharacterSelector)sender).GetActiveCharacter();
        }

        public void UpdateView()
        {
            maxLuckPointsTb.Text = "" + (_activeCharacter.MaximumLuckPoints);
            initiativeRatingTb.Text = "" + (_activeCharacter.InitiativeRating);
            maxActionPointsTb.Text = "" + (_activeCharacter.MaximumAp);
            maxStaminaTb.Text = "" + (_activeCharacter.Stamina);
            maxMagickaTb.Text = "" + (_activeCharacter.MagickaPool);
            movementRatingTb.Text = "" + (_activeCharacter.MovementRating);
            carryRatingTb.Text = "" + (_activeCharacter.CarryRating);
            woundThresholdTb.Text = "" + (_activeCharacter.WoundThreshold);
            maxHealthTb.Text = "" + (_activeCharacter.MaxHealth);
            damageBonusTb.Text = "" + (_activeCharacter.DamageBonus);
        }
    }
}
