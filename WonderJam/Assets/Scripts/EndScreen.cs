using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : Photon.MonoBehaviour
{
    public Image win;
    public Image loose;
    public CTimer timer;
    public TriggerFin fin;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in gos)
        {
            if (go.GetPhotonView().isMine)
            {
                if (fin.blue && go.GetPhotonView().owner.GetTeam() == PunTeams.Team.blue || fin.red && go.GetPhotonView().owner.GetTeam() == PunTeams.Team.red)
                {
                    win.gameObject.SetActive(true);
                }
                else
                {
                    if(fin.blue|| fin.red)
                    {
                        loose.gameObject.SetActive(true);
                    }
                }
            }
        }
       
    }
}
