using UnityEngine;

namespace Tetris.Scripts
{
    public class Tetrimino : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetriminos _tetriminos;
        [SerializeField] private FourWaySensor _fourWaySensor;

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
            var canMove = _fourWaySensor.CanMoveLeft();
            if (canMove)
            {
                _transform.Translate(Vector3.left * _playFieldSettings.MovementSize, Space.World);
            }
            return canMove;
        }
        
        public bool MoveRight()
        {
            var canMove = _fourWaySensor.CanMoveRight();
            if (canMove)
            {
                _transform.Translate(Vector3.right * _playFieldSettings.MovementSize, Space.World);
            }
            return canMove;
        }
        
        public bool MoveDown()
        {
            var canMove = _fourWaySensor.CanMoveDown();
            if (canMove)
            {
                _transform.Translate(Vector3.down * _playFieldSettings.MovementSize, Space.World);
            }
            else
            {
                var breakHere = 5.0;
            }
            return canMove;
        }
        
        public void Rotate()
        {
            transform.Rotate(Vector3.forward, 90);
        }
    }
}
