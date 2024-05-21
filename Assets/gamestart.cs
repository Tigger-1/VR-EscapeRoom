using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestart : MonoBehaviour
{
    public GameObject hint1;
    public AudioClip audioClip; // Public field for the audio clip

    private AudioSource audioSource;

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
        if (hint1 != null)
        {
            hint1.SetActive(true);
        }

        if (audioSource != null && audioClip != null)
        {
            audioSource.Play();
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
