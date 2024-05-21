using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashking : MonoBehaviour
{
    public AudioClip audioClip; // Audio clip to play when collision occurs
    public GameObject objectToDestroy1; // First object to be destroyed
    public GameObject objectToDestroy2; // Second object to be destroyed

    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
        else
        {
            Debug.LogError("AudioClip is not assigned in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the White King
        if (other.CompareTag("WhiteKing"))
        {
            Debug.Log("White King entered the trash collider.");

            // Play the assigned audio clip if an audio clip is assigned to the AudioSource
            if (audioSource != null && audioClip != null)
            {
                audioSource.Play();
            }

            // Destroy the objects if they're assigned
            if (objectToDestroy1 != null)
            {
                Destroy(objectToDestroy1);
            }

            if (objectToDestroy2 != null)
            {
                Destroy(objectToDestroy2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can add other logic here if needed
    }
}
