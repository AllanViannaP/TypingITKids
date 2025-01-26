using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;
    public void Play()
    {
        // Load the game scene
        SceneManager.LoadScene("GameBase");
    }
    
    public void OpenOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public void Deck()
    {
        // Load the Deck scene
        SceneManager.LoadScene("DeckCreate");
    }

    public void Quit()
    {
        // Quit the game
        Application.Quit();
    }
}
