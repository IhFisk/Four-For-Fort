using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFin : MonoBehaviour
{
    
    public bool blue;
    public bool red;
    public bool once=false;

    public AudioClip winClip;

    private AudioSource winSource;
    // Start is called before the first frame update
    void Start()
    {
        winSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(!once)
        {
            PhotonView pv = other.gameObject.GetPhotonView();
            if (pv.owner.GetTeam() == PunTeams.Team.blue)
            {
                blue = true;
            }
            if (pv.owner.GetTeam() == PunTeams.Team.red)
            {
                red = true;
            }
        }

        winSource.PlayOneShot(winClip);
        
    }
}
