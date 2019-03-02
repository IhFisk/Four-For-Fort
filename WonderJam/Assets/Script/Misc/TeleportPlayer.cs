using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    Activate active;
    

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
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject go in gos)
            {
                if (active.getPlayer() && go.GetPhotonView() == active.getPlayer().GetPhotonView())
                {
                    active.getPlayer().transform.position = transform.position;
                }
            }
        }
    }
}
