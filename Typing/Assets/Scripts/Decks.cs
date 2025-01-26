using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour
{
    // Dictionary to store decks with a name as the key and a list of words as the value
    private Dictionary<string, List<string>> decks = new Dictionary<string, List<string>>();

    // Adds a new deck with a given name
    public bool AddDeck(string deckName)
    {
        // Check if the deck name already exists
        if (decks.ContainsKey(deckName))
        {
            Debug.LogWarning($"Deck with name '{deckName}' already exists.");
            return false;
        }

        // Add a new empty deck
        decks[deckName] = new List<string>();
        Debug.Log($"Deck '{deckName}' created successfully.");
        return true;
    }

    // Adds a word to a specific deck
    public bool AddWordToDeck(string deckName, string word)
    {
        if (decks.ContainsKey(deckName))
        {
            decks[deckName].Add(word);
            Debug.Log($"Word '{word}' added to deck '{deckName}'.");
            return true;
        }

        Debug.LogWarning($"Deck '{deckName}' does not exist.");
        return false;
    }

    // Removes a word from a specific deck
    public bool RemoveWordFromDeck(string deckName, string word)
    {
        if (decks.ContainsKey(deckName))
        {
            if (decks[deckName].Remove(word))
            {
                Debug.Log($"Word '{word}' removed from deck '{deckName}'.");
                return true;
            }
            else
            {
                Debug.LogWarning($"Word '{word}' not found in deck '{deckName}'.");
                return false;
            }
        }

        Debug.LogWarning($"Deck '{deckName}' does not exist.");
        return false;
    }

    // Deletes an entire deck
    public bool DeleteDeck(string deckName)
    {
        if (decks.Remove(deckName))
        {
            Debug.Log($"Deck '{deckName}' deleted successfully.");
            return true;
        }

        Debug.LogWarning($"Deck '{deckName}' does not exist.");
        return false;
    }

    // Gets all words from a specific deck
    public List<string> GetDeckWords(string deckName)
    {
        if (decks.ContainsKey(deckName))
        {
            return new List<string>(decks[deckName]); // Return a copy to avoid external modification
        }

        Debug.LogWarning($"Deck '{deckName}' does not exist.");
        return null;
    }

    // Gets the names of all available decks
    public List<string> GetDeckNames()
    {
        return new List<string>(decks.Keys);
    }
}
