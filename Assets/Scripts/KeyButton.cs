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
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player) { 
            keysPressed = true;
            door.openDoor();
            animator.SetBool("isClicked", true);
        }
    }
    // Open the door when the button is clicked

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            keysPressed = false;
            animator.SetBool("isClicked", false);
            if (!otherButton.keysPressed)
            {
                door.closeDoor();    
            }
        }


    }
}
