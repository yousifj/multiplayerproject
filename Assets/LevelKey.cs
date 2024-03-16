using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            FindAnyObjectByType<Goal>().openGoal();
            FindAnyObjectByType<AudioManger>().Play("Key Picked");
            Destroy(gameObject);
        }
    }
}
