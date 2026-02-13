using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject letterPrefab;

    public float spawnXRange = 9f;
    public float spawnZ = 0f;

    public int guaranteedCopies = 5;      
    public int extraRandomLetters = 40;   

    void Start()
    {
        SpawnAllLetters();
    }

    void SpawnAllLetters()
    {
        string word = Manager.Instance.targetWord;
        List<char> lettersToSpawn = new List<char>();

        
        
        
        foreach (char c in word)
        {
            for (int i = 0; i < guaranteedCopies; i++)
            {
                lettersToSpawn.Add(c);
            }
        }

        
        
        
        for (int i = 0; i < extraRandomLetters; i++)
        {
            if (Random.value < 0.6f)
            {
                
                lettersToSpawn.Add(word[Random.Range(0, word.Length)]);
            }
            else
            {
                
                char randomLetter = (char)Random.Range('A', 'Z' + 1);
                lettersToSpawn.Add(randomLetter);
            }
        }

        
        
        
        for (int i = 0; i < lettersToSpawn.Count; i++)
        {
            int rand = Random.Range(i, lettersToSpawn.Count);
            (lettersToSpawn[i], lettersToSpawn[rand]) = (lettersToSpawn[rand], lettersToSpawn[i]);
        }

        
        
       
        float currentY = Camera.main.transform.position.y + 4.5f;

        foreach (char letter in lettersToSpawn)
        {
            float x = Random.Range(-spawnXRange, spawnXRange);
            Vector3 spawnPos = new Vector3(x, currentY, spawnZ);

            GameObject go = Instantiate(letterPrefab, spawnPos, Quaternion.identity);

            LetterBehavior lb = go.GetComponent<LetterBehavior>();
            lb.letterChar = letter;

            TextMeshPro tmp = go.GetComponentInChildren<TextMeshPro>();
            tmp.text = letter.ToString();

            currentY += Random.Range(1.6f, 2.5f);
        }
    }
}





