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
    class SaveFile
    {
        public List<Character> Characters;
        public List<Combat> Combats;

        public SaveFile(Dictionary<uint, Character> characters, Dictionary<uint, Combat> combats)
        {
            Characters = new List<Character>();
            foreach(Character c in characters.Values)
            {
                Characters.Add(c);
            }

            Combats = new List<Combat>();
            foreach(Combat c in combats.Values)
            {
                Combats.Add(c);
            }
        }

        public SaveFile(List<Character> characters, List<Combat> combats)
        {
            Characters = characters;
            Combats = combats;
        }

        public SaveFile()
        {
            Characters = new List<Character>();
            Combats = new List<Combat>();
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

        private static void ResetCharacterComponentIds()
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
