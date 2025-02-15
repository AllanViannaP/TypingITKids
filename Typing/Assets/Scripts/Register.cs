using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField NickField; // Reference to the input field for the nickname
    public InputField passwordField; // Reference to the input field for the password
    public InputField emailField; // Reference to the input field for the email
    public Button submitButton; // Reference to the submit button
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

     // Function to register a new user (commented for now)
    public IEnumerator RegisterUser()
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

}
