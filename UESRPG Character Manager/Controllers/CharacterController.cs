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
        public delegate void SelectedCharacterChangingHandler(object sender, EventArgs e);
        [Description("Fires when the selected character is about to change.")]
        public event SelectedCharacterChangingHandler SelectedCharacterChanging;

        public delegate void SelectedCharacterChangedHandler(object sender, EventArgs e);
        [Description("Fires when the selected character changes.")]
        public event SelectedCharacterChangedHandler SelectedCharacterChanged;

        public delegate void CharacterListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the list of characters is changed, either by adding characters or loading a new file.")]
        public event CharacterListChangedHandler CharacterListChanged;

        protected void onSelectedCharacterChanging()
        {
            SelectedCharacterChanging?.Invoke(this, new System.EventArgs());
        }

        protected void onSelectedCharacterChanged()
        {
            SelectedCharacterChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onCharacterListChanged()
        {
            CharacterListChanged?.Invoke(this, new System.EventArgs());
        }
        #endregion

        private static CharacterController _instance;
        private static bool _isInitialized;

        private string _currentFile;
        private List<Character> _characterList;
        private Character _activeCharacter;

        public CharacterController()
        {
            _characterList = new List<Character>();
            _activeCharacter = new Character();
            _activeCharacter.Update();
            _characterList.Add(_activeCharacter);
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

        public Character ActiveCharacter
        {
            get { return _activeCharacter; }
        }

        public List<Character> CharacterList
        {
            get { return _characterList; }
        }

        public void Reset()
        {
            onSelectedCharacterChanging();
            Skill.NextAvailableId = 0;
            Spell.NextAvailableId = 0;
            Weapon.NextAvailableId = 0;
            _characterList = new List<Character>();
            _activeCharacter = new Character();
            _activeCharacter.Update();
            _characterList.Add(_activeCharacter);

            onCharacterListChanged();
            onSelectedCharacterChanged();
        }

        public bool SelectCharacter(uint index)
        {
            bool result = false;

            if (index < _characterList.Count)
            {
                onSelectedCharacterChanging();
                _activeCharacter = _characterList[(int)index];
                result = true;
                onSelectedCharacterChanged();
            }

            return result;
        }

        public Character AddCharacter()
        {
            Character newChar = new Character();
            newChar.Update();
            _characterList.Add(newChar);

            onCharacterListChanged();

            return newChar;
        }

        public void AddSkill(Skill skillToAdd)
        {
            _activeCharacter.AddSkill(skillToAdd);
        }

        public void EditSkill(Skill editedSkill)
        {
            _activeCharacter.EditSkill(editedSkill);
        }

        public void DeleteSkill(Skill skillToDelete)
        {
            _activeCharacter.DeleteSkill(skillToDelete);
        }

        public void AddSpell(Spell spellToAdd)
        {
            _activeCharacter.AddSpell(spellToAdd);
        }

        public void EditSpell(Spell editedSpell)
        {
            _activeCharacter.EditSpell(editedSpell);
        }

        public void DeleteSpell(Spell spellToDelete)
        {
            _activeCharacter.DeleteSpell(spellToDelete);
        }

        public void AddWeapon(Weapon weaponToAdd)
        {
            _activeCharacter.AddWeapon(weaponToAdd);
        }

        public void EditWeapon(Weapon weaponToEdit)
        {
            _activeCharacter.EditWeapon(weaponToEdit);
        }

        public void DeleteWeapon(Weapon weaponToDelete)
        {
            _activeCharacter.DeleteWeapon(weaponToDelete);
        }

        public void ChangeCharacterName(string newName)
        {
            _activeCharacter.Name = newName;
            onCharacterListChanged();
        }

        public void ChangeCharacteristic(int characteristicIndex, int value)
        {
            _activeCharacter.SetCharacteristic(characteristicIndex, value);
        }

        public void ChangeModifier(int modifierIndex, int value)
        {
            _activeCharacter.SetModifier(modifierIndex, value);
        }

        public void ChangeHealth(int value)
        {
            _activeCharacter.CurrentHealth = value;
        }

        public void ChangeMagicka(int value)
        {
            _activeCharacter.CurrentMagicka = value;
        }

        public void ChangeStamina(int value)
        {
            _activeCharacter.CurrentStamina = value;
        }

        public void ChangeAP(int value)
        {
            _activeCharacter.CurrentAp = value;
        }

        public void ChangeLuck(int value)
        {
            _activeCharacter.CurrentLuckPoints = value;
        }

        public void ForceUpdate()
        {
            onSelectedCharacterChanging();
            onSelectedCharacterChanged();
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
                    foreach (Character c in _characterList)
                    {
                        c.EngVersion = Program.CURRENT_ENG_VERSION;
                        c.MinorVersion = Program.CURRENT_MINOR_VERSION;
                        c.MajorVersion = Program.CURRENT_MINOR_VERSION;
                    }

                    xml.Serialize(fs, _characterList);
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
                onSelectedCharacterChanging();
                try
                {
                    // Reset the ID indices, since the previous character list is discarded.
                    Skill.NextAvailableId = 0;
                    Spell.NextAvailableId = 0;
                    Weapon.NextAvailableId = 0;
                    List<Character> loadedList = (List<Character>)xml.Deserialize(fs);

                    _currentFile = fileName;

                    foreach (Character c in loadedList)
                    {
                        // Perform any necessary updates.
                        c.Update();
                    }

                    _characterList = loadedList;
                    if (_characterList.Count > 0)
                    {
                        _activeCharacter = _characterList[0];
                    }
                    else
                    {
                        _activeCharacter = new Character();
                    }

                    onSelectedCharacterChanged();
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

        #endregion
    }
}
