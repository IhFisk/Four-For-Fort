using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliderplayer : MonoBehaviour
{
    public bool blueTeam;
    public SliderUI sb;
    public SliderUI sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players)
        {
            if (go.GetPhotonView().owner.GetTeam() == PunTeams.Team.blue)
            {
                sb.joueur = go;
            }
            else
            {
                sr.joueur = go;
            }
        }
    }
}
