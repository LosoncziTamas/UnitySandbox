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

        public bool MoveDown()
        {
            var upsideDown = _meshContainer.rotation.eulerAngles == Vector3.forward * 180;
            var canMove = upsideDown ? !_topSensor.Colliding : !_bottomSensor.Colliding;
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
