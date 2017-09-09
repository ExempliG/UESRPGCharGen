using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UESRPG_Character_Manager
{
    static class Program
    {
        /// <todo>Find a better place for this</todo>
        public static int CurrentEngVersion = 1;
        public static int CurrentMinorVersion = 0;
        public static int CurrentMajorVersion = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new UI.MainWindow.MainWindow ());
        }
    }
}
