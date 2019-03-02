using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundAboutScript : MonoBehaviour
{

    public Transform gravityCenter;

    public float angle = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gravityCenter.position, Vector3.up, angle );
    }
}
