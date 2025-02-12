using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    public DB db = null; // Ensure this is assigned in the Inspector

    private List<string> setWords = new List<string>();
    private List<string> nowWords = new List<string>();

    private void Awake()
    {
        StartCoroutine(SetWords(1)); // Call the function as a Coroutine
    }

    private IEnumerator SetWords(int deckId)
    {
        yield return StartCoroutine(db.FetchWords(words =>
        {
            foreach (string word in words)
            {
                setWords.Add(word);
            }

            nowWords.AddRange(setWords);
            Shuffle(nowWords);
            LowerCase(nowWords);
        }));
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
            newWord = nowWords[nowWords.Count - 1];
            nowWords.RemoveAt(nowWords.Count - 1);
        }

        return newWord;
    }
}
