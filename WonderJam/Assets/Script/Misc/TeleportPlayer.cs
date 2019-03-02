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
    private bool isInstantiate = false;

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
                if (active.getPlayer() && go.GetPhotonView().owner == active.getPlayer().GetPhotonView().owner)
                {
                    player = active.getPlayer();
                    pos_found = true;
                }
            }
        }

        if (pos_found)
        {
            time += Time.deltaTime;

            Camera.main.GetComponentInParent<CameraController>().setFov(35);

            if (!isInstantiate)
            {
                Destroy(Instantiate(particleEffect, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z), Quaternion.identity), 0.5f);
                isInstantiate = true;
            }


            if (time > 0.4f)
            {
                Camera.main.GetComponentInParent<CameraController>().setFov(60);
            }

              if (time > 0.5f && pos_found)
            {
                player.transform.position = transform.position;
                Destroy(Instantiate(particleEffect, player.transform.position, Quaternion.identity), 0.5f);  
                pos_found = false;
                time = 0.0f;

            }
        }
    }
}
