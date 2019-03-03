using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderUI : MonoBehaviour
{

    public Transform positionEquipe;
    public GameObject joueur;
    public bool blueTeam;

    private Vector3 startPositonUI = new Vector3(0, 0, 0);
    public Transform endPositonUI;

    private float distanceTotal;

    private Vector3 endPositionMap;

    // Start is called before the first frame update
    void Start()
    {
        TeamPlacer tp = GetComponent<TeamPlacer>();
        distanceTotal = tp.getDistanceBetweenPoint();
        endPositionMap = tp.getEndPositon();
        startPositonUI = transform.position;


        Debug.Log(endPositionMap);

    }

    // Update is called once per frame
    void Update()
    {
        positionEquipe = joueur.transform;
        float distance = Vector3.Distance(positionEquipe.position, endPositionMap);
;
        transform.position = Vector3.Lerp(startPositonUI, endPositonUI.position, distance/ distanceTotal);
    }
}
