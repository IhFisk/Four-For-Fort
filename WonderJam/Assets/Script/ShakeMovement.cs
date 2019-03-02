using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMovement : MonoBehaviour
{

    public float speed = 1.0f;
    public float amount = 1.0f;

    private Vector2 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(Mathf.Sin(Time.time * speed) * amount, transform.position.y , transform.position.z);

        transform.position = v;
        
    }
}
