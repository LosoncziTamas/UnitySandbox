using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Scripts
{
    [CreateAssetMenu]
    public class Tetrominos : BaseList<Tetromino>
    {
        [SerializeField] private List<Tetromino> _prefabs;
        
        public Tetromino SpawnRandom()
        {
            // TODO: implement random selection
            // TODO: implement positioning
            var tetrimino = Instantiate(_prefabs[0]);
            return tetrimino;
        }
    }
}