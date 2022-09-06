using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Scripts
{
    public class Tetromino : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetrominos _tetrominos;
        [SerializeField] private Sensor _rotationTestSensor;
        [SerializeField] private List<TetrominoPiece> _downwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _upwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _leftwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _rightwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _allPieces;
        
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            var currentPosition = _transform.position;
            currentPosition.y = _playFieldSettings.SpawnPosition.y;
            _transform.position = currentPosition;
            _tetrominos.Add(this);
        }

        private void OnDestroy()
        {
            _tetrominos.Remove(this);
        }

        private bool AllPiecesCanMoveInDirection(Direction direction, List<TetrominoPiece> piecesToTest)
        {
            foreach (var piece in piecesToTest)
            {
                if (!piece.CanMoveInDirection(direction))
                {
                    return false;
                }
            }
            return true;
        }

        public bool MoveLeft()
        {
            var rotation = GetRotation();
            List<TetrominoPiece> piecesToTest = null;
            if (Mathf.Approximately(0, rotation))
            {
                piecesToTest = _leftwardFacingPieces;
            }
            if (Mathf.Approximately(90, rotation))
            {
                piecesToTest = _upwardFacingPieces;
            }
            if (Mathf.Approximately(180, rotation))
            {
                piecesToTest = _rightwardFacingPieces;
            }
            if (Mathf.Approximately(270, rotation))
            {
                piecesToTest = _downwardFacingPieces;
            }
            var canMove = AllPiecesCanMoveInDirection(Direction.Left, piecesToTest);
            if (canMove)
            {
                _transform.Translate(Vector3.left * _playFieldSettings.MovementSize, Space.World);
            }
            return canMove;
        }
        
        public bool MoveRight()
        {
            var rotation = GetRotation();
            List<TetrominoPiece> piecesToTest = null;
            if (Mathf.Approximately(0, rotation))
            {
                piecesToTest = _rightwardFacingPieces;
            }
            if (Mathf.Approximately(90, rotation))
            {
                piecesToTest = _downwardFacingPieces;
            }
            if (Mathf.Approximately(180, rotation))
            {
                piecesToTest = _leftwardFacingPieces;
            }
            if (Mathf.Approximately(270, rotation))
            {
                piecesToTest = _upwardFacingPieces;
            }
            var canMove = AllPiecesCanMoveInDirection(Direction.Right, piecesToTest);
            if (canMove)
            {
                _transform.Translate(Vector3.right * _playFieldSettings.MovementSize, Space.World);
            }
            return canMove;
        }

        private float GetRotation()
        {
            return transform.rotation.eulerAngles.z;
        }
        
        public bool MoveDown()
        {
            var rotation = GetRotation();
            List<TetrominoPiece> piecesToTest = null;
            if (Mathf.Approximately(0, rotation))
            {
                piecesToTest = _downwardFacingPieces;
            }
            if (Mathf.Approximately(90, rotation))
            {
                piecesToTest = _leftwardFacingPieces;
            }
            if (Mathf.Approximately(180, rotation))
            {
                piecesToTest = _upwardFacingPieces;
            }
            if (Mathf.Approximately(270, rotation))
            {
                piecesToTest = _rightwardFacingPieces;
            }
            var canMove = AllPiecesCanMoveInDirection(Direction.Down, piecesToTest);
            if (canMove)
            {
                _transform.Translate(Vector3.down * _playFieldSettings.MovementSize, Space.World);
            }
            else
            {
                
            }
            return canMove;
        }

        private bool AnyPieceIsColliding()
        {
            foreach (var piece in _allPieces)
            {
                if (piece.Colliding())
                {
                    Debug.Break();
                    return true;
                }
            }

            return false;
        }

        public IEnumerator Rotate()
        {
            transform.Rotate(Vector3.forward, 90);
            yield return new WaitForFixedUpdate();
            while (AnyPieceIsColliding())
            {
                transform.Rotate(Vector3.forward, 90);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
