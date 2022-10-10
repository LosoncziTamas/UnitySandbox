using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private Tile _tilePrefab;
        
        public BoardSettings Settings { get; private set; }

        private List<Tile> _tiles;

        public void Setup(BoardSettings settings)
        {
            _tiles = new List<Tile>(Settings.ColumnCount * Settings.RowCount);
            Settings = settings;
            for (var x = 0; x < Settings.ColumnCount; x++)
            {
                for (var y = 0; y < Settings.RowCount; y++)
                {
                    var position = new Vector3(x + Settings.Offset.x, y + Settings.Offset.y, 0);
                    var tile = Instantiate(_tilePrefab, position, Quaternion.identity, transform);
                    tile.Init(this, new Vector2Int(x, y));
                    _tiles[x * Settings.ColumnCount + y] = tile;
                }
            }
        }
        
        public List<Tile> DetermineAdjacentTiles(Vector2Int boardPosition)
        {
            var result = new List<Tile>();
            return result;
        }
        
        public Tile GetTile(Vector2Int pos)
        {
            Debug.Assert(pos.x >= 0 && pos.x < Settings.ColumnCount, $"x: {pos.x}");
            Debug.Assert(pos.y >= 0 && pos.y < Settings.RowCount, $"y: {pos.y}");
            var result = _tiles[pos.x * Settings.ColumnCount + pos.y];
            return result;
        }
    }
}