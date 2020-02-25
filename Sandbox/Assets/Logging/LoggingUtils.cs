using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace Logging
{
    public static class LoggingUtils
    {
        [CanBeNull] private static MethodInfo _cachedClearLogRef;
        public static void ClearLog()
        {
#if UNITY_EDITOR
            if (_cachedClearLogRef == null)
            {
                var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
                var type = assembly.GetType("UnityEditor.LogEntries");
                _cachedClearLogRef = type.GetMethod("Clear");
            }
            else
            {
                _cachedClearLogRef.Invoke(new object(), null);
            }
#endif
        }

        public static void PrettyPrintText(string key, string text)
        {
            Debug.Log($"[{key}] {text}");
        }

        public static void PrettyPrint(object obj, string text)
        {
            PrettyPrintText(obj.GetType().Name, text);
        }
        
        // TODO: log method
    }
}