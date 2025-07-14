using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_SRRPG
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T? _instance;

        protected virtual void Initialize() { }

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                _instance = new T();
                _instance.Initialize();

                return _instance;
            }
        }
    }
}
