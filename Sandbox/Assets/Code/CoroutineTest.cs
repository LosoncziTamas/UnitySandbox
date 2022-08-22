using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class CoroutineTest : MonoBehaviour
    {

        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Vector3 _destination;
        [SerializeField] private float _speed;
        
        private static IEnumerator<Vector3> MoveToDestination(GameObject objectToMove, Vector3 destination, float speed)
        {
            // Not at destination yet
            while (objectToMove.transform.position != destination)
            {
                // Move toward destination
                objectToMove.transform.position = Vector3.MoveTowards(
                    objectToMove.transform.position,
                    destination,
                    Time.deltaTime * speed
                );
 
                // Yield new position
                yield return objectToMove.transform.position;
            }
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Coroutine"))
            {
                StartCoroutine(MoveToDestination(_gameObject, _destination, _speed));
            }

            if (GUILayout.Button("Iterate Coroutine"))
            {
                var enumerator = MoveToDestination(_gameObject, _destination, _speed);
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    Debug.Log("Current " + current);
                }
            }
        }
    }
}