using UnityEngine;

namespace Tetris.Scripts
{
    public class Sensor : MonoBehaviour
    {
        public bool Colliding { get; private set; }
        
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