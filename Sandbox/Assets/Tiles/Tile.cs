using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Tile : MonoBehaviour
    {
        public Vector2Int BoardPosition { get; private set; }

        private TileManager _tileManager;
        
        public void Init(TileManager tileManager, Vector2Int boardPosition)
        {
            _tileManager = tileManager;
            BoardPosition = boardPosition;

        }
    }
}
