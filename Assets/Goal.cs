using UnityEngine;
using System.Collections.Generic;

public class Goal : MonoBehaviour
{
    bool keyPicked = false;
    // Add a set to keep track of the players 
    List<int> playersInside = new List<int>();
    // Function to set the key picked
    public void openGoal()
    {
        keyPicked = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player has enter triggerd this collider, if it did add it to a list
        // I'm doing this because the player has 2 colliders so I want to make sure that each player trigger this once
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player && !playersInside.Contains(player.GetInstanceID()))
        {
            playersInside.Add(player.GetInstanceID());
            // If both players are in the goal and key was picked move to the next level
            if (keyPicked && playersInside.Count == 2)
            {
                // Go to the next level
                FindObjectOfType<UIManger>().NextScene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if player has exit triggerd this collider, if it did remove it from the list
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player && playersInside.Contains(player.GetInstanceID()))
        {
            playersInside.Remove(player.GetInstanceID());
        }
    }

    private void CheckGoalCompletion()
    {
        
    }
}
