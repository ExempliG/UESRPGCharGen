using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UESRPG_Character_Manager.UI.Selectors;
using UESRPG_Character_Manager.CharacterComponents.Character;

namespace UESRPG_Character_Manager.UI.CharacterViews
{
    public abstract class SelectedCharacterControl : UserControl
    {
        protected ICharacterSelector _selector;

        protected List<CharacterAspect> aspectsToWatch = new List<CharacterAspect>();

        protected Guid GetGuid()
        {
            return _selector.GetCharacterGuid();
        }

        public void SetSelector( ICharacterSelector selector )
        {
            selector.OnSelectedNewCharacter += onSelectedNewCharacter;
            selector.OnCharacterChanged += onSelectedCharacterChanged;
            _selector = selector;
        }

        protected void onSelectedNewCharacter( object sender, SelectedNewCharacterEventArgs e )
        {
            toggleAllControls( _selector.HasCharacter );

            updateView();
        }

        protected void onSelectedCharacterChanged( object sender, CharacterChangedEventArgs e )
        {
            if ( aspectsToWatch.Contains( e.Aspect ) )
            {
                updateView();
            }
        }

        protected abstract void updateView();

        protected abstract void toggleAllControls( bool enabled );
    }
}
