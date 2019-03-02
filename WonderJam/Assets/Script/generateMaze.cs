using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateMaze : MonoBehaviour
{
    public GameObject objectToInstance;
    public int lines;
    public int columns;
    public Vector3 direction;

    private Activate active;
    private Vector3 baseTransform = new Vector3(0, 0, 0);

    private bool once = false;
    private bool isGenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        active = GetComponent<Activate>();
        baseTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(active.getActive() && !once)
        {
            for(int i = 0; i < lines; i++)
            {
                transform.position = new Vector3(baseTransform.x, baseTransform.y, baseTransform.z);
                for(int j = 0; j < columns; j++)
                {
                    Instantiate(objectToInstance, transform.position, Quaternion.identity);
                    transform.position += new Vector3(direction.x, 0, 0);
                }
                transform.position += new Vector3(0, 0, direction.z);
            }
            once = true;
        }
    }

    public void Activate()
    {
        isGenerate = false;
    }
}