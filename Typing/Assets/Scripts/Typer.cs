using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Word Bank
    public Text wordOut = null; // The UI element to display the word
    private string currentWord = string.Empty;
    private string remainingWord = string.Empty;
    private string typedWord = string.Empty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        // Get word from word bank
        currentWord = "hello";
        typedWord = string.Empty;
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newWord)
    {
        remainingWord = newWord;
        UpdateWordDisplay();
    }

    private void UpdateWordDisplay()
    {
        // Highlight the typed letters in light gray and the next letter in red
        string grayPart = "<color=#686f87>" + typedWord + "</color>"; // Light gray color
        string redPart = remainingWord.Length > 0 ? "<color=red>" + remainingWord[0] + "</color>" : "";
        string restOfWord = remainingWord.Length > 1 ? remainingWord.Substring(1) : "";

        wordOut.text = grayPart + redPart + restOfWord;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string inputString = Input.inputString;
            if (inputString.Length == 1)
            {
                EnterLetter(inputString);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (CheckLetter(typedLetter))
        {
            AddTypedLetter();
            if (WordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private bool CheckLetter(string inputChar)
    {
        return remainingWord.IndexOf(inputChar) == 0;
    }

    private bool WordComplete()
    {
        return remainingWord.Length == 0;
    }

    private void AddTypedLetter()
    {
        // Move the first letter to the typedWord and update the display
        typedWord += remainingWord[0];
        remainingWord = remainingWord.Substring(1);
        UpdateWordDisplay();
    }
}
