using UnityEngine;
using UnityEngine.EventSystems;

namespace Tiles
{
    [RequireComponent(typeof(Tile))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Renderer))]
    public class HighlightTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private BoardSettings _boardSettings;
        [SerializeField] private bool _walkable;

        private Color _originalColor;
        
        // TODO: fix event
        public void OnPointerEnter(PointerEventData eventData)
        {
            _originalColor = _renderer.material.color;
            _renderer.material.color = _walkable ? _boardSettings.WalkableTileColor : _boardSettings.NonWalkableTileColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _renderer.material.color = _originalColor;
        }
    }
}