using System.Collections.Generic;
using System.Linq;

namespace UESRPG_Character_Manager.CharacterComponents.Character
{
    partial class Character
    {
        public List<Spell> Spells
        {
            get { return _spells; }
        }

        public void AddSpell(Spell newSpell)
        {
            Spells.Add(newSpell);
            onSpellListChanged();
        }

        public void EditSpell(Spell newSpell)
        {
            IEnumerable<Spell> spellSearch = from Spell s in Spells
                                             where s.Guid == newSpell.Guid
                                             select s;
            if (spellSearch.Count() == 1)
            {
                Spell currentSpell = spellSearch.ElementAt(0);
                int spellIndex = Spells.IndexOf(currentSpell);
                Spells[spellIndex] = newSpell;

                onSpellListChanged();
            }
        }

        public void DeleteSpell(Spell spellToDelete)
        {
            Spells.Remove(spellToDelete);

            onSpellListChanged();
        }
    }
}
