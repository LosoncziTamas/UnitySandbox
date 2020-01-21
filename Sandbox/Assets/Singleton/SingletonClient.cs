using UnityEngine;

namespace Singleton
{
    public class SingletonClient : MonoBehaviour
    {
        private void Awake()
        {
            Singleton.Instance.Initialize();
        }
    }
}