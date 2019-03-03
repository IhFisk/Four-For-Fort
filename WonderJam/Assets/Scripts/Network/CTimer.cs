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
    [HideInInspector] public string StringTimerblue;
    [HideInInspector] public string StringTimerred;
    private bool gameEnded = false;
    private float time0 = 0;
    private bool Started = false;
    private bool Quit = false;
    public float countdown = 0;
    public float countdownValue = 10;

    public float blueTimer = 0;
    public float redTimer = 0;
    public bool finish = false;
    bool once = false;

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
                /*
                if (PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count == 2 && PunTeams.PlayersPerTeam[PunTeams.Team.red].Count == 2)
                {
                    countdown += Time.deltaTime;
                    TimeSpan ts = TimeSpan.FromSeconds(countdownValue - countdown);
                    StringTimer = new DateTime(ts.Ticks).ToString("mm:ss");
                }
                */
                //to play alone 

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

                GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                bool playerfinish = false;
                if (finish)
                {

                    float myTimer = timer;

                    foreach (GameObject go in gos)
                    {
                        if (go.GetPhotonView().owner.GetTeam() == PhotonNetwork.player.GetTeam() && !go.GetPhotonView().isMine)
                        {
                            PhotonView pv= go.GetPhotonView();
                            PhotonPlayer pp= go.GetPhotonView().owner;
                            bool otherplayerfinished = (bool)go.GetPhotonView().owner.CustomProperties["finish"];
                            if (!otherplayerfinished)
                            {
                                bool playerfinishfirst = (bool)PhotonNetwork.player.CustomProperties["finishfirst"];
                                playerfinishfirst = true;
                                Hashtable hash = new Hashtable();
                                hash.Add("finishfirst", playerfinishfirst);
                                PhotonNetwork.player.SetCustomProperties(hash);
                            }
                            else
                            {
                                bool otherplayerfinishedfirst = (bool)go.GetPhotonView().owner.CustomProperties["finishfirst"];
                                if (otherplayerfinishedfirst)
                                {
                                    if (!once)
                                    {
                                        if (PhotonNetwork.player.GetTeam() == PunTeams.Team.blue)
                                        {
                                            float Timer = (float)PhotonNetwork.time;
                                            Hashtable setblueTimer = new Hashtable() { { "blueTimer", Timer } };
                                            PhotonNetwork.room.SetCustomProperties(setblueTimer);
                                        }
                                        else
                                        {
                                            float Timer = (float)PhotonNetwork.time;
                                            Hashtable setredTimer = new Hashtable() { { "redTimer", Timer } };
                                            PhotonNetwork.room.SetCustomProperties(setredTimer);
                                        }

                                        once = true;
                                    }

                                }
                            }

                        }

                    }

                    //finish = false;
                }
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Cursor.visible = true;
                    endGame();

                }

                Hashtable h = PhotonNetwork.room.CustomProperties;
                blueTimer = (float)h["blueTimer"];
                TimeSpan tsb = TimeSpan.FromSeconds(blueTimer);
                StringTimerblue = new DateTime(tsb.Ticks).ToString("mm:ss");
                redTimer = (float)h["redTimer"];
                TimeSpan tsr = TimeSpan.FromSeconds(redTimer);
                StringTimerred = new DateTime(tsr.Ticks).ToString("mm:ss");
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

            float b = 0;
            Hashtable setbTimer = new Hashtable() { { "blueTimer", b } };
            PhotonNetwork.room.SetCustomProperties(setbTimer);

            Hashtable setrTimer = new Hashtable() { { "redTimer", b } };
            PhotonNetwork.room.SetCustomProperties(setrTimer);
        }
        Hashtable h = PhotonNetwork.room.CustomProperties;
        time0 = (float)h["RefTime"];

        bool playerfinish = (bool)PhotonNetwork.player.CustomProperties["finish"];
        playerfinish = false;
        Hashtable hash = new Hashtable();
        hash.Add("finish", playerfinish);

        bool playerfinishfirst = (bool)PhotonNetwork.player.CustomProperties["finishfirst"];
        playerfinishfirst = false;
        hash.Add("finishfirst", playerfinishfirst);
        PhotonNetwork.player.SetCustomProperties(hash);
    }

    IEnumerator OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
        while (PhotonNetwork.room != null || PhotonNetwork.connected == false)
            yield return 0;
    }
}

