using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    // ATTRIBUTS PUBLICS
    public GameObject vortexGround;
    public float slowAmount;


    // ATTRIBUTS SERIALIZEFIELD
    [SerializeField] public GameObject player;

    // ATTRIBUTS PRIVEES
    private SimpleCharacterControl Character_components;
    private GameObject particle;
    private bool playerPresent;
    private readonly float waitTime = 2f;
    private float time;

    void Awake()
    {
        Character_components = player.GetComponent<SimpleCharacterControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerPresent = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerPresent = false;
    }

    public void ShowVortexEffect(bool value)
    {
        if (value)
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
                Character_components.SlowPlayer(slowAmount);
                ShowVortexEffect(true);
                time = 0f;
            }

        }
        else
        {
            Character_components.restoreSpeed();
            ShowVortexEffect(false);
        }
    }
}
