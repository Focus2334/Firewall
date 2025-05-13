using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvasScript : MonoBehaviour
{
    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main menu");
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game scene");
    }
}
