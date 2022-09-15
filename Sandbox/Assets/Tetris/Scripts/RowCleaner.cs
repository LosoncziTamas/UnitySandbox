using System.Collections;
using UnityEngine;

namespace Tetris.Scripts
{
    public class RowCleaner : MonoBehaviour
    {
        private static readonly Vector3 ShiftOffset = Vector3.up;

        private const int MaxRowCount = 20;
        private const int PieceCountPerRow = 10;
        
        [SerializeField] private Collider _collider;

        private readonly Collider[] _colliders = new Collider[16];

        private int _tetriminoLayer;

        private void Awake()
        {
            _tetriminoLayer = LayerMask.GetMask("Tetrimino");
        }
        
        private IEnumerator ShiftPieces(int startRowIndex, float delayInSeconds)
        {
            var bounds = _collider.bounds;
            var keepShifting = true;
            for (var rowIndex = startRowIndex; rowIndex < MaxRowCount && keepShifting; ++rowIndex)
            {
                var center = bounds.center + rowIndex * ShiftOffset;
                var overlapCount = Physics.OverlapBoxNonAlloc(center, bounds.extents, _colliders, Quaternion.identity, _tetriminoLayer);
                keepShifting = overlapCount > 0;
                for (var i = 0; i < overlapCount; i++)
                {
                    var overlappingCollider = _colliders[i];
                    overlappingCollider.transform.position += Vector3.down;
                }
                yield return new WaitForSeconds(delayInSeconds);
            }
        }

        public void Clear(float delay)
        {
            StartCoroutine(ClearRoutine(delay));
        }
        
        private IEnumerator ClearRoutine(float delay)
        {
            for (var i = 0; i < MaxRowCount; i++)
            {
                if (CheckRow(i))
                {
                    Debug.Log($"Shift pieces starting at {i + 1}");
                    yield return ShiftPieces(i + 1, delay);
                }
            }
        }

        private bool CheckRow(int rowIndex)
        {
            var bounds = _collider.bounds;
            var center = bounds.center + rowIndex * ShiftOffset;
            var overlapCount = Physics.OverlapBoxNonAlloc(center, bounds.extents, _colliders, Quaternion.identity, _tetriminoLayer);
            var clearRow = overlapCount == PieceCountPerRow;
            if (clearRow)
            {
                for (var colliderIndex = 0; colliderIndex < overlapCount; colliderIndex++)
                {
                    var overlappingCollider = _colliders[colliderIndex];
                    Destroy(overlappingCollider.gameObject);
                }  
            }
            return clearRow;
        }
    }
}