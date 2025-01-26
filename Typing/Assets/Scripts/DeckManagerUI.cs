using UnityEngine;
using UnityEngine.UI;

public class DeckManagerUI : MonoBehaviour
{
    public Decks decks;
    public InputField deckNameInput; 
    public InputField wordInput; 
    public Text deckListText; 
    public WordBank wordBank; 
    // Cria um novo deck
    public void CreateDeck()
    {
        string deckName = deckNameInput.text;
        if (!string.IsNullOrEmpty(deckName))
        {
            decks.AddDeck(deckName);
            UpdateDeckList();
        }
    }

    // Add a word to a deck
    public void AddWordToDeck()
    {
        string deckName = deckNameInput.text;
        string word = wordInput.text;

        if (!string.IsNullOrEmpty(deckName) && !string.IsNullOrEmpty(word))
        {
            decks.AddWordToDeck(deckName, word);
            UpdateDeckList();
        }
    }

    // update the deck list
    private void UpdateDeckList()
    {
        var deckNames = decks.GetDeckNames();
        deckListText.text = string.Join("\n", deckNames);
    }

    // Load the deck to the word bank
    public void LoadDeckToWordBank(string deckName)
    {
        // var wordBank = FindObjectOfType<WordBank>();
        // wordBank.LoadDeck(deckName);
    }
}
