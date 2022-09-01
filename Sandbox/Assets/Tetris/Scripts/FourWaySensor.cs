using UnityEngine;

namespace Tetris.Scripts
{
    public class FourWaySensor : MonoBehaviour
    {
        private const float NoRotation = 0f;
        private const float RotatedBy90 = 90f;
        private const float RotatedBy180 = 180f;
        private const float RotatedBy270 = 270f;
        
        [SerializeField] private Sensor _bottomSensor;
        [SerializeField] private Sensor _leftSensor;
        [SerializeField] private Sensor _rightSensor;
        [SerializeField] private Sensor _topSensor;

        public bool CanMoveLeft()
        {
            var currentRotation = transform.rotation.eulerAngles.z;
            if (Mathf.Approximately(NoRotation, currentRotation))
            {
                return !_leftSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy90, currentRotation))
            {
                return !_topSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy180, currentRotation))
            {
                return !_rightSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy270, currentRotation))
            {
                return !_bottomSensor.Colliding;
            }
            return true;
        }
        
        public bool CanMoveDown()
        {
            var currentRotation = transform.rotation.eulerAngles.z;
            if (Mathf.Approximately(NoRotation, currentRotation))
            {
                return !_bottomSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy90, currentRotation))
            {
                return !_leftSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy180, currentRotation))
            {
                return !_topSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy270, currentRotation))
            {
                return !_rightSensor.Colliding;
            }
            return true;
        }
        
        public bool CanMoveRight()
        {
            var currentRotation = transform.rotation.eulerAngles.z;
            if (Mathf.Approximately(NoRotation, currentRotation))
            {
                return !_rightSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy90, currentRotation))
            {
                return !_bottomSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy180, currentRotation))
            {
                return !_leftSensor.Colliding;
            }
            if (Mathf.Approximately(RotatedBy270, currentRotation))
            {
                return !_topSensor.Colliding;
            }
            return true;
        }
    }
}