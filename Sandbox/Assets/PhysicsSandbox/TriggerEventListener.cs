using UnityEngine;

namespace PhysicsSandbox
{
    public class TriggerEventListener : MonoBehaviour
    {        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter for {gameObject.name}");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnTriggerExit for {gameObject.name}");
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnTriggerStay for {gameObject.name}");
        }
    }
}
