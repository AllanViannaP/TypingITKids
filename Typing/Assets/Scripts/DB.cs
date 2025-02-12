using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class WordList
{
    public string[] words; // Necessary for JsonUtility to work
}

public class DB : MonoBehaviour
{
    // public InputField NickField;
    // public InputField passwordField;
    // public InputField emailField;

    // Stores the retrieved words
    private string[] retrievedWords;

    // Function to register a new user
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
    }
    */

    // Function to fetch words from the database
    public IEnumerator FetchWords(System.Action<string[]> callback)
    {
        using UnityWebRequest request = UnityWebRequest.Get("http://localhost/typer/get_words.php");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;
            WordList wordList = JsonUtility.FromJson<WordList>(jsonResponse);
            retrievedWords = wordList.words;
            callback(retrievedWords);
        }
        else
        {
            Debug.Log("Request failed: " + request.error);
            callback(new string[0]); // Return an empty array on error
        }
    }

    private void Start()
    {
        StartCoroutine(FetchWords(HandleWords));
    }

    private void HandleWords(string[] words)
    {
        foreach (string word in words)
        {
            Debug.Log("Received word: " + word);
        }
    }

    // Function to return words for other scripts
    public string[] GetRetrievedWords()
    {
        return retrievedWords ?? new string[0]; // Return an empty array if null
    }
}
