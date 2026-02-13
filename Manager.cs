using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public static bool playerWon = false;

    public string sentencePrefix;
    public string targetWord;

    public UIManager ui;
    public SpawnerController spawner;

    public float timeLeft = 60f;
    int currentIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ui.ShowSentence(sentencePrefix, targetWord.Length);
        StartCoroutine(TimerCountdown());
    }

    
    public void OnLetterCaught(char c)
    {
        char needed = targetWord[currentIndex];

        if (c == needed)
        {
            ui.ShowCorrect();

            currentIndex++;
            ui.UpdateBlanks(targetWord, currentIndex);

            
            if (currentIndex == targetWord.Length)
            {
                playerWon = true;
                SceneManager.LoadScene("FinalEndScene");
            }
        }
        else
        {
            ui.ShowWrong();
        }
    }

    
    private IEnumerator TimerCountdown()
    {
        timeLeft = 60f;

        while (timeLeft > 0)
        {
            ui.UpdateTimer(timeLeft);
            timeLeft -= 1f;
            yield return new WaitForSeconds(1f);
        }

        playerWon = false;
        SceneManager.LoadScene("FinalEndScene");
    }
}






