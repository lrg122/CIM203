using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("FinalMainGame");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("FinalMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

