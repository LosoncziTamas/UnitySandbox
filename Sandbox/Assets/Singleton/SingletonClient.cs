using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singleton
{
    public class SingletonClient : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(UseSingleton());
            StartCoroutine(ReloadScene());
        }

        private IEnumerator ReloadScene()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(5.0f);
                SceneManager.LoadScene("SingletonScene");
                ClearLog();
            }
        }
        
        private static void ClearLog()
        {
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method?.Invoke(new object(), null);
        }
        
        private IEnumerator UseSingleton()
        {
            while (isActiveAndEnabled)
            {
                SingleSceneSingletonBehaviour.Instance.Increment();
                yield return new WaitForSeconds(2.0f);
            }
        }
    }
}