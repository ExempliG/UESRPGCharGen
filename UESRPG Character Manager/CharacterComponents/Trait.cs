using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;

namespace UESRPG_Character_Manager.CharacterComponents
{
    public class Trait : ICloneable
    {
        public static uint NextAvailableId { get; set; }

        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute()]
        public bool IsRacialTrait { get; set; }
        public string Description { get; set; }
        [XmlAttribute()]
        public int XpCost { get; set; }

        [XmlIgnore(), Browsable(false)]
        public uint TraitId;

        public Trait()
        {
            TraitId = NextAvailableId;
            NextAvailableId++;
        }

        public Trait(string Name, bool IsRacialTrait, int Cost, string Description) : this()
        {
            this.Name = Name;
            this.IsRacialTrait = IsRacialTrait;
            this.XpCost = Cost;
            this.Description = Description;
        }

        public object Clone()
        {
            Trait newTrait = new Trait(Name, IsRacialTrait, XpCost, Description);
            return newTrait;
        }
    }
}
