using UnityEngine;

namespace Tetris.Scripts
{
    [CreateAssetMenu]
    public class PlayFieldSettings : ScriptableObject
    {
        public float TickDurationInSeconds;
        public float MovementSize;
        public Vector2 SpawnPosition;
    }
}