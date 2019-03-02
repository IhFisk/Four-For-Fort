using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBarriere : MonoBehaviour
{

    private bool moveTheDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTheDoor)
        {
            transform.position += new Vector3(0.0f, 0.5f, 0.0f);
        }
    }

    public void setTheDoorMovement(bool new_bool)
    {
        moveTheDoor = new_bool;
    } 
}
