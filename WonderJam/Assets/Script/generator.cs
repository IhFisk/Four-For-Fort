using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : Photon.MonoBehaviour
{

    public GameObject goobjectToInstance;
    public int numberObjectToSpawnPerLine;
    public int numberOfLine;

    public bool generateFromMaze;

    public Transform otherSpawnPoint;

    public Vector3 direction;
    private Vector3 baseTransformValue = new Vector3(0, 0, 0);
    private Activate active;


    private bool isGenerate = true;
    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        baseTransformValue = transform.position;
        active = GetComponent<Activate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active.getActive() && !once)
        {
            for (int j = 0; j < numberOfLine; j++)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, baseTransformValue.z);

                for (int i = 0; i < numberObjectToSpawnPerLine; i++)
                {                    
                    GameObject currentObject = Instantiate(goobjectToInstance, transform.position, Quaternion.identity);

                    if (generateFromMaze)
                    {
                        GameObject objectSolution = Instantiate(goobjectToInstance, otherSpawnPoint.position, Quaternion.identity);
                        objectSolution.transform.localScale = new Vector3(objectSolution.transform.localScale.x, objectSolution.transform.localScale.y * 0.1f, objectSolution.transform.localScale.z);

                        int[,] matrice = GetComponent<generateMaze>().getMaze();

                        if(matrice[j, i] == 1)
                        {
                            currentObject.GetComponent<BoxCollider>().enabled = true;

                            foreach (var child in objectSolution.GetComponentsInChildren<Renderer>())
                            {
                                child.material.color = Color.green;
                            }
                        }
                    }
                    transform.position += new Vector3(0, 0, direction.z);
                }
                transform.position += new Vector3(direction.x, 0, 0);
            }
            once = true;
        }
    }

    public void Activate()
    {
        isGenerate = false;
    }
}