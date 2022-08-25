using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Scripts
{
    [CreateAssetMenu]
    public class Tetriminos : ScriptableObject
    {
        private readonly List<Tetrimino> _tetriminos = new();

        [SerializeField] private List<Tetrimino> _prefabs;
        
        public void Add(Tetrimino tetrimino)
        {
            _tetriminos.Add(tetrimino);
        }

        public bool Remove(Tetrimino tetrimino)
        {
            return _tetriminos.Remove(tetrimino);
        }

        public Tetrimino SpawnRandom()
        {
            // TODO: implement random selection
            // TODO: implement positioning
            var tetrimino = Instantiate(_prefabs[0]);
            return tetrimino;
        }
    }
}