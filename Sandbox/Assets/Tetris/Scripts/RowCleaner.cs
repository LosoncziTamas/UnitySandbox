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

        private void OnGUI()
        {
            GUILayout.Space(100);
            if (GUILayout.Button("Clear level"))
            {
                StartCoroutine(Clear());
            }
        }
        
        private IEnumerator ShiftPieces(int startRowIndex)
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
                    // TODO: move individual pieces
                }

                yield return new WaitForSeconds(1.0f);
            }
        }

        private IEnumerator Clear()
        {
            for (var i = 0; i < MaxRowCount; i++)
            {
                if (CheckRow(i))
                {
                    yield return new WaitForSeconds(1.0f);
                    yield return ShiftPieces(i + 1);
                }
            }
        }

        private bool CheckRow(int rowIndex)
        {
            var bounds = _collider.bounds;
            var center = bounds.center + rowIndex * ShiftOffset;
            var overlapCount = Physics.OverlapBoxNonAlloc(center, bounds.extents, _colliders, Quaternion.identity, _tetriminoLayer);
            var clearRow = overlapCount == PieceCountPerRow;
            Debug.Log("CheckRow overlapCount " + overlapCount);
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