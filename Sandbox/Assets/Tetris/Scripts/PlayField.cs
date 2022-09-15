using System.Collections;
using UnityEngine;

namespace Tetris.Scripts
{
    public class PlayField : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetrominos _tetrominos;
        [SerializeField] private RowCleaner _rowCleaner;

        public bool IsUpdating { get; private set; }

        private Tetromino _currentPiece;
        private float _accumulator;
        
        private void OnGUI()
        {
            if (GUILayout.Button("Start Level"))
            {
                StartLevel();
            }
            if (GUILayout.Button("Clear Level"))
            {
                _rowCleaner.Clear(0);
            }
        }

        public void StartLevel()
        {
            IsUpdating = true;
            _currentPiece = _tetrominos.SpawnRandom();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _currentPiece.MoveLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _currentPiece.MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentPiece.Rotate();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // TODO: move to the latest pos
            }

            if (IsUpdating)
            {
                _accumulator += Time.deltaTime;
                if (_accumulator >= _playFieldSettings.TickDurationInSeconds)
                {
                    UpdateGame();
                }
            }
        }
        
        
        
                
        private void UpdateGame()
        {
            _accumulator = 0;
            var pieceGrounded = !_currentPiece.MoveDown();
            if (pieceGrounded)
            {
                _currentPiece = _tetrominos.SpawnRandom();
                _rowCleaner.Clear(0.0f);
            }
        }
    }
}