using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Command { get; private set; }
        public string Help { get; private set; }
        public string Usage { get; private set; }

        public CommandAttribute(string name, string command, string help, string usage)
        {
            Name = name;
            Command = command;
            Help = help;
            Usage = usage;
        }
    }
}
