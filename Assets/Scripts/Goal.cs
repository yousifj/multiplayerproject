using UnityEngine;
using System.Collections.Generic;

public class Goal : MonoBehaviour
{
    // Cached 
    bool keyPicked = false;
    int playercount = 0;
    // Function to set the key picked
    public void openGoal()
    {
        keyPicked = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player has enter triggerd this collider, if it did add it 
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            playercount++;
            // If both players are in the goal and key was picked move to the next level
            if (keyPicked && playercount == 2)
            {
                // Go to the next level
                FindObjectOfType<UIManger>().Nextlevel();
                FindObjectOfType<AudioManger>().Play("nextLevel");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if player has exit triggerd this collider, if it did remove it from the list
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            playercount--;
        }
    }

}
