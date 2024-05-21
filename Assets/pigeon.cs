using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpotAudioTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the birdspotcollider GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on birdspotcollider.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Pigeon"
        if (other.CompareTag("Pigeon"))
        {
            Debug.Log("Pigeon entered the birdspotcollider.");
            // Play the audio clip
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the tag "Pigeon"
        if (other.CompareTag("Pigeon"))
        {
            Debug.Log("Pigeon exited the birdspotcollider.");
            // Stop the audio clip when the pigeon exits the collider
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
