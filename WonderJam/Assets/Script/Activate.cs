using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{    

    public bool isActive = false;

    public void setActive(bool new_active)
    {
        Debug.Log("Get active " + new_active);
        isActive = new_active;
    }

    public bool getActive()
    {
        Debug.Log("Get active " + isActive);
        return isActive;
    }

}
