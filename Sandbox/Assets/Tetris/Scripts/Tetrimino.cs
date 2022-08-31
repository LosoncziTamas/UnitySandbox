using UnityEngine;

namespace Tetris.Scripts
{
    public class Tetrimino : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetriminos _tetriminos;
        [SerializeField] private Transform _meshContainer;
        [SerializeField] private Transform _sensors;
        [SerializeField] private Sensor _bottomSensor;
        [SerializeField] private Sensor _leftSensor;
        [SerializeField] private Sensor _rightSensor;
        [SerializeField] private Sensor _topSensor;

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
            var canMove = CanMoveLeft();
            if (canMove)
            {
                _transform.Translate(Vector3.left * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        private bool CanMoveLeft()
        {
            return !_leftSensor.Colliding;
        }

        public bool MoveRight()
        {
            var canMove = CanMoveRight();
            if (canMove)
            {
                _transform.Translate(Vector3.right * _playFieldSettings.MovementSize);
            }
            return canMove;
        }
        
        private bool CanMoveRight()
        {
            return !_rightSensor.Colliding;
        }
        
        public bool MoveDown()
        {
            var canMove = CanMoveDown();
            if (canMove)
            {
                _transform.Translate(Vector3.down * _playFieldSettings.MovementSize);
            }
            else
            {
                var breakHere = 5.0;
            }
            return canMove;
        }
        
        private bool CanMoveDown()
        {
            return !_bottomSensor.Colliding;
        }

        public void Rotate()
        {
            _meshContainer.Rotate(Vector3.forward, 90);
            _sensors.Rotate(Vector3.forward, 90);
        }
    }
}
