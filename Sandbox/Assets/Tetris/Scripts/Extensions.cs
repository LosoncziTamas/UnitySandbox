using UnityEditor;
using UnityEngine;

namespace Tetris.Scripts
{
    public static class Extensions
    {
        public static string GetFullPathToObject(this MonoBehaviour go)
        {
            var trans = go.transform;
            var root = trans.root;
            return $"{root.name}/{AnimationUtility.CalculateTransformPath(trans, root)}";
        }
    }
}