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

        private void Awake()
        {
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
                transform.Translate(Vector3.left * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        public bool MoveRight()
        {
            var canMove = !_rightSensor.Colliding;
            if (canMove)
            {
                transform.Translate(Vector3.right * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        public bool MoveDown()
        {
            var canMove = !_bottomSensor.Colliding;
            if (canMove)
            {
                transform.Translate(Vector3.down * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        public void Rotate()
        {
            
        }
        
    }
}
