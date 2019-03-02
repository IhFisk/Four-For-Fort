using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QteSynchromize : MonoBehaviour
{

    private Activate active;

    // Start is called before the first frame update
    void Start()
    {
        active = GetComponent<Activate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active.getActive())
        {
            GetComponentInParent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
