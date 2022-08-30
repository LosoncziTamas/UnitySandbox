using System;
using UnityEngine;

namespace Tetris.Scripts
{
    public class Tetrimino : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetriminos _tetriminos;
        [SerializeField] private Transform _meshContainer;
        [SerializeField] private Sensor _ghostMesh;

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
            var canMove = CanMoveInDirection(Vector3.left, _ghostMesh.transform);
            if (canMove)
            {
                _transform.Translate(Vector3.left * _playFieldSettings.MovementSize);
            }
            return canMove;
        }

        public bool MoveRight()
        {
            var canMove = CanMoveInDirection(Vector3.right, _ghostMesh.transform);
            if (canMove)
            {
                _transform.Translate(Vector3.right * _playFieldSettings.MovementSize);
            }
            return canMove;
        }
        
        public bool MoveDown()
        {
            var canMove = CanMoveInDirection(Vector3.down, _ghostMesh.transform);
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
        
        private bool CanMoveInDirection(Vector3 direction, Transform trans)
        {
            var originalPos = trans.position;
            trans.Translate(direction * _playFieldSettings.MovementSize, Space.World);
            var result = !_ghostMesh.Colliding;
            trans.position = originalPos;
            return result;
        }

        public void Rotate()
        {
            _meshContainer.Rotate(Vector3.forward, 90);
            _ghostMesh.transform.Rotate(Vector3.forward, 90);
        }
    }
}
