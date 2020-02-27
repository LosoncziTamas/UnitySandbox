using UnityEngine;

namespace InputSandbox
{
    public class Selectable : MonoBehaviour
    {
        private bool _selected;
        public bool Selected => _selected;

        public void SetSelection(bool newValue)
        {
            _selected = newValue;
        }

        private void Update()
        {
            
        }
    }
}