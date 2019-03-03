using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundAboutScript : MonoBehaviour
{

    public Transform gravityCenter;

    public float angle = 15f;

    // Start is called before the first frame update
    void Start()
    {
        angle = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        rotateRigidBodyAroundPointBy(transform.GetComponent<Rigidbody>(), gravityCenter.position, Vector3.up, angle);

        //transform.RotateAround(gravityCenter.position, Vector3.up, angle );
    }

    public void rotateRigidBodyAroundPointBy(Rigidbody rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle * Time.deltaTime, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.transform.parent = transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.transform.parent = null;
    }
}
