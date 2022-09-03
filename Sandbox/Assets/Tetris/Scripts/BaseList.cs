using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Scripts
{
    public abstract class BaseList<T> : ScriptableObject where T : MonoBehaviour
    {
        protected readonly List<T> list = new();

        public void Add(T t)
        {
            list.Add(t);
        }

        public bool Remove(T t)
        {
            return list.Remove(t);
        }
    }
}