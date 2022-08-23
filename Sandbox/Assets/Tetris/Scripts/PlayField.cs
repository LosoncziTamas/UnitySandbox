using System;
using System.Collections;
using UnityEngine;

namespace Tetris.Scripts
{
    public class PlayField : MonoBehaviour
    {
        [SerializeField] private PlayFieldSettings _playFieldSettings;
        [SerializeField] private Tetriminos _tetriminos;
        
        public bool IsUpdating { get; private set; }

        private YieldInstruction _waitYield;
        private Tetrimino _currentPiece;

        private void Awake()
        {
            _waitYield = new WaitForSeconds(_playFieldSettings.TickDurationInSeconds);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Level"))
            {
                StartLevel();
            }
        }

        public void StartLevel()
        {
            IsUpdating = true;
            _currentPiece = _tetriminos.SpawnRandom();
            StartCoroutine(GameLoop());
        }

        private IEnumerator GameLoop()
        {
            while (IsUpdating)
            {
                if (!_currentPiece.MoveDown())
                {
                    _currentPiece = _tetriminos.SpawnRandom();
                }
                yield return _waitYield;
            }
        }

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            if (horizontal < 0)
            {
                _currentPiece.MoveLeft();
            }
            else if (horizontal > 0)
            {
                _currentPiece.MoveRight();
            }
        }
    }
}