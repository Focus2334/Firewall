using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvasScript : MonoBehaviour
{
    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main menu");
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
