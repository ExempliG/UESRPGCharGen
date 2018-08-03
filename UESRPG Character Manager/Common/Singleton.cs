using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.Common
{
    public class Singleton<T> where T : new()
    {
        protected static T s_instance;
        private static bool _isInitialized = false;
        public static T Instance
        {
            get
            {
                if(!_isInitialized)
                {
                    s_instance = new T();
                    _isInitialized = true;
                }
                return s_instance;
            }
        }
    }
}
