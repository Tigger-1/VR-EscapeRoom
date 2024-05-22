using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    public GameObject endingtext;
    // Start is called before the first frame update
    void Start()
    {
        endingtext.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {



        endingtext.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
