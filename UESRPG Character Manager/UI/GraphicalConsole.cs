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
    /// <summary>
    /// The GraphicalConsole control displays output from the GlobalConsole, as well as allowing input from the User.
    /// </summary>
    public partial class GraphicalConsole : UserControl
    {
        /**
         * A list of colors to apply to each different type of ConsoleLine
         */
        private Color[] _colors = new Color[] {
            Color.Black,                            // LineType.USER_COMMAND
            Color.DarkBlue,                         // LineType.GENERATED
            Color.DarkRed,                          // LineType.ERROR
            Color.DimGray                           // LineType.DEBUG
        };

        /**
         * A list of Colors to cycle through based on the row
         */
        private Color[] _rowColors = new Color[]
        {
            Color.White,
            Color.WhiteSmoke
        };

        private int _rowIndex = 0;

        public GraphicalConsole()
        {
            InitializeComponent();

            // Grab all the lines that are currently in the GlobalConsole then subscribe to new events.
            foreach(ConsoleLine line in GlobalConsole.Instance.Lines)
            {
                addLine( line );
            }
            GlobalConsole.ConsoleUpdated += onConsoleUpdated;

            CanCloseParent = false;
        }

        /// <summary>
        /// Determines whether this control is allowed to close its parent. It might be desirable to have a breakout
        /// console close its Parent window, for example.
        /// </summary>
        public bool CanCloseParent { get; set; }

        private void tbInput_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter )
            {
                GlobalConsole.Instance.ProcessLine( tbInput.Text );
                tbInput.Text = "";
            }
            else if ( e.KeyCode == Keys.Escape && CanCloseParent )
            {
                GlobalConsole.Instance.Log( "Closed with esc" );
                ( ( Form )this.TopLevelControl ).Close();
            }
        }

        protected void onConsoleUpdated( object sender, ConsoleUpdatedEventArgs e )
        {
            foreach( ConsoleLine line in e.NewLines )
            {
                addLine( line );
            }
        }

        /// <summary>
        /// Processes the ConsoleLine, applying colors and prefixes as appropriate.
        /// </summary>
        /// <param name="line"></param>
        protected void addLine( ConsoleLine line )
        {
            applyForegroundColor( line );
            applyBackgroundColor();

            rtbOutput.AppendText( applyPrefix( line ) );

            scrollToEnd();
            _rowIndex++;
        }

        /**
         * A list of prefixes to apply to each different type of ConsoleLine
         */
        private string[] _prefixes = new string[]
        {
            "> ",                                   // LineType.USER_COMMAND
            "",                                     // LineType.GENERATED
            "[ERROR] ",                             // LineType.ERROR
            "[LOG] "                                // LineType.DEBUG
        };

        /// <summary>
        /// Look up the appropriate prefix and apply it to the string, returning the resulting string
        /// </summary>
        /// <param name="line">The ConsoleLine to prepend to</param>
        /// <returns>The resulting line text as a string</returns>
        protected string applyPrefix( ConsoleLine line )
        {
            string prefix = _prefixes[( int )line.Type];
            return line.Line.Insert( 1, prefix );
        }

        /// <summary>
        /// Look up the appropriate foreground color and apply it to the rich text box
        /// </summary>
        /// <param name="line">The ConsoleLine to colorize</param>
        protected void applyForegroundColor( ConsoleLine line )
        {
            rtbOutput.SelectionColor = _colors[( int )line.Type];
        }

        /// <summary>
        /// Look up the appropriate background color and apply it to the rich text box
        /// </summary>
        protected void applyBackgroundColor()
        {
            int bgColorIndex = _rowIndex % _rowColors.Length;
            rtbOutput.SelectionBackColor = _rowColors[bgColorIndex];
        }

        /// <summary>
        /// Scroll to the bottom of the rich text box content
        /// </summary>
        protected void scrollToEnd()
        {
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void GraphicalConsole_SizeChanged( object sender, EventArgs e )
        {
            scrollToEnd();
        }
    }
}
