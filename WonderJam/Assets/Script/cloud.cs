using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{

    public float speedValue = 0.31f;
    private MeshFilter mesh;

    private Vector3 spawnPosition = new Vector3(0, 0, 0);


    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>();
        spawnPosition = mesh.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speedValue * transform.forward * Time.deltaTime;
    }    

    public void resetPosition()
    {
        transform.position = spawnPosition;
    }

    public void OnBecameInvisible()
    {
        resetPosition();
    }
}
