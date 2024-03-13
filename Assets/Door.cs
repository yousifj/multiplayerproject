using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
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
    public void closeDoor()
    {
        animator.SetBool("opend", false);
    }
}
