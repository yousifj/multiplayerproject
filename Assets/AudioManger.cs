using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip KeyPicked;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Method to play sounds
    public void Play(string s)
    {
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
                default: break;
        }

    }
}
