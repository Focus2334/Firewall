using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuScript : MonoBehaviour
    {
        public void Play() => SceneManager.LoadScene("Game scene");

        public void Exit() => Application.Quit();
    }
}