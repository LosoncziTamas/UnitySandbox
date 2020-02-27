using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class LoadSceneTest : MonoBehaviour
    {
        private AsyncOperation sceneLoad;
        
        void Start()
        {
            
            sceneLoad = SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            // sceneLoad.allowSceneActivation = false;
            sceneLoad.completed += SceneLoadOnCompleted;
            
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByBuildIndex(0));
            
            SceneManager.sceneUnloaded += SceneManagerOnSceneUnloaded;
            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        }

        private void SceneLoadOnCompleted(AsyncOperation obj)
        {
            Debug.Log("Scene load completed.");
        }


        private void Update()
        {
            Debug.Log(sceneLoad.progress);
        }

        private void SceneManagerOnSceneUnloaded(Scene arg0)
        {
            Debug.Log("SceneManagerOnSceneUnloaded" + arg0);
        }        
        
        private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log("SceneManagerOnSceneLoaded" + arg0);
        }

        private void OnDestroy()
        {
            Debug.Log("OnDestroy");
        }
    }
}
