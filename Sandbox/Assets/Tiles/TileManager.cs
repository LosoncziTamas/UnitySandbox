using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private BoardSettings _boardSettings;
        
        private Tile[] _tiles;

        private void Start()
        {
            SetupBoard();
        }

        public void SetupBoard()
        {
            _tiles = new Tile[_boardSettings.ColumnCount * _boardSettings.RowCount];
            for (var x = 0; x < _boardSettings.ColumnCount; x++)
            {
                for (var y = 0; y < _boardSettings.RowCount; y++)
                {
                    var position = new Vector3(x + _boardSettings.Offset.x, y + _boardSettings.Offset.y, 0);
                    var tile = Instantiate(_tilePrefab, position, Quaternion.identity, transform);
                    tile.Init(this, new Vector2Int(x, y));
                    _tiles[x * _boardSettings.ColumnCount + y] = tile;
                }
            }
        }
        
        public List<Tile> DetermineAdjacentTiles(Vector2Int boardPosition)
        {
            var potentialAdjacentBoardPositions = new List<Vector2Int>
            {
                new (boardPosition.x - 1, boardPosition.y),
                new (boardPosition.x - 1, boardPosition.y - 1),
                new (boardPosition.x - 1, boardPosition.y + 1),
                new (boardPosition.x, boardPosition.y + 1),
                new (boardPosition.x, boardPosition.y - 1),
                new (boardPosition.x + 1, boardPosition.y),
                new (boardPosition.x + 1, boardPosition.y - 1),
                new (boardPosition.x + 1, boardPosition.y + 1)
            };
            var result = new List<Tile>();
            foreach (var position in potentialAdjacentBoardPositions)
            {
                if (InsideBoardBounds(position))
                {
                    result.Add(GetTile(position));
                }
            }
            return result;
        }

        private bool InsideBoardBounds(Vector2 positionOnBoard)
        {
            var columnCheck = positionOnBoard.x >= 0 && positionOnBoard.x < _boardSettings.ColumnCount;
            var rowCheck = positionOnBoard.y >= 0 && positionOnBoard.y < _boardSettings.RowCount;
            return columnCheck && rowCheck;
        }
        
        public Tile GetTile(Vector2Int positionOnBoard)
        {
            Debug.Assert(positionOnBoard.x >= 0 && positionOnBoard.x < _boardSettings.ColumnCount, $"x: {positionOnBoard.x}");
            Debug.Assert(positionOnBoard.y >= 0 && positionOnBoard.y < _boardSettings.RowCount, $"y: {positionOnBoard.y}");
            var result = _tiles[positionOnBoard.x * _boardSettings.ColumnCount + positionOnBoard.y];
            return result;
        }
    }
}