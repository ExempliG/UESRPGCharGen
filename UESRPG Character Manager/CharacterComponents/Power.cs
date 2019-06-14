using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;

using UESRPG_Character_Manager.Common;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public class Power: IIdentifiable, ICloneable
    {
        [XmlAttribute()]
        public string Name { get; set; }
        public string Description { get; set; }

        [XmlIgnore(), Browsable(false)]
        public Guid Guid { get; set; }

        public Power()
        {
            Guid = Guid.NewGuid();
        }

        public Power(string Name, string Description) : this()
        {
            this.Name = Name;
            this.Description = Description;
        }

        public object Clone()
        {
            return new Power(Name, Description);
        }
    }
}
