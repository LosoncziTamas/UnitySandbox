using System.Collections;
using UnityEngine;

namespace Fundamentals
{
    public class InstantiateObject : MonoBehaviour
    {
        public float delayInSeconds;
        
        [SerializeField] private GameObject _objectPrefab;

        private void Awake()
        {
            StartCoroutine(InstantiatePrefab(delayInSeconds));
        }

        private IEnumerator InstantiatePrefab(float delay)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(_objectPrefab);
        }
    }
}