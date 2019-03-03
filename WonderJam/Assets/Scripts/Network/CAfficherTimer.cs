using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;
public class CAfficherTimer : Photon.PunBehaviour
{


    public Text TxtTimer;
    public Text TxtTimerblue;
    public Text TxtTimerred;
    public GameObject blue;
    public GameObject red;
    public CTimer timer;
    public string nomTimer;


    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {

        TxtTimer.text = timer.StringTimer;
        if(timer.blueTimer!=0)
        {
            blue.SetActive(true);
            TxtTimerblue.text = timer.StringTimerblue;
        }
        if (timer.redTimer != 0)
        {
            red.SetActive(true);
            TxtTimerred.text = timer.StringTimerred;
        }
    }
}