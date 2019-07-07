using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using UESRPG_Character_Manager.CharacterComponents.Character;
using UESRPG_Character_Manager.Items;
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.Common
{
    public partial class SaveFile
    {
        private struct Version
        {
            public int MajorRevision;
            public int MinorRevision;
            public int EngRevision;
            public int Release;

            public Version( int MajorRevision, int MinorRevision, int EngRevision, int Release )
            {
                this.MajorRevision = MajorRevision;
                this.MinorRevision = MinorRevision;
                this.EngRevision = EngRevision;
                this.Release = Release;
            }

            public static bool operator < ( Version a, Version b )
            {
                return (a.MajorRevision < b.MajorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision < b.MinorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision < b.EngRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision == b.EngRevision && a.Release < b.Release);
            }

            public static bool operator > ( Version a, Version b )
            {
                return (a.MajorRevision > b.MajorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision > b.MinorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision > b.EngRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision == b.EngRevision && a.Release > b.Release);
            }

            public static bool operator <= ( Version a, Version b )
            {
                return (a.MajorRevision <= b.MajorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision <= b.MinorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision <= b.EngRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision == b.EngRevision && a.Release <= b.Release);
            }

            public static bool operator >= ( Version a, Version b )
            {
                return (a.MajorRevision >= b.MajorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision >= b.MinorRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision >= b.EngRevision) ||
                       (a.MajorRevision == b.MajorRevision && a.MinorRevision == b.MinorRevision && a.EngRevision == b.EngRevision && a.Release >= b.Release);
            }

            public override string ToString()
            {
                return string.Format("{0}.{1}.{2}-{3}", MajorRevision, MinorRevision, EngRevision, Release);
            }
        }

        [XmlAttribute()]
        public int MajorRevision
        {
            get
            {
                return _fileVersion.MajorRevision;
            }
            set
            {
                _fileVersion.MajorRevision = value;
            }
        }
        [XmlAttribute()]
        public int MinorRevision
        {
            get
            {
                return _fileVersion.MinorRevision;
            }
            set
            {
                _fileVersion.MinorRevision = value;
            }
        }
        [XmlAttribute()]
        public int EngRevision
        {
            get
            {
                return _fileVersion.EngRevision;
            }
            set
            {
                _fileVersion.EngRevision = value;
            }
        }
        [XmlAttribute()]
        public int Release
        {
            get
            {
                return _fileVersion.Release;
            }
            set
            {
                _fileVersion.Release = value;
            }
        }

        public List<Character> Characters;
        public List<CombatSave> Combats;
        private Version _fileVersion;

        public SaveFile(Dictionary<Guid, Character> characters, Dictionary<uint, Combat> combats)
        {
            Characters = new List<Character>();
            foreach(Character c in characters.Values)
            {
                Characters.Add(c);
            }

            Combats = new List<CombatSave>();
            foreach(Combat c in combats.Values)
            {
                Combats.Add(new CombatSave(c));
            }

            _fileVersion = new Version(Program.CURRENT_MAJOR_VERSION, Program.CURRENT_MINOR_VERSION, Program.CURRENT_ENG_VERSION, Program.CURRENT_RELEASE);
        }

        public SaveFile(Dictionary<Guid, Character> characters)
        {
            Characters = new List<Character>();
            foreach(Character c in characters.Values)
            {
                Characters.Add(c);
            }

            Combats = new List<CombatSave>();

            _fileVersion = new Version(Program.CURRENT_MAJOR_VERSION, Program.CURRENT_MINOR_VERSION, Program.CURRENT_ENG_VERSION, Program.CURRENT_RELEASE);
        }

        public SaveFile(List<Character> characters, List<Combat> combats)
        {
            Characters = characters;
            Combats = new List<CombatSave>();
            foreach(Combat c in combats)
            {
                Combats.Add(new CombatSave(c));
            }

            _fileVersion = new Version(Program.CURRENT_MAJOR_VERSION, Program.CURRENT_MINOR_VERSION, Program.CURRENT_ENG_VERSION, Program.CURRENT_RELEASE);
        }

        public SaveFile(List<Character> characters)
        {
            Characters = characters;
            Combats = new List<CombatSave>();

            _fileVersion = new Version(Program.CURRENT_MAJOR_VERSION, Program.CURRENT_MINOR_VERSION, Program.CURRENT_ENG_VERSION, Program.CURRENT_RELEASE);
        }

        public SaveFile()
        {
            Characters = new List<Character>();
            Combats = new List<CombatSave>();

            _fileVersion = new Version(Program.CURRENT_MAJOR_VERSION, Program.CURRENT_MINOR_VERSION, Program.CURRENT_ENG_VERSION, Program.CURRENT_RELEASE);
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
                    MajorRevision = Program.CURRENT_MAJOR_VERSION;
                    MinorRevision = Program.CURRENT_MINOR_VERSION;
                    EngRevision = Program.CURRENT_ENG_VERSION;

                    XmlSerializer xml = new XmlSerializer(typeof(SaveFile));
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
                // XmlDocument xml = new XmlDocument();
                // xml.Load(fs);
                XmlSerializer serializer = new XmlSerializer(typeof(SaveFile));

                try
                {
                    save = (SaveFile)serializer.Deserialize(fs);
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

        public Dictionary<Guid, Character> GetCharacterDict()
        {
            Dictionary<Guid, Character> charDict = new Dictionary<Guid, Character>();

            foreach(Character c in Characters)
            {
                charDict.Add(c.Guid, c);
            }

            return charDict;
        }

        public void UpdateCharacters()
        {
            foreach (Character c in Characters)
            {
                // Perform any necessary updates.
                c.Update(MajorRevision, MinorRevision, EngRevision);
            }
        }

        public Dictionary<uint, Combat> GetCombatDict()
        {
            Dictionary<uint, Combat> combatDict = new Dictionary<uint, Combat>();

            foreach(CombatSave cs in Combats)
            {
                Combat c = Combat.Restore(cs);
                combatDict.Add(c.CombatId, c);
            }

            return combatDict;
        }
    }
}
