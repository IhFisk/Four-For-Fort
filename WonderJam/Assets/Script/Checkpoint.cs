using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool playerIsPresent;
    private GameObject player;

    private SpawnPoint[] listSpawnPoint;
    private float distanceMax = float.MaxValue;
    private Transform positonToSpawn;

    private void Start()
    {     
        listSpawnPoint = GetComponentsInChildren<SpawnPoint>();
    }


    private void OnTriggerEnter(Collider other)
    {
        playerIsPresent = true;
        player = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        distanceMax = float.MaxValue;
        playerIsPresent = false;
        player = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerIsPresent && player.CompareTag("Player"))
        {
            foreach(SpawnPoint sp in listSpawnPoint)
            {
                float distance = Vector3.Distance(sp.transform.position, player.transform.position);

                Vector3 toTarget = (sp.transform.position - player.transform.position).normalized;                

                if (!(Vector3.Dot(toTarget, transform.forward) > 0))
                {
                    if (distance <= distanceMax)
                    {
                        distanceMax = distance;
                        positonToSpawn = sp.transform;
                    }
                }


            }
            playerIsPresent = false;
            player.transform.position = positonToSpawn.position;
        }
    }
}
