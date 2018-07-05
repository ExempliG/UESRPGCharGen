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

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The CharacterController class handles all things dealing explicitly with Character objects, such as managing inventory, accessing stats,
    /// and saving/loading the Character list.
    /// </summary>
    public class CharacterController
    {
        #region Event definitions
        public delegate void SelectedCharacterChangedHandler(object sender, SelectedCharacterChangedEventArgs e);
        [Description("Fires when the selected character changes.")]
        public event SelectedCharacterChangedHandler SelectedCharacterChanged;

        public delegate void CharacterListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the list of characters is changed, either by adding characters or loading a new file.")]
        public event CharacterListChangedHandler CharacterListChanged;
        #endregion

        public static uint SelectorId { get; private set; }
        public const uint DEFAULT_SELECTOR_ID = 0;
        private Dictionary<uint, uint> _activeSelectors;

        private static CharacterController _instance;
        private static bool _isInitialized;

        private string _currentFile;
        private Dictionary<uint, Character> _characterDict;

        public CharacterController()
        {
            _characterDict = new Dictionary<uint, Character>();
            SelectorId = 0;
            _activeSelectors = new Dictionary<uint, uint>();
        }

        public static CharacterController Instance
        {
            get
            {
                if (!_isInitialized)
                {
                    _instance = new CharacterController();
                    _isInitialized = true;
                }
                return _instance;
            }
        }

        public Dictionary<uint, Character> CharacterDict
        {
            get { return _characterDict; }
        }

        public void SelectCharacter(uint characterId, uint selectorId)
        {
            Character c = GetCharacterById(characterId);
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
                throw new ArgumentOutOfRangeException("id", id, "You stink");
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

        public Character AddCharacter()
        {
            Character newChar = new Character();
            newChar.Update();
            _characterDict.Add(newChar.CharacterId, newChar);

            return newChar;
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

        /// <summary>
        /// Performs the saving of a Character list.
        /// </summary>
        /// <param name="fileName">The filename to save the list as.</param>
        public bool SaveChar(string fileName, out string message)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(fileName))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Character>));
                FileStream fs = new FileStream(fileName, FileMode.Create);
                try
                {
                    List<Character> charList = new List<Character>();
                    foreach (Character c in _characterDict.Values)
                    {
                        c.EngVersion = Program.CURRENT_ENG_VERSION;
                        c.MinorVersion = Program.CURRENT_MINOR_VERSION;
                        c.MajorVersion = Program.CURRENT_MINOR_VERSION;
                        charList.Add(c);
                    }

                    xml.Serialize(fs, charList);
                    _currentFile = fileName;

                    message = "Success.";
                    result = true;
                }
                catch (IOException e)
                {
                    message = string.Format("File was not saved successfully for reason:\n{0}", e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                message = "Invalid fileName.";
            }

            return result;
        }

        /// <summary>
        /// Handle the loading of a Character list.
        /// </summary>
        public bool LoadChar(string fileName, out string message)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(fileName))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Character>));
                FileStream fs = new FileStream(fileName, FileMode.Open);

                // Grab the current "next" IDs, in case the load fails.
                uint skillIdPlaceholder = Skill.NextAvailableId;
                uint spellIdPlaceholder = Spell.NextAvailableId;
                uint weaponIdPlaceholder = Weapon.NextAvailableId;
                uint characterIdPlaceholder = Character.NextAvailableId;
                try
                {
                    // Reset the ID indices, since the previous character list is discarded.
                    Skill.NextAvailableId = 0;
                    Spell.NextAvailableId = 0;
                    Weapon.NextAvailableId = 0;
                    Character.NextAvailableId = 0;
                    List<Character> loadedList = (List<Character>)xml.Deserialize(fs);

                    _currentFile = fileName;

                    Dictionary<uint, Character> charDict = new Dictionary<uint, Character>();
                    foreach (Character c in loadedList)
                    {
                        // Perform any necessary updates.
                        c.Update();
                        charDict.Add(c.CharacterId, c);
                    }

                    _characterDict = charDict;

                    onSelectedCharacterChanged(0, DEFAULT_SELECTOR_ID, CharacterSelectionEvent.NO_CHARACTER);
                    onCharacterListChanged();
                    message = "Success.";
                    result = true;
                }
                catch (IOException e)
                {
                    message = string.Format("Failed to load character(s) for reason: {0}", e.Message);
                    // Load failed, restore the old highest IDs so there are no collisions if the user wants to
                    // continue with the current character list.
                    Skill.NextAvailableId = skillIdPlaceholder;
                    Spell.NextAvailableId = spellIdPlaceholder;
                    Weapon.NextAvailableId = weaponIdPlaceholder;
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                message = "Invalid fileName.";
            }

            return result;
        }

        #region Event callers
        protected void onSelectedCharacterChanged(uint characterId, uint selectorId, CharacterSelectionEvent eventType)
        {
            SelectedCharacterChanged?.Invoke(this, new SelectedCharacterChangedEventArgs(characterId, selectorId, eventType));
        }

        protected void onCharacterListChanged()
        {
            CharacterListChanged?.Invoke(this, new System.EventArgs());
        }
        #endregion
    }
}
