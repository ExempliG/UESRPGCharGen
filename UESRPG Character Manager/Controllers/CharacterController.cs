using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The CharacterController class handles all things dealing explicitly with Character objects, such as managing inventory, accessing stats,
    /// and saving/loading the Character list.
    /// </summary>
    class CharacterController
    {
        public delegate void SelectedCharacterChangedHandler(object sender, EventArgs e);
        [Description("Fires when the selected character changes.")]
        public event SelectedCharacterChangedHandler SelectedCharacterChanged;
        public delegate void CharacterListChangedHandler(object sender, EventArgs e);
        public event CharacterListChangedHandler CharacterListChanged;

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

        protected void onSelectedCharacterChanged()
        {
            // Invoke the event if subscribers exist
            SelectedCharacterChanged?.Invoke(this, new System.EventArgs());
        }

        protected void onCharacterListChanged()
        {
            CharacterListChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
