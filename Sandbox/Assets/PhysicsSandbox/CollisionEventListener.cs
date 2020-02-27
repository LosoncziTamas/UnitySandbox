using UnityEngine;

namespace PhysicsSandbox
{
    public class CollisionEventListener : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"OnCollisionEnter for {gameObject.name}");
        }

        private void OnCollisionExit(Collision other)
        {
            Debug.Log($"OnCollisionExit for {gameObject.name}");
        }

        private void OnCollisionStay(Collision other)
        {
            Debug.Log($"OnCollisionStay for {gameObject.name}");
        }
    }
}