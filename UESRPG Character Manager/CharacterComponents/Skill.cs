using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;

namespace UESRPG_Character_Manager.CharacterComponents
{
    /// <summary>
    /// Embodies a generic Skill.
    /// </summary>
    /// <todo>Skills should be able to calculate their own difficulty.</todo>
    public class Skill : ICloneable
    {
        public static uint NextAvailableId { get; set; }

        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute()]
        public int Rank { get; set; }
        public string Description { get; set; }
        public int[] Characteristics { get; set; }
        public bool isDefaultSkill = false;
        [XmlIgnore(), Browsable(false)]
        public uint SkillId { get; private set; }

        public Skill()
        {
            // Assign each skill a unique ID. This is used for skill editing purposes.
            SkillId = NextAvailableId;
            NextAvailableId++;

            Characteristics = new int[0];
        }

        // A constructor used for duplicating Skill objects in the Clone method
        private Skill(uint skillId)
        {
            SkillId = skillId;

            Characteristics = new int[0];
        }

        public override string ToString()
        {
            return Name;
        }

        public object Clone()
        {
            Skill s = new Skill(this.SkillId);

            s.Name = this.Name;
            s.Rank = this.Rank;
            s.Description = this.Description;
            s.Characteristics = (int[])this.Characteristics.Clone();
            s.isDefaultSkill = this.isDefaultSkill;

            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Skill))
            {
                return false;
            }

            Skill s = (Skill)obj;

            return
            (
                s.Name == this.Name &&
                s.Rank == this.Rank &&
                s.Description == this.Description &&
                s.Characteristics.SequenceEqual(Characteristics) &&
                s.isDefaultSkill == this.isDefaultSkill
            );
        }
    }
}
