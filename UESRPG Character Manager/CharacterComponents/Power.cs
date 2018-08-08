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
        public static uint NextAvailableId { get; set; }

        [XmlAttribute()]
        public string Name { get; set; }
        public string Description { get; set; }

        [XmlIgnore(), Browsable(false)]
        public uint Id { get; set; }
        public void ResetId()
        {
            Id = NextAvailableId;
            NextAvailableId++;
        }

        public Power()
        {
            Id = NextAvailableId;
            NextAvailableId++;
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
