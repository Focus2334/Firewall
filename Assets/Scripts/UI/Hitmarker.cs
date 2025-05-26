using UnityEngine;

namespace UI
{
    public class Hitmarker : MonoBehaviour
    {
        [SerializeField] private float timeForHitmarker = 0.2f;
        [SerializeField] private Texture2D cursorImage;
        [SerializeField] private Texture2D hitmarkerImage;
        
        private bool isCursorSetBack = true;
        private static bool changeCursor;
        private float timer;
        
        public void Update()
        {
            if (changeCursor)
                SetHitmarker();
            if (timer > 0)
                timer -= Time.deltaTime;
            if (timer <= 0 && !isCursorSetBack)
                SetCursorBack();
        }

        private void SetHitmarker()
        {
            changeCursor = false;
            isCursorSetBack = false;
            timer = timeForHitmarker;
            print("Hitmarker");
            Cursor.SetCursor(hitmarkerImage, Vector2.zero, CursorMode.Auto);
        }

        private void SetCursorBack()
        {
            Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
            isCursorSetBack = true;
        }

        public static void ChangeCursor() => changeCursor = true;
    }
}