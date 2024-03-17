using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    // Slecet the sounds in the unrt editor
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip KeyPicked;
    [SerializeField] AudioClip switchClicked;
    [SerializeField] AudioClip newLevel;
    [SerializeField] AudioClip spawn;
    
    // cached 
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Method to play sounds
    public void Play(string s)
    {
        // pick the sound passed as an argument to this method
        switch (s)
        {
            case "Jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "Death":
                audioSource.PlayOneShot(DeathSound);
                break;
            case "Key Picked":
                audioSource.PlayOneShot(KeyPicked);
                break;
            case "SwitchClicked":
                audioSource.PlayOneShot(switchClicked);
                break;
            case "Spawn":
                audioSource.PlayOneShot(spawn);
                break;
            case "nextLevel":
                audioSource.PlayOneShot(newLevel);
                break;
            default: 
                break;
        }

    }
}
