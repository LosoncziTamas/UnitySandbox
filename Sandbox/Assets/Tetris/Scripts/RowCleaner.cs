using System;
using UnityEngine;

namespace Tetris.Scripts
{
    public class RowCleaner : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        private readonly Collider[] _colliders = new Collider[14];
        
        private void OnGUI()
        {
            GUILayout.Space(100);
            if (GUILayout.Button("Overlap test"))
            {
                var bounds = _collider.bounds;
                var overlapCount = Physics.OverlapBoxNonAlloc(bounds.center, bounds.extents, _colliders, Quaternion.identity, LayerMask.NameToLayer("Sensor"));
                if (overlapCount > 0)
                {
                    Debug.Log("overlap count " + overlapCount);
                }
            }
        }
    }
}