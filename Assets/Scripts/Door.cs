using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // chached 
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Open the door
    public void openDoor()
    {
        animator.SetBool("opend", true);
    }
    // Close the door
    public void closeDoor()
    {
        animator.SetBool("opend", false);
    }
}
