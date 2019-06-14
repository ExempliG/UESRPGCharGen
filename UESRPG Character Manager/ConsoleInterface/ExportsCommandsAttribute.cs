using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    /// <summary>
    /// This attribute marks a class as having Commands to export to the GlobalConsole.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportsCommandsAttribute : Attribute
    {
    }
}
