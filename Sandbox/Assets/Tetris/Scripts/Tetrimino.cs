using System;
using UnityEngine;

namespace Tetris.Scripts
{
    public class Tetrimino : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetriminos _tetriminos;
        
        [SerializeField] private Sensor _leftSensor;
        [SerializeField] private Sensor _rightSensor;
        [SerializeField] private Sensor _bottomSensor;
        [SerializeField] private Sensor _topSensor;
        
        [SerializeField] private Transform _meshContainer;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            var currentPosition = _transform.position;
            currentPosition.y = _playFieldSettings.SpawnPosition.y;
            _transform.position = currentPosition;
            _tetriminos.Add(this);
        }

        private void OnDestroy()
        {
            _tetriminos.Remove(this);
        }

        public bool MoveLeft()
        {
            var canMove = !_leftSensor.Colliding;
            if (canMove)
            {
                _transform.Translate(Vector3.left * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        public bool MoveRight()
        {
            var canMove = !_rightSensor.Colliding;
            if (canMove)
            {
                _transform.Translate(Vector3.right * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        private static readonly Vector3 RotatedBy90 = Vector3.forward * 90; 
        private static readonly Vector3 RotatedBy180 = Vector3.forward * 180; 
        private static readonly Vector3 RotatedBy270 = Vector3.forward * 270; 
        private static readonly Vector3 RotatedBy0 = Vector3.zero;
        
        private bool CanMoveDown()
        {
            var canMove = true;
            if (_meshContainer.rotation.eulerAngles == RotatedBy90)
            {
                canMove = !_leftSensor.Colliding;
            }
            else if (_meshContainer.rotation.eulerAngles == RotatedBy180)
            {
                canMove = !_topSensor.Colliding;
            }
            else if (_meshContainer.rotation.eulerAngles == RotatedBy270)
            {
                canMove = !_rightSensor.Colliding;
            }
            else if (_meshContainer.rotation.eulerAngles == RotatedBy0)
            {
                canMove = !_bottomSensor.Colliding;
            }

            return canMove;
        }

        public bool MoveDown()
        {
            var canMove = CanMoveDown();
            if (canMove)
            {
                _transform.Translate(Vector3.down * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        public void Rotate()
        {
            _meshContainer.Rotate(Vector3.forward, 90);
        }
        
    }
}
