using System.Collections;
using Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singleton
{
    public class SingletonClient : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(UseSingleton());
            // StartCoroutine(ReloadScene());
        }

        private IEnumerator ReloadScene()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(5.0f);
                SceneManager.LoadScene("SingletonScene");
                LoggingUtils.ClearLog();
            }
        }
        
        private IEnumerator UseSingleton()
        {
            while (isActiveAndEnabled)
            {
                MultiSceneSingletonBehaviour.Instance.Increment();
                yield return new WaitForSeconds(2.0f);
            }
        }
    }
}