using System;
using UnityEngine;

namespace Tetris.Scripts
{
    public class TetrominoPiece : MonoBehaviour
    {
        [SerializeField] private FourWaySensor _fourWaySensor;
        [SerializeField] private Sensor _collisionSensor;

        public bool CanMoveInDirection(Direction direction)
        {
            return direction switch
            {
                Direction.Left => _fourWaySensor.CanMoveLeft(),
                Direction.Right => _fourWaySensor.CanMoveRight(),
                Direction.Down => _fourWaySensor.CanMoveDown(),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public bool Colliding()
        {
            return _collisionSensor.Colliding;
        }
    }
}