using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

using UESRPG_Character_Manager.Items;

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The CharacterController class handles all things dealing explicitly with Character objects, such as managing inventory, accessing stats,
    /// and saving/loading the Character list.
    /// </summary>
    class CharacterController
    {
        #region Event definitions
        public delegate void SelectedCharacterChangedHandler(object sender, EventArgs e);
        [Description("Fires when the selected character changes.")]
        public event SelectedCharacterChangedHandler SelectedCharacterChanged;

        public delegate void CharacterListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the list of characters is changed, either by adding characters or loading a new file.")]
        public event CharacterListChangedHandler CharacterListChanged;

        public delegate void CharacteristicChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Characteristics is changed by the user.")]
        public event CharacteristicChangedHandler CharacteristicChanged;

        public delegate void AttributeChangedHandler(object sender, EventArgs e);
        [Description("Fires when one of the Attributes is changed by the user.")]
        public event AttributeChangedHandler AttributeChanged;

        public delegate void SkillListChangedHandler(object sender, EventArgs e);
        [Description("Fires when a skill is added, removed, or edited.")]
        public event SkillListChangedHandler SkillListChanged;

        public delegate void SpellListChangedHandler(object sender, EventArgs e);
        [Description("Fires when the spell list changes via adding or renaming a spell.")]
        public event SpellListChangedHandler SpellListChanged;

        public delegate void WeaponsChangedHandler(object sender, EventArgs e);
        [Description("Fires when a Weapon is changed or added by the user.")]
        public event WeaponsChangedHandler WeaponsChanged;
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

        public bool SelectCharacter(uint index)
        {
            bool result = false;

            if (index < _characterList.Count)
            {
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

            return newChar;
        }

        public void AddSkill(Skill skillToAdd)
        {
            _activeCharacter.Skills.Add(skillToAdd);
            onSkillListChanged();
        }

        public void DeleteSkill(Skill skillToDelete)
        {
            _activeCharacter.DeleteSkill(skillToDelete);
            onSkillListChanged();
            onSpellListChanged(); // Deletion of a Skill marks all Spells which used that Skill with "Untrained"
        }

        public void AddSpell(Spell spellToAdd)
        {
            _activeCharacter.Spells.Add(spellToAdd);
            onSpellListChanged();
        }

        public void AddWeapon(Weapon weaponToAdd)
        {
            _activeCharacter.Weapons.Add(weaponToAdd);
            onWeaponsChanged();
        }

        public void ChangeCharacterName(string newName)
        {
            _activeCharacter.Name = newName;
            onCharacterListChanged();
        }

        public void ChangeCharacteristic(int characteristicIndex, int value)
        {
            _activeCharacter.SetCharacteristic(characteristicIndex, value);
            onCharacteristicChanged();
        }

        public void ChangeModifier(int modifierIndex, int value)
        {
            _activeCharacter.SetModifier(modifierIndex, value);

            // As modifiers modify attributes, changing a modifier subsequently changes an attribute.
            onAttributeChanged();
        }

        public void ChangeHealth(int value)
        {
            _activeCharacter.CurrentHealth = value;
            onAttributeChanged();
        }

        public void ChangeMagicka(int value)
        {
            _activeCharacter.CurrentMagicka = value;
            onAttributeChanged();
        }

        public void ChangeStamina(int value)
        {
            _activeCharacter.CurrentStamina = value;
            onAttributeChanged();
        }

        public void ChangeAP(int value)
        {
            _activeCharacter.CurrentAp = value;
            onAttributeChanged();
        }

        public void ChangeLuck(int value)
        {
            _activeCharacter.CurrentLuckPoints = value;
            onAttributeChanged();
        }

        public void ForceUpdate()
        {
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

                try
                {
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
        protected void onSelectedCharacterChanged()
        {
            SelectedCharacterChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onCharacterListChanged()
        {
            CharacterListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onCharacteristicChanged()
        {
            CharacteristicChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onAttributeChanged()
        {
            AttributeChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onSkillListChanged()
        {
            SkillListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onSpellListChanged()
        {
            SpellListChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onWeaponsChanged()
        {
            WeaponsChanged?.Invoke(this, new System.EventArgs());
        }
        #endregion
    }
}
