using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    public class ConsoleUpdatedEventArgs : EventArgs
    {
        public ConsoleUpdatedEventArgs( List<string> newLines )
        {
            NewLines = newLines;
        }

        public ConsoleUpdatedEventArgs( string newLine )
        {
            NewLines = new List<string> { newLine };
        }

        public List<string> NewLines { get; private set; }
    }
}
