using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpressed : MonoBehaviour
{
    public GameObject hint2;
    private void OnTriggerEnter(Collider other)
    {
        hint2.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        hint2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
