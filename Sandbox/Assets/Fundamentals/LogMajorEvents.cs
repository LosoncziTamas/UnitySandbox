using UnityEngine;

namespace Fundamentals
{
    public class LogMajorEvents : MonoBehaviour
    {
        private void LogWithColors(string text)
        {
            Debug.Log($"<color=red>[{gameObject.name}]</color> <color=yellow>{text}</color> called.");
            
            Debug.Log($"<color=yellow>isActiveAndEnabled {isActiveAndEnabled}</color>");
            Debug.Log($"<color=yellow>gameObject.activeInHierarchy {gameObject.activeInHierarchy}</color>");
            Debug.Log($"<color=yellow>gameObject.activeSelf {gameObject.activeSelf}</color>");
            Debug.Log($"<color=yellow>enabled {enabled}</color>");
        }
        private void Awake()
        {
            LogWithColors("Awake");
        }

        private void OnDestroy()
        {
            LogWithColors("OnDestroy");
        }

        private void OnDisable()
        {
            LogWithColors("OnDisable");
        }

        private void OnEnable()
        {
            LogWithColors("OnEnable");
        }

        private void Start()
        {
            LogWithColors("Start");
        }
    }
}