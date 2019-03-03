using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public AudioClip doorOpen;
    public AudioClip doorClose;

    private Activate active;
    private AudioSource audioSource;
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
        if(active.getActive() && !anim.GetBool("IsOpen"))
        {
            anim.SetBool("IsOpen", true);
            AudioSource.PlayClipAtPoint(doorOpen, transform.position);
            //transform.Rotate(0, 90, 0, Space.World);
        }
        else if(!active.getActive() && anim.GetBool("IsOpen"))
        {
            anim.enabled = true;
            anim.SetBool("IsOpen", false);
            AudioSource.PlayClipAtPoint(doorClose, transform.position);
            //transform.Rotate(0, -90, 0, Space.World);
        }
    }

    void DoorOpened()
    {
        //anim.enabled = false;
    }

}
