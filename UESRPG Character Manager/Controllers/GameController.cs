using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.Controllers
{
    /// <summary>
    /// The GameController class handles game mechanics not explicitly related to Character handling, such as the creation of Spell,
    /// Weapon, and Armor objects as well as roll calculations.
    /// </summary>
    class GameController
    {
        private static GameController _instance;
        private static bool _isInitialized = false;

        public static GameController Instance
        {
            get
            {
                if (!_isInitialized)
                {
                    _instance = new GameController();
                    _isInitialized = true;
                }
                return _instance;
            }
        }
    }
}
