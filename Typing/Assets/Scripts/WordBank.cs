using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WordBank : MonoBehaviour
{
    private List<string> setWords = new List<string>
    {
        "test","words","here","hello","world","unity","game","development","programming"
    };

    private List<string> nowWords = new List<string>();

    private void Awake()
    {
        nowWords.AddRange(setWords);
        Shuffle(nowWords);
        LowerCase(nowWords);
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void LowerCase(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (nowWords.Count != 0)
        {
            newWord = nowWords.Last();
            nowWords.Remove(newWord);
        }

         return newWord;
    }
}
