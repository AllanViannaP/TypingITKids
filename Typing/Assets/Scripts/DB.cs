using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class WordList
{
    public string[] words; // Necessary for JsonUtility to work
}

public class DB : MonoBehaviour
{
    private string[] retrievedWords; // Stores the retrieved words

    // Function to fetch words from the database using the deck ID
    public IEnumerator FetchWords(int deckId, System.Action<string[]> callback)
    {
        string url = "http://localhost/typer/get_words.php?id_deck=" + deckId; // URL with the deck ID parameter

        using UnityWebRequest request = UnityWebRequest.Get(url); // Using GET since we are passing parameters in the URL
        yield return request.SendWebRequest(); // Sends the request and waits for the response

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text; // Get the JSON response from the server
            WordList wordList = JsonUtility.FromJson<WordList>(jsonResponse); // Convert the JSON response into a WordList object

            // Check if the response is not null or empty before passing it to the callback
            if (wordList != null && wordList.words != null && wordList.words.Length > 0)
            {
                retrievedWords = wordList.words; // Store the retrieved words
                callback(retrievedWords); // Pass the words to the callback
            }
            else
            {
                Debug.LogError("No words returned or malformed response."); // In case the response is invalid
                callback(new string[0]); // Return an empty array in case of error
            }
        }
        else
        {
            Debug.LogError("Request error: " + request.error); // Log the error if the request fails
            callback(new string[0]); // Return an empty array in case of error
        }
    }

    // Function to register a new user (commented for now)
    /*public IEnumerator RegisterUser()
    {
        WWWForm form = new();
        form.AddField("nick", NickField.text);
        form.AddField("password", passwordField.text);
        form.AddField("email", emailField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/typer/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                if (www.downloadHandler.text == "0")
                {
                    Debug.Log("User created successfully.");
                    // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
                else
                {
                    Debug.Log("User creation failed. Error #" + www.downloadHandler.text);
                }
            }
            else
            {
                Debug.Log("Request failed: " + www.error);
            }
        }
    }*/

    private void Start()
    {
        int deckId = 1; // Example: Replace with the actual deck ID you want to fetch
        StartCoroutine(FetchWords(deckId, HandleWords)); // Start fetching the words
    }

    private void HandleWords(string[] words)
    {
        // Check if the word array is not null or empty before accessing it
        if (words != null && words.Length > 0)
        {
            foreach (string word in words)
            {
                Debug.Log("Received word: " + word); // Log each received word
            }
        }
        else
        {
            Debug.LogError("No words received."); // If no words were received
        }
    }

    // Function to return words for other scripts
    public string[] GetRetrievedWords()
    {
        return retrievedWords ?? new string[0]; // Return an empty array if null
    }
}
