using System.Collections.Generic;
using System.Linq;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public List<Talent> Talents
        {
            get { return _talents; }
        }

        public void AddTalent(Talent newTalent)
        {
            _talents.Add(newTalent);
        }

        public void EditTalent(Talent newTalent)
        {
            IEnumerable<Talent> talentSearch = from Talent t in _talents
                                               where t.Guid == newTalent.Guid
                                               select t;
            if (talentSearch.Count() == 1)
            {
                Talent currentTalent = talentSearch.ElementAt(0);
                int talentIndex = Talents.IndexOf(currentTalent);
                Talents[talentIndex] = newTalent;

                onTalentListChanged();
            }
        }

        public void DeleteTalent(Talent talentToDelete)
        {
            _talents.Remove(talentToDelete);

            onTalentListChanged();
        }
    }
}
