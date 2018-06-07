using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.Controllers;

namespace UESRPG_Character_Manager.UI.CombatViews
{
    public partial class CombatWindow : Form
    {
        private uint _combatId;

        public CombatWindow()
        {
            InitializeComponent();
        }

        public CombatWindow( uint combatId ) : this()
        {
            _combatId = combatId;

            combatantsListView._combatId = _combatId;

            this.FormClosed += onClosed;
        }

        protected void onClosed(object sender, EventArgs e)
        {
            GameController.Instance.EndCombat(_combatId);
        }
    }
}
