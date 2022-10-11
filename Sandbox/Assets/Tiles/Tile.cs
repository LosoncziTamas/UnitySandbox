using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Tile : MonoBehaviour
    {
        public Vector2Int BoardPosition { get; private set; }

        private List<Tile> _adjacentTiles = new();

        public void Init(TileManager tileManager, Vector2Int boardPosition)
        {
            BoardPosition = boardPosition;
            // _adjacentTiles = tileManager.DetermineAdjacentTiles(boardPosition);
        }
    }
}
