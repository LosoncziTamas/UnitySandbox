using UnityEngine;

namespace Singleton
{
    public class SingleSceneSingletonBehaviour : MonoBehaviour
    {
        public static SingleSceneSingletonBehaviour Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Create an instance when referenced from script
                    var go = new GameObject("NaiveSingletonBehaviour", typeof(SingleSceneSingletonBehaviour));
                    _instance = go.GetComponent<SingleSceneSingletonBehaviour>();
                }

                return _instance;
            }
        }

        private static SingleSceneSingletonBehaviour _instance;
        
        private int _counter;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                // If there are several scripts in the scene, we need to make sure only one instance remains.
                Debug.LogWarning($"There is an existing singleton instance.");
                Destroy(this);
            }
        }

        public void Increment()
        {
            // A method that changes the internal state.
            _counter++;
            Debug.Log($"Counter value: {_counter}");
        }

        private void OnDestroy()
        {
            Debug.Log($"Destroying singleton component at {gameObject.name}.");
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}