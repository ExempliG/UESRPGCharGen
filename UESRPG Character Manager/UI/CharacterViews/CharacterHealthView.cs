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
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public partial class CharacterHealthView : UserControl
    {
        private uint _activeCharacter;
        private bool _hasCharacter = false;
        public uint SelectorId { get; set; }

        private bool _attributesMutex = false;

        public CharacterHealthView()
        {
            InitializeComponent();

            Character.AttributeChanged += onAttributeChanged;
            CharacterController.Instance.SelectedCharacterChanged += onCombatantChanged;
        }

        protected void onAttributeChanged(object sender, EventArgs e)
        {
            if (_hasCharacter)
            {
                Character c = (Character)sender;
                if (c.CharacterId == _activeCharacter && this.Enabled)
                {
                    getCurrentValues(c);
                }
            }
        }

        protected void onCombatantChanged(object sender, SelectedCharacterChangedEventArgs e)
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

                updateAll();
            }

            /*Combat cmb = (Combat)sender;
            ICombatant ic = cmb.Combatants[cmb.CurrentCombatantIndex];
            if(ic.GetType() == typeof(Character))
            {
                enableAll();
                Character c = (Character)ic;
                CharacterId = c.CharacterId;
            }
            else
            {
                disableAll();
            }*/
        }

        private void updateAll()
        {
            if (_hasCharacter)
            {
                Character c = CharacterController.Instance.GetCharacterById(_activeCharacter);
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

        private void toggleAllControls(bool enabled)
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
            changeAttribute(delegate () { CharacterController.Instance.ChangeHealth(_activeCharacter, tryParseAttribute(healthTb.Text)); });
        }

        private void staminaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeStamina(_activeCharacter, tryParseAttribute(staminaTb.Text)); });
        }

        private void magickaTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeMagicka(_activeCharacter, tryParseAttribute(magickaTb.Text)); });
        }

        private void actionPointsTb_TextChanged(object sender, EventArgs e)
        {
            changeAttribute(delegate () { CharacterController.Instance.ChangeAP(_activeCharacter, tryParseAttribute(actionPointsTb.Text)); });
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
