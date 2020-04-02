using UnityEngine;

namespace CodeSandbox
{
    public class LoopTest : MonoBehaviour
    {
        public Transform root;

        void Start()
        {
            ForeachLoop();
        }

        private void ForeachLoop()
        {
            foreach (Transform child in root)
            {
                child.SetParent(null);
            }
        }
        
        private void ReverseForLoop()
        {
            for (var i = root.childCount - 1; i >= 0; i--)
            {
                var child = root.GetChild(i);
                child.SetParent(null);
            }
        }

    }
}
