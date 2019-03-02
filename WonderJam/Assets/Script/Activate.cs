using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{    

    public bool isActive = false;
    public GameObject objectFound;

    public void setActive(bool new_active)
    {
        isActive = new_active;
    }

    public void setObjectFound(GameObject new_object)
    {
        objectFound = new_object;
    }

    public bool getActive()
    {
        return isActive;
    }

    public GameObject getPlayer()
    {
        return objectFound;
    }

}
