using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelKey : MonoBehaviour
{
    // Check if the user touched the key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player gets the get open the goal
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            FindAnyObjectByType<Goal>().openGoal();
            FindAnyObjectByType<AudioManger>().Play("Key Picked");
            Destroy(gameObject);
        }
    }
}
