using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Camera mainCamera;

        private void Start() => 
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        public Vector2 GetMovementInput()
        {
            var result = new Vector3();
            var horizontal = 0;
            var vertical = 0;
            
            if (Input.GetKey(KeyCode.D)) 
                horizontal = 1;

            if (Input.GetKey(KeyCode.A)) 
                horizontal = -1;

            if (Input.GetKey(KeyCode.W)) 
                vertical = 1;

            if (Input.GetKey(KeyCode.S)) 
                vertical = -1;

            result.x = horizontal;
            result.y = vertical;
            return result;
        }

        public bool GetFireInput() => Input.GetKey(KeyCode.Mouse0);
        public bool GetDashInput() => Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space);
        public bool GetReloadInput() => Input.GetKeyDown(KeyCode.R);

        public Vector2 GetMousePosition() => mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}