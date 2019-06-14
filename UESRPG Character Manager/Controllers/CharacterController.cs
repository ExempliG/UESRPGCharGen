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
using UESRPG_Character_Manager.CharacterComponents.Character;
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
        private Dictionary<uint, Guid> _activeSelectors;

        private Dictionary<Guid, Character> _characterDict;

        // I'm so sorry
        private Dictionary<uint, Dictionary<Guid, Character>> _otherDicts;
        public static uint CharacterListId { get; private set; }

        public CharacterController()
        {
            _characterDict = new Dictionary<Guid, Character>();
            SelectorId = 0;
            _activeSelectors = new Dictionary<uint, Guid>();
            _otherDicts = new Dictionary<uint, Dictionary<Guid, Character>>();
            CharacterListId = 0;
        }

        public void SetCharDict(Dictionary<Guid, Character> dict)
        {
            _characterDict = dict;
            onCharacterListChanged();

            foreach (uint selectorId in _activeSelectors.Keys)
            {
                Guid selectedChar = _activeSelectors[selectorId];

                if (_characterDict.Count == 0)
                {
                    onSelectedCharacterChanged(Guid.Empty, selectorId, CharacterSelectionEvent.NO_CHARACTER);
                }
                else
                {
                    onSelectedCharacterChanged(selectedChar, selectorId, CharacterSelectionEvent.NEW_CHARACTER);
                }
            }
        }

        public Dictionary<Guid, Character> CharacterDict
        {
            get { return _characterDict; }
        }

        public void SubscribeToCharacter( Guid guid, Character.CharacterChangedHandler h )
        {
            Character c = GetCharacterByGuid( guid );
            c.CharacterChanged += h;
        }

        public void UnsubscribeFromCharacter( Guid guid, Character.CharacterChangedHandler h )
        {
            Character c = GetCharacterByGuid( guid );
            c.CharacterChanged -= h;
        }

        public void SelectCharacter(int index, uint selectorId)
        {
            if (index >= 0)
            {
                Character c = GetCharacterByIndex(index);
                _activeSelectors[selectorId] = c.Guid;
                onSelectedCharacterChanged(c.Guid, selectorId, CharacterSelectionEvent.NEW_CHARACTER);
            }
            else
            {
                onSelectedCharacterChanged(Guid.Empty, selectorId, CharacterSelectionEvent.NO_CHARACTER);
            }
        }

        public void SelectCharacterById(Guid characterGuid, uint selectorId)
        {
            Character c = GetCharacterByGuid(characterGuid);
            _activeSelectors[selectorId] = characterGuid;
            onSelectedCharacterChanged(characterGuid, selectorId, CharacterSelectionEvent.NEW_CHARACTER);
        }

        public void DeselectCharacter(uint selectorId)
        {
            onSelectedCharacterChanged(Guid.Empty, selectorId, CharacterSelectionEvent.NO_CHARACTER);
        }

        public Character GetCharacterByGuid(Guid guid)
        {
            if(_characterDict.ContainsKey(guid))
            {
                return _characterDict[guid];
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", guid, CharacterControllerExceptionMessages.InvalidCharacterId);
            }
        }

        public Character GetCharacterByGuidFromList(Guid charGuid, uint listId)
        {
            Dictionary<Guid, Character> otherDict = GetCharacterDict(listId);
            if(otherDict.ContainsKey(charGuid))
            {
                return otherDict[charGuid];
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

        public Dictionary<Guid, Character> GetCharacterDict(uint listId)
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
            _activeSelectors.Add(newSelectorId, Guid.Empty);
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
            _otherDicts.Add(newListId, new Dictionary<Guid, Character>());
            return newListId;
        }

        public uint StartCharacterList(List<Character> charList)
        {
            uint newListId = CharacterListId;
            CharacterListId++;

            Dictionary<Guid, Character> charDict = new Dictionary<Guid, Character>();
            foreach(Character c in charList)
            {
                charDict.Add(c.Guid, c);
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
            _characterDict.Add(newChar.Guid, newChar);
            onCharacterListChanged(newChar.Guid, CharacterListChangedEvent.NEW_CHARACTER);

            return newChar;
        }

        /// <summary>
        /// Adds a character from an ancillary list to the main list.
        /// </summary>
        /// <param name="fromList"></param>
        /// <param name="fromGuid"></param>
        /// <returns></returns>
        public Character AddCharacter(uint fromList, Guid fromGuid)
        {
            if(_otherDicts.ContainsKey(fromList))
            {
                Character c = _otherDicts[fromList][fromGuid].DuplicateChar();

                if(_characterDict.ContainsKey(c.Guid))
                {
                    throw new ArgumentException("c.Id", "todo: What a weird exception");
                }
                _characterDict.Add(c.Guid, c);

                onCharacterListChanged(c.Guid, CharacterListChangedEvent.NEW_CHARACTER);
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
        /// <param name="fromGuid">The Character GUID to export</param>
        /// <param name="toList">The list ID to export to</param>
        /// <returns></returns>
        public Character ExportCharacter(Guid fromGuid, uint toList)
        {
            if(_otherDicts.ContainsKey(toList))
            {
                Character c = CharacterDict[fromGuid].DuplicateChar();

                if(_otherDicts[toList].ContainsKey(c.Guid))
                {
                    throw new ArgumentException("c.Id", "todo: What a weird exception");
                }
                _otherDicts[toList].Add(c.Guid, c);

                onCharacterListChanged(fromGuid, toList, CharacterListChangedEvent.NEW_CHARACTER);
                return c;
            }
            else
            {
                throw new ArgumentOutOfRangeException("toList", toList, "todo: This needs a unique exception message");
            }
        }

        public void RemoveCharacter(Guid charGuid)
        {
            foreach(uint selectorId in _activeSelectors.Keys)
            {
                if(_activeSelectors[selectorId] == charGuid)
                {
                    onSelectedCharacterChanged(Guid.Empty, selectorId, CharacterSelectionEvent.NO_CHARACTER);
                }
            }

            // Special handling, aimed at constructs which do more than simply display the selected character's info.
            onCharacterListChanged(charGuid, CharacterListChangedEvent.BEFORE_DELETE_CHARACTER);
            _characterDict.Remove(charGuid);
            onCharacterListChanged(Guid.Empty, CharacterListChangedEvent.AFTER_DELETE_CHARACTER);
        }

        public void AddSkill(Guid characterGuid, Skill skillToAdd)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.AddSkill(skillToAdd);
        }

        public void EditSkill(Guid characterGuid, Skill editedSkill)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.EditSkill(editedSkill);
        }

        public void DeleteSkill(Guid characterGuid, Skill skillToDelete)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.DeleteSkill(skillToDelete);
        }

        public void AddSpell(Guid characterGuid, Spell spellToAdd)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.AddSpell(spellToAdd);
        }

        public void EditSpell(Guid characterGuid, Spell editedSpell)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.EditSpell(editedSpell);
        }

        public void DeleteSpell(Guid characterGuid, Spell spellToDelete)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.DeleteSpell(spellToDelete);
        }

        public void AddWeapon(Guid characterGuid, Weapon weaponToAdd)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.AddWeapon(weaponToAdd);
        }

        public void EditWeapon(Guid characterGuid, Weapon weaponToEdit)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.EditWeapon(weaponToEdit);
        }

        public void DeleteWeapon(Guid characterGuid, Weapon weaponToDelete)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.DeleteWeapon(weaponToDelete);
        }

        public void ChangeCharacterName(Guid characterGuid, string newName)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.Name = newName;
            onCharacterListChanged();
        }

        public void ChangeCharacteristic(Guid characterGuid, int characteristicIndex, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.SetCharacteristic(characteristicIndex, value);
        }

        public void ChangeModifier(Guid characterGuid, int modifierIndex, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.SetModifier(modifierIndex, value);
        }

        public void ChangeHealth(Guid characterGuid, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.CurrentHealth = value;
        }

        public void ChangeMagicka(Guid characterGuid, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.CurrentMagicka = value;
        }

        public void ChangeStamina(Guid characterGuid, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.CurrentStamina = value;
        }

        public void ChangeAP(Guid characterGuid, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.CurrentAp = value;
        }

        public void ChangeLuck(Guid characterGuid, int value)
        {
            Character c = GetCharacterByGuid(characterGuid);
            c.CurrentLuckPoints = value;
        }

        public void ForceUpdate()
        {
            foreach (uint selectorId in _activeSelectors.Keys)
            {
                onSelectedCharacterChanged(Guid.Empty, selectorId, CharacterSelectionEvent.SAME_CHARACTER);
            }
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
        protected void onSelectedCharacterChanged(Guid characterGuid, uint selectorId, CharacterSelectionEvent eventType)
        {
            SelectedCharacterChanged?.Invoke(this, new SelectedCharacterChangedEventArgs(characterGuid, selectorId, eventType));
        }

        protected void onCharacterListChanged()
        {
            CharacterListChanged?.Invoke(this, new CharacterListChangedEventArgs(Guid.Empty, CharacterListChangedEvent.NEW_CHARACTER));
        }

        protected void onCharacterListChanged(Guid characterGuid, CharacterListChangedEvent eventType)
        {
            CharacterListChanged?.Invoke(this, new CharacterListChangedEventArgs(characterGuid, eventType));
        }

        protected void onCharacterListChanged(Guid characterGuid, uint listId, CharacterListChangedEvent eventType)
        {
            CharacterListChanged?.Invoke(this, new CharacterListChangedEventArgs(characterGuid, listId, eventType));
        }
        #endregion
    }
}
