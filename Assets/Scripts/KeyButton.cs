using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] KeyButton otherButton;
    bool keysPressed = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player pressed the button
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player) {
            // Open the door when the button is clicked by the player
            keysPressed = true;
            door.openDoor();
            animator.SetBool("isClicked", true);
            FindObjectOfType<AudioManger>().Play("SwitchClicked");
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            // Close the door when the player leaves the switch
            keysPressed = false;
            animator.SetBool("isClicked", false);
            if (!otherButton.keysPressed)
            {
                door.closeDoor();
                FindObjectOfType<AudioManger>().Play("SwitchClicked");
            }
        }


    }
}
