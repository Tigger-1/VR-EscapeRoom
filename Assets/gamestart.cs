using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestart : MonoBehaviour
{
    public GameObject hint1;

    private void OnTriggerEnter(Collider other)
    {
        hint1.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        hint1.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the hint is initially disabled
        hint1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
