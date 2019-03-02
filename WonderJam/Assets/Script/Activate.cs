using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{

    public bool isActive = false;
    public GameObject activatingGo;

    public GameObject player;

    public void setActive(bool new_active)
    {
        isActive = new_active;
    }

    public bool getActive()
    {
        return isActive;
    }


    public void setPlayer(GameObject new_player)
    {
        player = new_player;
    }

    public GameObject getPlayer()
    {
        return player;
    }
    public void setActiveWithRef(bool new_active, GameObject go)
    {
        isActive = new_active;
        activatingGo = go;
    }

}
