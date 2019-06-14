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
    public enum TalentLevel
    {
        NOVICE,
        APPRENTICE,
        JOURNEYMAN,
        ADEPT,
        EXPERT,
        MASTER,
        NUMBER_OF_TALENT_LEVELS
    }

    public class Talent : ICloneable, IIdentifiable
    {
        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute()]
        public bool IsRacialTalent { get; set; }
        [XmlAttribute()]
        public TalentLevel Level { get; set; }
        public string Description { get; set; }
        [XmlIgnore(), Browsable(false)]
        public Guid Guid { get; private set; }

        public Talent()
        {
            Guid = Guid.NewGuid();
        }

        public Talent(string Name, bool IsRacialTalent, TalentLevel Level, string Description) : this()
        {
            this.Name = Name;
            this.IsRacialTalent = IsRacialTalent;
            this.Level = Level;
            this.Description = Description;
        }

        public object Clone()
        {
            Talent newTalent = new Talent(Name, IsRacialTalent, Level, Description);
            return newTalent;
        }
    }
}
