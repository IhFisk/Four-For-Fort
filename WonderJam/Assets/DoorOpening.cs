using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private Activate active;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        active = GetComponent<Activate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active.getActive())
        {
            anim.SetTrigger("IsOpened");
        }
    }

    void DoorOpened()
    {
        anim.enabled = false;
    }

}
