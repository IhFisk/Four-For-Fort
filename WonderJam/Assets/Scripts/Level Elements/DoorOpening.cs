using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{
    GameObject pressurePlate;
    pressureAnim pressureAnim;
    // Start is called before the first frame update
    void Start()
    {
        pressurePlate = GameObject.FindWithTag("pressurePlate");
    }

    // Update is called once per frame
    void Update()
    {
        if (pressureAnim.GetStatePressure())
        {
            // open door
        }
    }
}
