using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    [SerializeField] Door door;
    int keysPresses;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Open the door when the button is clicked
    private void OnTriggerEnter2D(Collider2D collision)
    {
        keysPresses++;
        door.openDoor();
        animator.SetBool("isClicked", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        keysPresses--;
        if (keysPresses == 0)
        {
            door.closeDoor();
            animator.SetBool("isClicked", false);
        }

    }
}
