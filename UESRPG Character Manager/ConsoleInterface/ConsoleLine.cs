using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    /// <summary>
    /// ConsoleLine represents a line printed to the GlobalConsole with an included LineType
    /// </summary>
    public class ConsoleLine
    {
        public enum LineType
        {
            USER_COMMAND,
            GENERATED,
            ERROR,
            DEBUG,
            MAX
        }

        public ConsoleLine(string line)
        {
            Line = line;
            Type = LineType.GENERATED;
        }

        public ConsoleLine( string line, LineType type )
        {
            Line = line;
            Type = type;
        }

        //  Create a ConsoleLine from a string
        public static implicit operator ConsoleLine( string s )
        {
            return new ConsoleLine( s );
        }

        public string Line { get; private set; }
        public LineType Type { get; private set; }

        public override string ToString()
        {
            return Line;
        }
    }
}
