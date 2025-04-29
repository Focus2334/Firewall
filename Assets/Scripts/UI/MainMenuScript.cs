using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField] private ShipCanvasScript shipCanvasScript;
        public void Play() => SceneManager.LoadScene("Game scene");

        public void Exit() => Application.Quit();

        public void OpenShipMenu()
        {
            shipCanvasScript.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}