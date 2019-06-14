using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    public class ConsoleUpdatedEventArgs : EventArgs
    {
        public ConsoleUpdatedEventArgs( List<ConsoleLine> newLines )
        {
            NewLines = newLines;
        }

        public ConsoleUpdatedEventArgs( ConsoleLine newLine )
        {
            NewLines = new List<ConsoleLine> { newLine };
        }

        public List<ConsoleLine> NewLines { get; private set; }
    }
}
