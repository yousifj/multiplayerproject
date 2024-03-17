using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{
    // Start the game as a client
    public void startClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    // Start the game as the host
    public void startHost()
    {
        NetworkManager.Singleton.StartHost();
    }
    // Go to the next level
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Go to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    // Quit the game
    public void Quit()
    {
        Application.Quit();
    }
}
