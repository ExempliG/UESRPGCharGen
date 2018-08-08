using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESRPG_Character_Manager.Common;
using UESRPG_Character_Manager.Controllers;
using UESRPG_Character_Manager.CharacterComponents;
using UESRPG_Character_Manager.GameComponents;

namespace UESRPG_Character_Manager.Controllers
{
    public class IOController : Singleton<IOController>
    {
        private string _currentFile;

        /// <summary>
        /// Performs the saving of a Character list.
        /// </summary>
        /// <param name="filename">The filename to save the list as.</param>
        public bool SaveChar(string filename, out string message)
        {
            SaveFile save = new SaveFile(CharacterController.Instance.CharacterDict, GameController.Instance.CombatDict);
            bool result = save.SaveToFilename(filename, out message);

            return result;
        }

        /// <summary>
        /// Handle the loading of a Character list.
        /// </summary>
        public bool LoadChar(string filename, out string message)
        {
            SaveFile save = SaveFile.LoadFilename(filename, out bool result, out message);

            if (result)
            {
                save.UpdateCharactersAndCombats();

                Dictionary<uint, Character> characterDict = save.GetCharacterDict();
                CharacterController.Instance.SetCharDict(characterDict);

                Dictionary<uint, Combat> combatDict = save.GetCombatDict();
                GameController.Instance.SetCombatDict(combatDict);
            }

            return result;
        }
    }
}
