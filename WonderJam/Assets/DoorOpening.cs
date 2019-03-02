using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private Activate active;
    Animator anim;
<<<<<<< HEAD
   // Active active;
=======
>>>>>>> da323991265436f9e1520b965ad8979814015195

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
<<<<<<< HEAD
     //   active = GetComponent<Active>();
=======
        active = GetComponent<Activate>();
>>>>>>> da323991265436f9e1520b965ad8979814015195
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
      /*  if(getActive())
=======
        if(active.getActive())
>>>>>>> da323991265436f9e1520b965ad8979814015195
        {
            anim.SetTrigger("IsOpened");
        }*/
    }

    void DoorOpened()
    {
        anim.enabled = false;
    }

}
