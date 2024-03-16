using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // At the start of the level make it so the player collide with the goal
    bool keyPicked = false;
    int playerCount = 0;
    public void openGoal()
    {
        keyPicked = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {

            playerCount++;
            Debug.Log(playerCount);
            if (keyPicked && playerCount == 3)
            {
                //go to the next level
                FindAnyObjectByType<UIManger>().NextScene();
            }
        }
    }
        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Debug.Log(playerCount);
            playerCount--;
        }
    }
}
