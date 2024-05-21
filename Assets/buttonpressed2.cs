using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpressed2 : MonoBehaviour
{
    public GameObject hint3;
    public AudioClip audioClip; // Audio clip to play

    private AudioSource audioSource;

    void Start()
    {
        if (hint3 == null)
        {
            Debug.LogError("hint3 is not assigned in the inspector");
            return;
        }

        Debug.Log("Start method called, setting hint3 to inactive");
        hint3.SetActive(false);
        Debug.Log("hint3 active state: " + hint3.activeSelf);

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
        if (other.gameObject.CompareTag("IgnoreTrigger"))
        {
            Debug.Log("Ignored OnTriggerEnter from " + other.name);
            return;
        }

        Debug.Log("OnTriggerEnter called with " + other.name);
        hint3.SetActive(true);

        // Play the assigned audio clip if an audio clip is assigned to the AudioSource
        if (audioSource != null && audioClip != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("IgnoreTrigger"))
        {
            Debug.Log("Ignored OnTriggerExit from " + other.name);
            return;
        }

        Debug.Log("OnTriggerExit called with " + other.name);
        hint3.SetActive(false);

        // Stop the audio clip when the collider is exited
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
