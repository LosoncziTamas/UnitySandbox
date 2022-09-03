using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Scripts
{
    public class Tetromino : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetrominos _tetrominos;
        [SerializeField] private List<TetrominoPiece> _downwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _upwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _leftwardFacingPieces;
        [SerializeField] private List<TetrominoPiece> _rightwardFacingPieces;
        
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
            var rotation = transform.rotation.y;
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
            var rotation = transform.rotation.y;
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
        
        public bool MoveDown()
        {
            var rotation = transform.rotation.y;
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
        
        public bool Rotate()
        {
            // TODO: check if rotation should be performed
            transform.Rotate(Vector3.forward, 90);
            return true;
        }
    }
}
