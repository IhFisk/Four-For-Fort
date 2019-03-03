using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceBox : MonoBehaviour
{

    Vector3 startPositon = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        startPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < startPositon.y - 10)
        {
            transform.position = startPositon;
        }
    }
}
