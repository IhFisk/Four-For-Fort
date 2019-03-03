using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    private bool somethingInside = false;

    private void OnTriggerEnter(Collider other)
    {
        somethingInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        somethingInside = false;
    }

    public bool getSometinhInside()
    {
        return somethingInside;
    }
}
