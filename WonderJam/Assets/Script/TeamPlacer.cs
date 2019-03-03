using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPlacer : MonoBehaviour
{
    private Vector3 startPositon;
    private Vector3 endPositon;

    private float distanceBetweenPoints;


    // Start is called before the first frame update
    void Awake()
    {
        startPositon = GameObject.FindGameObjectWithTag("StartPosition").transform.position;
        endPositon = GameObject.FindGameObjectWithTag("EndPosition").transform.position;

        distanceBetweenPoints = Vector3.Distance(startPositon, endPositon);
    }

    public float getDistanceBetweenPoint()
    {
        return distanceBetweenPoints;
    }

    public Vector3 getEndPositon()
    {
        return endPositon;
    }


}
