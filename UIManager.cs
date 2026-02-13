using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI sentenceText;
    public TextMeshProUGUI blanksText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI messageText;

    public void ShowSentence(string prefix, int length)
    {
        sentenceText.text = prefix;

        string blanks = "";
        for (int i = 0; i < length; i++)

            blanks += "_ ";

        blanksText.text = blanks;
    }

    public void UpdateBlanks(string word, int filled)
    {
        string s = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (i < filled)
                s += word[i] + " ";
            else
                s += "_ ";
        }
        blanksText.text = s;
    }

    public void UpdateTimer(float t)
    {
        timerText.text = Mathf.Ceil(t).ToString();
    }

    public void ShowWrong()
    {
        messageText.gameObject.SetActive(true);
        messageText.text = "Wrong!";
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), 1.2f);
    }

    public void ShowCorrect()
    {
        messageText.gameObject.SetActive(true);
        messageText.text = "Correct!";
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), 1.2f);
    }

    void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }
}


