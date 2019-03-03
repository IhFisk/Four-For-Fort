using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;
public class CAfficherTimer : Photon.PunBehaviour
{


    public Text TxtTimer;
    public CTimer timer;
    public string nomTimer;

    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {

        TxtTimer.text = timer.StringTimer;
    }
}