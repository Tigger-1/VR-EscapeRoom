using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpressed2 : MonoBehaviour
{
    public GameObject hint3;

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
    }

    // Update is called once per frame
    void Update()
    {
    }
}
