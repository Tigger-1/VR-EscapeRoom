using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpressed : MonoBehaviour
{
    public GameObject hint2;
    public AudioClip audioClip; // Public field for the audio clip

    private AudioSource audioSource;

    void Start()
    {
        // Ensure the hint is initially disabled
        if (hint2 != null)
        {
            hint2.SetActive(false);
        }
        else
        {
            Debug.LogError("Hint2 is not assigned in the Inspector.");
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
        if (hint2 != null)
        {
            hint2.SetActive(true);
        }

        if (audioSource != null && audioClip != null)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
