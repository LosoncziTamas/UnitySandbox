using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Tetris.Scripts
{
    public class Sensor : MonoBehaviour
    {
        public bool Colliding => _colliders.Count > 0;

        private readonly List<Collider> _colliders = new();

        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _drawGizmo;
        [SerializeField] public List<GameObject> _objectsToIgnore;

        [CanBeNull] private BoxCollider _boxCollider;

        private void Awake()
        {
            _objectsToIgnore ??= new List<GameObject>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (CanCollide(other.gameObject))
            {
                _colliders.Add(other);
            }
        }

        private bool CanCollide(GameObject other)
        {
            return _layerMask.Contains(other.layer) && !_objectsToIgnore.Contains(other);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (CanCollide(other.gameObject) && !_colliders.Remove(other))
            {
                Debug.LogError($"[{this.GetFullPathToObject()}] Collider removal failed.");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (CanCollide(collision.gameObject))
            {
                _colliders.Add(collision.collider);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (CanCollide(collision.gameObject) && !_colliders.Remove(collision.collider))
            {
                Debug.LogError($"[{this.GetFullPathToObject()}] Collider removal failed.");
            }
        }

        private void OnDrawGizmos()
        {
            if (!_drawGizmo)
            {
                return;
            }
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