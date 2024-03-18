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
    // Go to the next Scene to be used in main menu/game over
    public void NextScene()
    {
        // Load next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Go to the next level to be used when switching level
    public void Nextlevel()
    {
        // Load next Scene after a delay
        StartCoroutine(LoadNextLevelWithDelay());
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        // Load next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Wait for 0.1 seconds
        yield return new WaitForSeconds(0.2f);

        // Find all objects of type PlayerController in the scene
        PlayerController[] playerControllers = FindObjectsOfType<PlayerController>();

        // Iterate through the list and call MovePlayerToSpawn function on each of them
        foreach (PlayerController playerController in playerControllers)
        {
            playerController.MovePlayerToSpawn();
        }
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
