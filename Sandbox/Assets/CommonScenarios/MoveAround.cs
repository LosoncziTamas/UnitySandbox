using UnityEngine;

namespace CommonScenarios
{
    public class MoveAround : MonoBehaviour
    {
        public GameObject target;
        
        public float distance;
        public float speed;

        private void Start()
        {
            Debug.Assert(target, "Target is not set in the inspector.");
            Debug.Assert(distance > 0.0f, "Incorrect distance value.");
            Debug.Assert(speed > 0.0f, "Incorrect speed value.");
        }

        private void Update()
        {
            var targetTrans = target.transform;
            // Calculating the offset.
            var x = Mathf.Sin(Time.time * speed) * distance;
            var z = Mathf.Cos(Time.time * speed) * distance;
            // Transforming from the target's local to the world space.
            // So it's orientation is taken into account.
            transform.position = targetTrans.TransformVector(
                targetTrans.position + new Vector3(x, 0.0f, z)
            );
        }
    }
}
