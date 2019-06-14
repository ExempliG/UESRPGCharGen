using System.Collections.Generic;
using System.Linq;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public List<Skill> Skills
        {
            get { return _skills; }
        }

        public void AddSkill(Skill newSkill)
        {
            Skills.Add(newSkill);
            onSkillListChanged();
        }

        public void EditSkill(Skill newSkill)
        {
            IEnumerable<Skill> skillSearch = from Skill s in Skills
                                             where s.Guid == newSkill.Guid
                                             select s;
            if (skillSearch.Count() == 1)
            {
                Skill currentSkill = skillSearch.ElementAt(0);
                int skillIndex = Skills.IndexOf(currentSkill);
                updateSpellSkills(currentSkill.Name, newSkill.Name);
                Skills[skillIndex] = newSkill;

                onSkillListChanged();
            }
        }

        public void DeleteSkill(Skill skillToDelete)
        {
            updateSpellSkills(skillToDelete.Name, "Untrained");
            Skills.Remove(skillToDelete);

            onSkillListChanged();
        }

        private void updateSpellSkills(string oldSkillName, string newSkillName)
        {
            IEnumerable<Spell> relatedSpells = from Spell s in Spells
                                               where s.AssociatedSkill.Equals(oldSkillName)
                                               select s;
            foreach (Spell s in relatedSpells)
            {
                s.AssociatedSkill = newSkillName;
            }

            onSpellListChanged();
        }
    }
}
