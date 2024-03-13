using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    [SerializeField] Door door;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Open the door when the button is clicked
    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.openDoor();
        animator.SetBool("isClicked", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        door.closeDoor();
        animator.SetBool("isClicked", false);

    }
}
