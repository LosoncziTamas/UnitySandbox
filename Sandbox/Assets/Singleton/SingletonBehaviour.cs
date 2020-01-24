using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singleton
{
    public class SingletonBehaviour : MonoBehaviour
    {
        public static SingletonBehaviour Instance
        {
            get => _instance;
            private set
            {
                if (_instance != null)
                {
                    Destroy(_instance.gameObject);
                    Debug.LogWarning("There is already an existing SingletonBehaviour instance.");
                }
                
                _instance = value;
                DontDestroyOnLoad(_instance.gameObject);
            }
        }

        private static SingletonBehaviour _instance;

        private void Awake()
        {
            StartCoroutine(ReloadScene());
            Debug.Log("Awake called");
            Instance = this;
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(4.0f);
            SceneManager.LoadScene("SingletonScene");
        }
    }

}

