using UnityEngine;

namespace Singleton
{
    public class Singleton
    {
        private static Singleton _instance;
        
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    Instance = new Singleton();
                }

                return _instance;
            }

            private set
            {
                if (_instance != null)
                {
                    Debug.LogWarning("Singleton already created.");
                }

                _instance = value;
            }
        }

        private Singleton()
        {
            Debug.Log("Singleton constructor.");
        }

        public void Initialize()
        {
            Debug.Log("Initialize");
        }
        
    }
}