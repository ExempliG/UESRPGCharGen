using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UESRPG_Character_Manager.ConsoleInterface;

namespace UESRPG_Character_Manager.UI
{
    public partial class GraphicalConsole : UserControl
    {
        public GraphicalConsole()
        {
            InitializeComponent();
            foreach(string line in GlobalConsole.Instance.Lines)
            {
                rtbOutput.Text += line;
            }
            GlobalConsole.ConsoleUpdated += onConsoleUpdated;
        }

        private void tbInput_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter )
            {
                GlobalConsole.Instance.ProcessLine( tbInput.Text );
                tbInput.Text = "";
            }
            else if ( e.KeyCode == Keys.Escape )
            {
                ( ( Form )this.TopLevelControl ).Close();
            }
        }

        protected void onConsoleUpdated( object sender, ConsoleUpdatedEventArgs e )
        {
            foreach( string line in e.NewLines )
            {
                rtbOutput.Text += line;
                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            }
        }
    }
}
