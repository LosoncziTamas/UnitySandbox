using Logging;
using UnityEngine;

namespace Singleton
{
    public class MultiSceneSingletonBehaviour : MonoBehaviour
    {
        public static MultiSceneSingletonBehaviour Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("MultiSceneSingletonBehaviour").AddComponent<MultiSceneSingletonBehaviour>();
                    DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }
        
        private static MultiSceneSingletonBehaviour _instance;

        private int _counter = 0;
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                // Preserve on scene change
                DontDestroyOnLoad(gameObject);
            }
            
            LoggingUtils.PrettyPrint(this, "Awake");
        }

        public void Increment()
        {
            _counter++;
            LoggingUtils.PrettyPrint(this, _counter.ToString());
        }

        private void OnDestroy()
        {
            LoggingUtils.PrettyPrint(this, "OnDestroy");
        }
    }
}