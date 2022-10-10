using UnityEngine;

namespace Tiles
{
    public class BoardSettings
    {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public Vector2 TileDimensions { get; set; }
        public Vector2 Offset { get; set; }
    }
}