using UnityEngine;

namespace Input
{
    public class InputReading : MonoBehaviour
    {
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
            Debug.Assert(_camera);
        }

        private void Update()
        {
            var input = GetInputState();
            if (input.mainButtonDown)
            {
               var ray = _camera.ScreenPointToRay(new Vector3(input.screenPosition.x, input.screenPosition.y, 0f));
               if (Physics.Raycast(ray, out var hit))
               {
                   var selectable = hit.transform.gameObject.GetComponent<Selectable>();
                   if (selectable)
                   {
                       if (!selectable.Selected)
                       {
                           hit.transform.localScale = 1.1f * Vector3.one;
                           selectable.SetSelection(true);
                       }
                       else
                       {
                           hit.transform.localScale = Vector3.one;
                           selectable.SetSelection(false);
                       }
                   }
               }
            }
        }

        public struct InputState
        {
            public bool mainButtonDown;
            public Vector2 screenPosition;
        }
    
        public static InputState GetInputState()
        {
            var result = new InputState();
        
            if (Application.isMobilePlatform && UnityEngine.Input.touchCount > 0)
            {
                result.mainButtonDown = true;
                result.screenPosition = UnityEngine.Input.GetTouch(0).position;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                result.mainButtonDown = true;
                result.screenPosition = new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y);
            }

            return result;
        }
    }
}
