using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.ConsoleInterface
{
    public struct Argument
    {
        public string Name;
        public string Value;

        public Argument( string Name )
        {
            this.Name = Name;
            Value = "";
        }

        public Argument( string Name, string Value )
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
