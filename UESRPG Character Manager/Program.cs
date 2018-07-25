using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UESRPG_Character_Manager
{
    static class Program
    {
        /// <todo>Relocate this to the SaveFile object in the first "API breaking" release</todo>
        public const int CURRENT_ENG_VERSION = 1;
        public const int CURRENT_MINOR_VERSION = 0;
        public const int CURRENT_MAJOR_VERSION = 0;

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
