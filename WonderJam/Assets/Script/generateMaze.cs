using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateMaze : MonoBehaviour
{
    public GameObject objectToInstance;
    public int lines;
    public int columns;
    public Vector3 direction;
    
    private Vector3 baseTransform = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        baseTransform = transform.position;

        for (int i = 0; i < lines; i++)
        {
            transform.position = new Vector3(baseTransform.x, baseTransform.y, baseTransform.z);
            for (int j = 0; j < columns; j++)
            {
                Instantiate(objectToInstance, transform.position, Quaternion.identity);
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