using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.Common
{
    public class SaveFile
    {
        [XmlAttribute()]
        public int MajorRevision;
        [XmlAttribute()]
        public int MinorRevision;
        [XmlAttribute()]
        public int EngRevision;

        public List<Character> Characters;
        public List<CombatSave> Combats;

        public SaveFile(Dictionary<uint, Character> characters, Dictionary<uint, Combat> combats)
        {
            Characters = new List<Character>();
            foreach(Character c in characters.Values)
            {
                Characters.Add(c);
            }

            Combats = new List<CombatSave>();
            foreach(Combat c in combats.Values)
            {
                Combats.Add(CombatSave.MakeSave(c));
            }
        }

        public SaveFile(List<Character> characters, List<Combat> combats)
        {
            Characters = characters;
            Combats = new List<CombatSave>();
            foreach(Combat c in combats)
            {
                Combats.Add(CombatSave.MakeSave(c));
            }
        }

        public SaveFile()
        {
            Characters = new List<Character>();
            Combats = new List<CombatSave>();
        }

        public bool SaveToFilename(string filename, out string message)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(filename))
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                result = SaveToFile(fs, out message);
            }
            else
            {
                message = "Invalid fileName.";
            }

            return result;
        }

        public bool SaveToFile(FileStream fs, out string message)
        {
            bool result = false;

            if (fs.CanWrite)
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(SaveFile));
                    foreach (Character c in Characters)
                    {
                        c.EngVersion = Program.CURRENT_ENG_VERSION;
                        c.MinorVersion = Program.CURRENT_MINOR_VERSION;
                        c.MajorVersion = Program.CURRENT_MINOR_VERSION;
                    }

                    xml.Serialize(fs, this);

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
                message = "Invalid file mode.";
                fs.Close();
            }

            return result;
        }

        public static SaveFile LoadFilename(string filename, out bool success, out string message)
        {
            success = false;
            SaveFile save = new SaveFile();

            if (!string.IsNullOrEmpty(filename))
            {
                FileStream fs = new FileStream(filename, FileMode.Open);

                save = LoadFile(fs, out success, out message);
            }
            else
            {
                message = "Invalid filename.";
            }

            return save;
        }

        public static SaveFile LoadFile(FileStream fs, out bool success, out string message)
        {
            success = false;
            SaveFile save = new SaveFile();

            if (fs.CanRead)
            {
                XmlSerializer xml = new XmlSerializer(typeof(SaveFile));

                try
                {
                    save = (SaveFile)xml.Deserialize(fs);
                    success = true;
                    message = "Success.";
                }
                catch (InvalidOperationException e)
                {
                    // An attempt has already been made to read this file, so it is important to reset the read position before trying again.
                    fs.Seek(0, SeekOrigin.Begin);
                    List<Character> charList = ReadCharListFromFile(fs, out success, out message);
                    save = new SaveFile(charList, new List<Combat>());
                }
                catch (IOException e)
                {
                    message = string.Format("Failed to load save for reason: {0}", e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                message = "Invalid file mode.";
                fs.Close();
            }

            return save;
        }

        private static List<Character> ReadCharListFromFilename(string fileName, out bool success, out string message)
        {
            success = false;
            List<Character> characters = new List<Character>();

            if (!string.IsNullOrEmpty(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);

                characters = ReadCharListFromFile(fs, out success, out message);
            }
            else
            {
                message = "Invalid filename.";
            }

            return characters;
        }

        private static List<Character> ReadCharListFromFile(FileStream fs, out bool success, out string message)
        {
            success = false;
            List<Character> characters = new List<Character>();

            if (fs.CanRead)
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Character>));

                try
                {
                    characters = (List<Character>)xml.Deserialize(fs);
                    success = true;
                    message = "Success.";
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
                message = "Invalid file mode.";
            }

            return characters;
        }

        public Dictionary<uint, Character> GetCharacterDict()
        {
            Dictionary<uint, Character> charDict = new Dictionary<uint, Character>();

            foreach(Character c in Characters)
            {
                charDict.Add(c.Id, c);
            }

            return charDict;
        }

        public Dictionary<uint, Character> GetUpdatedCharacterDict()
        {
            Dictionary<uint, Character> charDict = new Dictionary<uint, Character>();

            resetCharacterComponentIdCounters();
            foreach (Character c in Characters)
            {
                // Perform any necessary updates.
                c.Update();
                c.ResetId();
                c.ResetIdentifiableIds();
                charDict.Add(c.Id, c);
            }

            return charDict;
        }

        private void resetCharacterComponentIdCounters()
        {
            Character.NextAvailableId = 0;
            Power.NextAvailableId = 0;
            Skill.NextAvailableId = 0;
            Spell.NextAvailableId = 0;
            Talent.NextAvailableId = 0;
            Trait.NextAvailableId = 0;
            Weapon.NextAvailableId = 0;
        }
    }
}
