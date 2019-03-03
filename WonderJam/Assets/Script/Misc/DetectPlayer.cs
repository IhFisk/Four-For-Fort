using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    private bool somethingInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("TriggerObject"))
        {
            somethingInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("TriggerObject"))
        {
            somethingInside = false;
        }
    }

    public bool getSometinhInside()
    {
        return somethingInside;
    }
}
