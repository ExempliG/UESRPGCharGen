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
    /// Embodies a generic Spell.
    /// </summary>
    /// <todo>Add support for... *sigh* shadow magic.</todo>
    public class Spell : ICloneable
    {
        public static uint NextAvailableId { get; set; }

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

        [XmlIgnore(), Browsable(false)]
        public uint SpellId { get; private set; }

        public Spell()
        {
            SpellId = NextAvailableId;
            NextAvailableId++;
        }

        private Spell(uint spellId)
        {
            SpellId = spellId;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public object Clone()
        {
            Spell s = new Spell(this.SpellId);

            s.Name = this.Name;
            s.Level = this.Level;
            s.Cost = this.Cost;
            s.Difficulty = this.Difficulty;
            s.AssociatedSkill = this.AssociatedSkill;
            s.Description = this.Description;
            s.DoesDamage = this.DoesDamage;
            s.NumberOfDice = this.NumberOfDice;
            s.DiceSides = this.DiceSides;
            s.Penetration = this.Penetration;

            return s;
        }
    }
}
