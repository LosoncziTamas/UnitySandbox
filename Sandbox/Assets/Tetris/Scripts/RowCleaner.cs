using UnityEngine;

namespace Tetris.Scripts
{
    public class RowCleaner : MonoBehaviour
    {
        private const int PieceCountPerRow = 10;
        
        [SerializeField] private Collider _collider;

        private readonly Collider[] _colliders = new Collider[16];
        
        private void OnGUI()
        {
            GUILayout.Space(100);
            if (GUILayout.Button("Overlap test"))
            {
                var bounds = _collider.bounds;
                var tetriminoLayer = LayerMask.GetMask("Tetrimino");
                var overlapCount = Physics.OverlapBoxNonAlloc(bounds.center, bounds.extents, _colliders, Quaternion.identity, tetriminoLayer);
                if (overlapCount == PieceCountPerRow)
                {
                    for (var colliderIndex = 0; colliderIndex < overlapCount; colliderIndex++)
                    {
                        var overlappingCollider = _colliders[colliderIndex];
                        Destroy(overlappingCollider.gameObject);
                    }  
                    // TODO: check again and shift
                }
            }
        }
    }
}