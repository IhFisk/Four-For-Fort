using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{

    public bool isActive = false;
    public GameObject activatingGo;

    public void setActive(bool new_active)
    {
        isActive = new_active;
    }

    public bool getActive()
    {
        return isActive;
    }

    public void setActive(bool new_active, GameObject go)
    {
        isActive = new_active;
        activatingGo = go;
    }

}
