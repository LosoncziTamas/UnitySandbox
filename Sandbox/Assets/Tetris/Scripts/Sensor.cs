using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Tetris.Scripts
{
    public class Sensor : MonoBehaviour
    {
        public bool Colliding => _colliders.Count > 0;

        private readonly List<Collider> _colliders = new();

        [CanBeNull] private BoxCollider _boxCollider;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        // TODO: support using different layers
        private void OnTriggerEnter(Collider other)
        {
            _colliders.Add(other);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!_colliders.Remove(other))
            {
                Debug.LogError($"[{this.GetFullPathToObject()}] Collider removal failed.");
            }
        }

        private void OnDrawGizmos()
        {
            if (Colliding)
            {
                foreach (var c in _colliders)
                {
                    var bounds = c.bounds;
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(bounds.center, bounds.size);
                    if (_boxCollider)
                    {
                        Gizmos.color = Color.magenta;
                        Gizmos.DrawCube(_boxCollider.transform.TransformPoint(_boxCollider.center), _boxCollider.size);
                    }
                }
            }
        }
    }
}