using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    // ATTRIBUTS PUBLICS
    public GameObject vortexGround;
    public float slowAmount;


    // ATTRIBUTS SERIALIZEFIELD
    private GameObject player;

    // ATTRIBUTS PRIVEES
    private SimpleCharacterControlV2 Character_components;
    private GameObject particle;
    private bool playerPresent;
    private bool isSlow = false;

    private readonly float waitTime = 2f;
    private float time;
    

    private void OnTriggerEnter(Collider other)
    {
        playerPresent = true;
        player = other.gameObject;
        Character_components = player.GetComponent<SimpleCharacterControlV2>();
    }

    private void OnTriggerExit(Collider other)
    {
        playerPresent = false;
        Character_components.restoreSpeed();
        ShowVortexEffect(false);
        player = null;
        isSlow = false;

    }

    public void ShowVortexEffect(bool value)
    {
        if (value && !particle)
        {
            particle = Instantiate(vortexGround, player.transform);
        }
        else
            Destroy(particle, 1);
    }

    private void Update()
    {
        if (playerPresent)
        {
            time += Time.deltaTime;
            if (time > waitTime)
            {
                if (!isSlow)
                {
                    Character_components.SlowPlayer(slowAmount);
                    isSlow = true;
                }
                ShowVortexEffect(true);
                time = 0f;
            }     
        }
        else
        {
            if (player)
            {
                Character_components.restoreSpeed();
                ShowVortexEffect(false);
            }
        }
    }
}
