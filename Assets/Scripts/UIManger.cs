using System.Collections;
using System.Collections.Generic;
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
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
