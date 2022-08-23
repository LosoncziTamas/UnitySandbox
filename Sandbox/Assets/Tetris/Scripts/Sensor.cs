using UnityEngine;

namespace Tetris.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class Sensor : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        
        public bool Colliding { get; private set; }

        private void Awake()
        {
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            Colliding = true;
        }

        private void OnTriggerExit(Collider other)
        {
            Colliding = false;
        }
    }
}