using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace UESRPG_Character_Manager.CharacterComponents
{
    /// <summary>
    /// Embodies a generic Spell.
    /// </summary>
    /// <todo>Add support for... *sigh* shadow magic.</todo>
    public class Spell
    {
        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute()]
        public int Level { get; set; }
        public int Cost { get; set; }
        public int Difficulty { get; set; }
        public string AssociatedSkill { get; set; }
        public string Description { get; set; }
        public bool DoesDamage { get; set; }
        public int NumberOfDice { get; set; }
        public int DiceSides { get; set; }
        public int Penetration { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
