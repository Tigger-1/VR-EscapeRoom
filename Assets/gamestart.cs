using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestart : MonoBehaviour
{
    public GameObject hint1;
    public AudioClip audioClip; // Public field for the audio clip
    public AudioClip loopedAudioClip; // Public field for the looped audio clip

    private AudioSource audioSource;
    private AudioSource loopedAudioSource; // AudioSource for the looped audio clip

    private void Start()
    {
        // Ensure the hint is initially disabled
        if (hint1 != null)
        {
            hint1.SetActive(false);
        }
        else
        {
            Debug.LogError("Hint1 is not assigned in the Inspector.");
        }

        // Get or add an AudioSource component for the regular audio clip
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the regular audio clip to the AudioSource
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
        else
        {
            Debug.LogError("AudioClip is not assigned in the Inspector.");
        }

        // Check if the looped audio clip is assigned
        if (loopedAudioClip != null)
        {
            // Add AudioSource component for the looped audio clip
            loopedAudioSource = gameObject.AddComponent<AudioSource>();
            loopedAudioSource.clip = loopedAudioClip;
            loopedAudioSource.loop = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hint1 != null)
        {
            hint1.SetActive(true);
        }

        if (audioSource != null && audioClip != null)
        {
            audioSource.Play();
        }

        // Check if the triggered collider corresponds to where looped audio should play
        if (loopedAudioSource != null && loopedAudioClip != null && other.CompareTag("LoopedAudioTrigger"))
        {
            loopedAudioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hint1 != null)
        {
            hint1.SetActive(false);
        }

        if (audioSource != null && audioClip != null)
        {
            audioSource.Stop();
        }

        // Check if the looped audio source is playing, and stop it if necessary
        if (loopedAudioSource != null && loopedAudioSource.isPlaying && other.CompareTag("LoopedAudioTrigger"))
        {
            loopedAudioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
