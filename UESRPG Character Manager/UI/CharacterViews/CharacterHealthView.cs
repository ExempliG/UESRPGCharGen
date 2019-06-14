using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.CharacterComponents.Character;
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class CharacterHealthView : SelectedCharacterControl
    {
        private bool _attributesMutex = false;

        public CharacterHealthView()
        {
            InitializeComponent();

            toggleAllControls(false);
            aspectsToWatch.Add( CharacterAspect.ATTRIBUTE );
        }

        protected override void updateView()
        {
            if (_selector.HasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterByGuid(_selector.GetCharacterGuid());
                getCurrentValues(c);
                getMaxValues(c);
            }
        }

        private void getCurrentValues(Character c)
        {
            if(!_attributesMutex)
            {
                _attributesMutex = true;
                healthTb.Text = c.CurrentHealth.ToString();
                magickaTb.Text = c.CurrentMagicka.ToString();
                actionPointsTb.Text = c.CurrentAp.ToString();
                staminaTb.Text = c.CurrentStamina.ToString();
                _attributesMutex = false;
            }
        }

        private void getMaxValues(Character c)
        {
            if (!_attributesMutex)
            {
                _attributesMutex = true;
                maxHealthTb.Text = c.MaxHealth.ToString();
                maxMagickaTb.Text = c.MagickaPool.ToString();
                maxActionPointsTb.Text = c.MaximumAp.ToString();
                maxStaminaTb.Text = c.Stamina.ToString();
                _attributesMutex = false;
            }
        }

        protected override void toggleAllControls(bool enabled)
        {
            if(enabled)
            {
                enableAll();
            }
            else
            {
                disableAll();
            }
        }

        private void disableAll()
        {
            _attributesMutex = true;
            this.Enabled = false;
            healthTb.Enabled = false;
            healthTb.Text = "";
            maxHealthTb.Text = "";
            magickaTb.Enabled = false;
            magickaTb.Text = "";
            maxMagickaTb.Text = "";
            actionPointsTb.Enabled = false;
            actionPointsTb.Text = "";
            maxActionPointsTb.Text = "";
            staminaTb.Enabled = false;
            staminaTb.Text = "";
            maxStaminaTb.Text = "";
            _attributesMutex = false;
        }

        private void enableAll()
        {
            this.Enabled = true;
            healthTb.Enabled = true;
            magickaTb.Enabled = true;
            actionPointsTb.Enabled = true;
            staminaTb.Enabled = true;
        }

        private void healthTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeHealth(_selector.GetCharacterGuid(), tryParseAttribute(healthTb.Text)); });
        }

        private void staminaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeStamina(_selector.GetCharacterGuid(), tryParseAttribute(staminaTb.Text)); });
        }

        private void magickaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeMagicka(_selector.GetCharacterGuid(), tryParseAttribute(magickaTb.Text)); });
        }

        private void actionPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeAP(_selector.GetCharacterGuid(), tryParseAttribute(actionPointsTb.Text)); });
        }

        private int tryParseAttribute(string textVal)
        {
            if (int.TryParse(textVal, out int value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        private void changeAttribute(Action attributeChange)
        {
            if (!_attributesMutex)
            {
                _attributesMutex = true;
                attributeChange();
                _attributesMutex = false;
            }
        }
    }
}
