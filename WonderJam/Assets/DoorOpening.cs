using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    Animator anim;
   // Active active;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
     //   active = GetComponent<Active>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  if(getActive())
        {
            anim.SetTrigger("IsOpened");
        }*/
    }

    void DoorOpened()
    {
        anim.enabled = false;
    }

}
