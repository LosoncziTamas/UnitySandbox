using UnityEngine;

namespace Tiles
{
    [CreateAssetMenu]
    public class BoardSettings : ScriptableObject
    {
        [SerializeField] private int _rowCount;
        [SerializeField] private int _columnCount;
        [SerializeField] private Vector2 _tileDimensions;
        [SerializeField] private Vector2 _offset;
        [SerializeField] private Color _walkableTileHighlightTint;
        [SerializeField] private Color _nonWalkableTileHighlightTint;
        
        public int RowCount => _rowCount;
        public int ColumnCount => _columnCount;
        public Vector2 TileDimensions => _tileDimensions;
        public Vector2 Offset => _offset;
        public Color WalkableTileColor => _walkableTileHighlightTint;
        public Color NonWalkableTileColor => _nonWalkableTileHighlightTint;
    }
}