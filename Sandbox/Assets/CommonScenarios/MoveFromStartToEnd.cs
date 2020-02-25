using UnityEngine;

namespace CommonScenarios
{
    public class MoveFromStartToEnd : MonoBehaviour
    {
        public Transform start;
        public Transform end;
        
        public float targetTimeInSeconds;
        
        private float _timeElapsed;

        private void Start()
        {
            Debug.Assert(targetTimeInSeconds > 0.0f, "Target time is not positive.");
            _timeElapsed = 0.0f;
        }

        private void Update()
        {
            if (_timeElapsed >= targetTimeInSeconds)
            {
                _timeElapsed = 0.0f;
            }
            _timeElapsed += Time.deltaTime;
            transform.transform.position = Vector3.Lerp(
                start.position, 
                end.position, 
                _timeElapsed / targetTimeInSeconds
            );
        }
    }
}