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
        rotateRigidBodyAroundPointBy(transform.GetComponent<Rigidbody>(), gravityCenter.position, Vector3.up, angle);

        //transform.RotateAround(gravityCenter.position, Vector3.up, angle );
    }

    public void rotateRigidBodyAroundPointBy(Rigidbody rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }
}
