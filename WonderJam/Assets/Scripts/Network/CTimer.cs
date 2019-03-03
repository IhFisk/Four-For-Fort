using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CTimer : Photon.PunBehaviour
{


    public float timer = 0;
    //public float GameLenght = 300;

    [HideInInspector] public string StringTimer;
    private bool gameEnded = false;
    private float time0 = 0;
    private bool Started = false;
    private bool Quit = false;
    public float countdown = 0;
    public float countdownValue = 10;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        SerializeState(stream, info);
    }

    void SerializeState(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    void Update()
    {
        if (PhotonNetwork.inRoom)
        {
            if (!Started)
            {
                if (countdown > countdownValue)
                    StartTimer();
                if (PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count == 2 && PunTeams.PlayersPerTeam[PunTeams.Team.red].Count == 2)
                {
                    countdown += Time.deltaTime;
                    TimeSpan ts = TimeSpan.FromSeconds(countdownValue - countdown);
                    StringTimer = new DateTime(ts.Ticks).ToString("mm:ss");
                }

            }
            if (Started)
            {
                timer = (float)PhotonNetwork.time - time0;
                float t = timer - time0;
                TimeSpan ts = TimeSpan.FromSeconds(timer);
                if (ts.Seconds >= 0)
                    StringTimer = new DateTime(ts.Ticks).ToString("mm:ss");
                /*if (timer > GameLenght)
                {
                    if (!gameEnded)
                    {
                        gameEnded = true;
                        Time.timeScale = 0; // arrete le temps du jeu
                    }
                    else if (Quit)
                    {
                        Debug.Log("youou");
                        endGame();
                    }
                }*/
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Cursor.visible = true;
                endGame();
                
            }
        }
    }

    void endGame()
    {
            /*CJoueur[] players = FindObjectsOfType<CJoueur>(); // recupere tous les joueurs
            foreach (CJoueur player in players)
            {
                player.endGame();
                Debug.Log("end");
                Time.timeScale = 1;
                PhotonNetwork.LeaveRoom();
            }
            CCoolDown[] cds = FindObjectsOfType<CCoolDown>();
            foreach (CCoolDown cd in cds)
            {
                cd.disableComp();
            }*/
            PhotonNetwork.LeaveRoom();
     }

 
    public void StartTimer()
    {
        //Time.timeScale = 1;
        Started = true;
        if (PhotonNetwork.isMasterClient)
        {
            float referenceTime = (float)PhotonNetwork.time;
            Hashtable setReferenceTime = new Hashtable() { { "RefTime", referenceTime } };
            PhotonNetwork.room.SetCustomProperties(setReferenceTime);
        }
        Hashtable h = PhotonNetwork.room.CustomProperties;
        time0 = (float)h["RefTime"];
    }

    IEnumerator OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
        while (PhotonNetwork.room != null || PhotonNetwork.connected == false)
            yield return 0;
    }
}

