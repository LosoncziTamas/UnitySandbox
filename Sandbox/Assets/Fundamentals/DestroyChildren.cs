using UnityEngine;

namespace Fundamentals
{
    public class DestroyChildren : MonoBehaviour
    {
        private void Start()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}