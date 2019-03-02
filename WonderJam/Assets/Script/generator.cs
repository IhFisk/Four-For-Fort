using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{

    public GameObject goobjectToInstance;
    public int numberObjectToSpawnPerLine;
    public int numberOfLine;


    public Vector3 direction;

    private Vector3 baseTransformValue = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        baseTransformValue = transform.position;

        for (int j = 0; j < numberOfLine; j++)
        {
            transform.position = new Vector3(baseTransformValue.x, transform.position.y, transform.position.z);
                
            for (int i = 0; i < numberObjectToSpawnPerLine; i++)
            {
                Instantiate(goobjectToInstance, transform.position, Quaternion.identity);
                transform.position += new Vector3(direction.x, 0, 0);
            }
            transform.position += new Vector3(0, 0, direction.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
