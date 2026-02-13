using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        if (Manager.playerWon)
        {
            resultText.text = "You Won!\nYou weathered the storm!";
        }
        else
        {
            resultText.text = "Time's Up!\nYou didn’t finish the word :(";
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("FinalMenuScene");  
    }
}

