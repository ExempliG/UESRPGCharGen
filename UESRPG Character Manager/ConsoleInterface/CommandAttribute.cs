using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    /// <summary>
    /// This attribute marks a method as being a Command to export to the GlobalConsole.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Command { get; private set; }
        public string Help { get; private set; }
        public string Usage { get; private set; }

        /// <summary>
        /// Mark this method as being a Command to export to the GlobalConsole.
        /// </summary>
        /// <param name="name">The human readable command name.</param>
        /// <param name="command">The command text that the user will enter.</param>
        /// <param name="help">Some help text to display to the user.</param>
        /// <param name="usage">Usage text to display to the user.</param>
        public CommandAttribute(string name, string command, string help, string usage)
        {
            Name = name;
            Command = command;
            Help = help;
            Usage = usage;
        }
    }
}
