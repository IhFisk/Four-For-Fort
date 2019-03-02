using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    Activate active;

    public GameObject particleEffect;

    private Transform newPos;
    private bool pos_found = false;
    private GameObject player;

    private float time = 0.0f;

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
                    player = active.getPlayer();
                    pos_found = true;
                    active.setActive(false);
                }
            }
        }

        if (pos_found)
        {
            time += Time.deltaTime;
            //Instantiate();
            if(time > 0.5f)
            {

            }
        }
    }
}
