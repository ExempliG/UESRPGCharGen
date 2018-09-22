using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.Common;

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The CharacterController class handles all things dealing explicitly with Character objects, such as managing inventory, accessing stats,
    /// and saving/loading the Character list.
    /// </summary>
    public class CharacterController : Singleton<CharacterController>
    {
        #region Event definitions
        public delegate void SelectedCharacterChangedHandler(object sender, SelectedCharacterChangedEventArgs e);
        [Description("Fires when the selected character changes.")]
        public event SelectedCharacterChangedHandler SelectedCharacterChanged;

        public delegate void CharacterListChangedHandler(object sender, CharacterListChangedEventArgs e);
        [Description("Fires when the list of characters is changed, either by adding characters or loading a new file.")]
        public event CharacterListChangedHandler CharacterListChanged;
        #endregion

        public static uint SelectorId { get; private set; }
        public const uint DEFAULT_SELECTOR_ID = 0;
        private Dictionary<uint, uint> _activeSelectors;

        private Dictionary<uint, Character> _characterDict;

        // I'm so sorry
        private Dictionary<uint, Dictionary<uint, Character>> _otherDicts;
        public static uint CharacterListId { get; private set; }

        public CharacterController()
        {
            _characterDict = new Dictionary<uint, Character>();
            SelectorId = 0;
            _activeSelectors = new Dictionary<uint, uint>();
            _otherDicts = new Dictionary<uint, Dictionary<uint, Character>>();
            CharacterListId = 0;
        }

        public void SetCharDict(Dictionary<uint, Character> dict)
        {
            _characterDict = dict;
            onCharacterListChanged();

            foreach (uint selectorId in _activeSelectors.Keys)
            {
                uint selectedChar = _activeSelectors[selectorId];

                if (_characterDict.Count == 0)
                {
                    onSelectedCharacterChanged(0, selectorId, CharacterSelectionEvent.NO_CHARACTER);
                }
                else
                {
                    onSelectedCharacterChanged(0, selectorId, CharacterSelectionEvent.NEW_CHARACTER);
                }
            }
        }

        public Dictionary<uint, Character> CharacterDict
        {
            get { return _characterDict; }
        }

        public void SelectCharacter(int index, uint selectorId)
        {
            if (index >= 0)
            {
                Character c = GetCharacterByIndex(index);
                _activeSelectors[selectorId] = c.Id;
                onSelectedCharacterChanged(c.Id, selectorId, CharacterSelectionEvent.NEW_CHARACTER);
            }
            else
            {
                onSelectedCharacterChanged(0, selectorId, CharacterSelectionEvent.NO_CHARACTER);
            }
        }

        public void SelectCharacterById(uint characterId, uint selectorId)
        {
            Character c = GetCharacterById(characterId);
            _activeSelectors[selectorId] = characterId;
            onSelectedCharacterChanged(characterId, selectorId, CharacterSelectionEvent.NEW_CHARACTER);
        }

        public void DeselectCharacter(uint selectorId)
        {
            onSelectedCharacterChanged(0, selectorId, CharacterSelectionEvent.NO_CHARACTER);
        }

        public Character GetCharacterById(uint id)
        {
            if(_characterDict.ContainsKey(id))
            {
                return _characterDict[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, CharacterControllerExceptionMessages.InvalidCharacterId);
            }
        }

        public Character GetCharacterByIdFromList(uint charId, uint listId)
        {
            Dictionary<uint, Character> otherDict = GetCharacterDict(listId);
            if(otherDict.ContainsKey(charId))
            {
                return otherDict[charId];
            }
            else
            {
                throw new ArgumentOutOfRangeException("charId", "todo: You stink");
            }
        }

        public Character GetCharacterByIndex(int index)
        {
            return CharacterDict.Values.ElementAt(index);
        }

        public Dictionary<uint, Character> GetCharacterDict(uint listId)
        {
            if(_otherDicts.ContainsKey(listId))
            {
                return _otherDicts[listId];
            }
            else
            {
                throw new ArgumentOutOfRangeException("listId", "todo: You stink");
            }
        }

        public uint StartSelector()
        {
            uint newSelectorId = SelectorId;
            SelectorId++;
            _activeSelectors.Add(newSelectorId, 0);
            return newSelectorId;
        }

        public void EndSelector(uint selectorId)
        {
            _activeSelectors.Remove(selectorId);
        }

        public uint StartCharacterList()
        {
            uint newListId = CharacterListId;
            CharacterListId++;
            _otherDicts.Add(newListId, new Dictionary<uint, Character>());
            return newListId;
        }

        public uint StartCharacterList(List<Character> charList)
        {
            uint newListId = CharacterListId;
            CharacterListId++;

            Dictionary<uint, Character> charDict = new Dictionary<uint, Character>();
            foreach(Character c in charList)
            {
                charDict.Add(c.Id, c);
            }
            _otherDicts.Add(newListId, charDict);

            return newListId;
        }

        public void EndCharacterList(uint charListId)
        {
            _otherDicts.Remove(charListId);
        }

        public Character AddCharacter()
        {
            Character newChar = new Character();
            newChar.UntrainedCheck();
            _characterDict.Add(newChar.Id, newChar);
            onCharacterListChanged(newChar.Id, CharacterListChangedEvent.NEW_CHARACTER);

            return newChar;
        }

        /// <summary>
        /// Adds a character from an ancillary list to the main list.
        /// </summary>
        /// <param name="fromList"></param>
        /// <param name="fromId"></param>
        /// <returns></returns>
        public Character AddCharacter(uint fromList, uint fromId)
        {
            if(_otherDicts.ContainsKey(fromList))
            {
                Character c = _otherDicts[fromList][fromId].CopyChar();

                if(_characterDict.ContainsKey(c.Id))
                {
                    throw new ArgumentException("c.Id", "todo: What a weird exception");
                }
                _characterDict.Add(c.Id, c);

                onCharacterListChanged(c.Id, CharacterListChangedEvent.NEW_CHARACTER);
                return c;
            }
            else
            {
                throw new ArgumentOutOfRangeException("fromList", fromList, CharacterControllerExceptionMessages.InvalidCharacterListId);
            }
        }

        /// <summary>
        /// Adds a character from the main list to an ancillary list.
        /// </summary>
        /// <param name="fromId">The Character ID to export</param>
        /// <param name="toList">The list ID to export to</param>
        /// <returns></returns>
        public Character ExportCharacter(uint fromId, uint toList)
        {
            if(_otherDicts.ContainsKey(toList))
            {
                Character c = CharacterDict[fromId].CopyChar();

                if(_otherDicts[toList].ContainsKey(c.Id))
                {
                    throw new ArgumentException("c.Id", "todo: What a weird exception");
                }
                _otherDicts[toList].Add(c.Id, c);

                onCharacterListChanged(fromId, toList, CharacterListChangedEvent.NEW_CHARACTER);
                return c;
            }
            else
            {
                throw new ArgumentOutOfRangeException("toList", toList, "todo: This needs a unique exception message");
            }
        }

        public void RemoveCharacter(uint charId)
        {
            foreach(uint selectorId in _activeSelectors.Keys)
            {
                if(_activeSelectors[selectorId] == charId)
                {
                    onSelectedCharacterChanged(0, selectorId, CharacterSelectionEvent.NO_CHARACTER);
                }
            }

            // Special handling, aimed at constructs which do more than simply display the selected character's info.
            onCharacterListChanged(charId, CharacterListChangedEvent.BEFORE_DELETE_CHARACTER);
            _characterDict.Remove(charId);
            onCharacterListChanged(0, CharacterListChangedEvent.AFTER_DELETE_CHARACTER);
        }

        public void AddSkill(uint characterId, Skill skillToAdd)
        {
            Character c = GetCharacterById(characterId);
            c.AddSkill(skillToAdd);
        }

        public void EditSkill(uint characterId, Skill editedSkill)
        {
            Character c = GetCharacterById(characterId);
            c.EditSkill(editedSkill);
        }

        public void DeleteSkill(uint characterId, Skill skillToDelete)
        {
            Character c = GetCharacterById(characterId);
            c.DeleteSkill(skillToDelete);
        }

        public void AddSpell(uint characterId, Spell spellToAdd)
        {
            Character c = GetCharacterById(characterId);
            c.AddSpell(spellToAdd);
        }

        public void EditSpell(uint characterId, Spell editedSpell)
        {
            Character c = GetCharacterById(characterId);
            c.EditSpell(editedSpell);
        }

        public void DeleteSpell(uint characterId, Spell spellToDelete)
        {
            Character c = GetCharacterById(characterId);
            c.DeleteSpell(spellToDelete);
        }

        public void AddWeapon(uint characterId, Weapon weaponToAdd)
        {
            Character c = GetCharacterById(characterId);
            c.AddWeapon(weaponToAdd);
        }

        public void EditWeapon(uint characterId, Weapon weaponToEdit)
        {
            Character c = GetCharacterById(characterId);
            c.EditWeapon(weaponToEdit);
        }

        public void DeleteWeapon(uint characterId, Weapon weaponToDelete)
        {
            Character c = GetCharacterById(characterId);
            c.DeleteWeapon(weaponToDelete);
        }

        public void ChangeCharacterName(uint characterId, string newName)
        {
            Character c = GetCharacterById(characterId);
            c.Name = newName;
            onCharacterListChanged();
        }

        public void ChangeCharacteristic(uint characterId, int characteristicIndex, int value)
        {
            Character c = GetCharacterById(characterId);
            c.SetCharacteristic(characteristicIndex, value);
        }

        public void ChangeModifier(uint characterId, int modifierIndex, int value)
        {
            Character c = GetCharacterById(characterId);
            c.SetModifier(modifierIndex, value);
        }

        public void ChangeHealth(uint characterId, int value)
        {
            Character c = GetCharacterById(characterId);
            c.CurrentHealth = value;
        }

        public void ChangeMagicka(uint characterId, int value)
        {
            Character c = GetCharacterById(characterId);
            c.CurrentMagicka = value;
        }

        public void ChangeStamina(uint characterId, int value)
        {
            Character c = GetCharacterById(characterId);
            c.CurrentStamina = value;
        }

        public void ChangeAP(uint characterId, int value)
        {
            Character c = GetCharacterById(characterId);
            c.CurrentAp = value;
        }

        public void ChangeLuck(uint characterId, int value)
        {
            Character c = GetCharacterById(characterId);
            c.CurrentLuckPoints = value;
        }

        public void ForceUpdate()
        {
            foreach (uint selectorId in _activeSelectors.Keys)
            {
                onSelectedCharacterChanged(0, selectorId, CharacterSelectionEvent.SAME_CHARACTER);
            }
        }

        private void resetCharacterComponentIds()
        {
            Character.NextAvailableId = 0;
            Power.NextAvailableId = 0;
            Skill.NextAvailableId = 0;
            Spell.NextAvailableId = 0;
            Talent.NextAvailableId = 0;
            Trait.NextAvailableId = 0;
            Weapon.NextAvailableId = 0;
        }

        private List<Character> readCharListFromFile(string fileName, out bool success, out string message)
        {
            success = false;
            List<Character> characters = new List<Character>();

            if (!string.IsNullOrEmpty(fileName))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Character>));
                FileStream fs = new FileStream(fileName, FileMode.Open);

                try
                {
                    characters = (List<Character>)xml.Deserialize(fs);
                    success = true;
                    message = "Success.";
                }
                catch(IOException e)
                {
                    message = string.Format("Failed to load character(s) for reason: {0}", e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                message = "Invalid filename.";
            }

            return characters;
        }

        #region Event callers
        protected void onSelectedCharacterChanged(uint characterId, uint selectorId, CharacterSelectionEvent eventType)
        {
            SelectedCharacterChanged?.Invoke(this, new SelectedCharacterChangedEventArgs(characterId, selectorId, eventType));
        }

        protected void onCharacterListChanged()
        {
            CharacterListChanged?.Invoke(this, new CharacterListChangedEventArgs(0, CharacterListChangedEvent.NEW_CHARACTER));
        }

        protected void onCharacterListChanged(uint characterId, CharacterListChangedEvent eventType)
        {
            CharacterListChanged?.Invoke(this, new CharacterListChangedEventArgs(characterId, eventType));
        }

        protected void onCharacterListChanged(uint characterId, uint listId, CharacterListChangedEvent eventType)
        {
            CharacterListChanged?.Invoke(this, new CharacterListChangedEventArgs(characterId, listId, eventType));
        }
        #endregion
    }
}
