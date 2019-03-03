using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayUi : MonoBehaviour
{
    public TextMeshPro textMesh;
    public TextMeshPro connectingText;
    public string sceneName= "Multi 2";

    GUIStyle style;
    bool Joined = false;
    bool Created = false;
    bool RandomJoined = false;
    bool SelectJoined = false;
    bool ChampSelect = false;

    void Awake()
    {       

        //Connect to the main photon server. This is the only IP and port we ever need to set(!)
        if (!PhotonNetwork.connected)
            PhotonNetwork.ConnectUsingSettings("v3.0"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)

        //Load name from PlayerPrefs
        PhotonNetwork.playerName = PlayerPrefs.GetString("playerName", "Pascal" + Random.Range(1, 9999));
    }

    private string roomName = "myRoom";
    private Vector2 scrollPos = Vector2.zero;


    void OnGUI()
    {
        
        if (!PhotonNetwork.connected)
        {                        
            connectingText.gameObject.SetActive(true);
            if (textMesh)
            {
                textMesh.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            return;   //Wait for a connection
        }
        connectingText.gameObject.SetActive(false);



        if (PhotonNetwork.room != null)
            return; //Only when we're not in a Room   
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Cursor.lockState = CursorLockMode.None;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("PlayBtn"))
                {
                    textMesh = hit.collider.gameObject.GetComponent<TextMeshPro>();
                    StartGame();
                }
            }

        }
        
    }
    void LateUpdate()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        textMesh.color = Color.blue;


        
        if (PhotonNetwork.GetRoomList().Length == 0)
        {
            Joined = true;
            ChampSelect = true;
            RoomOptions options = new RoomOptions() { isVisible = true, maxPlayers = 4 };
            options.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "prop1", sceneName }, { "prop2", 4 } };
            options.CustomRoomPropertiesForLobby = new string[] { "prop1", "prop2" };
            PhotonNetwork.CreateRoom(roomName, options, TypedLobby.Default);
            //PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = 10 }, TypedLobby.Default);
        }
        else
        {
            PhotonNetwork.JoinRandomRoom();
            /*if(!PhotonNetwork.inRoom)
            {
                Joined = true;
                ChampSelect = true;
                RoomOptions options = new RoomOptions() { isVisible = true, maxPlayers = 4 };
                options.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "prop1", "SampleSceneMulti 1" }, { "prop2", 4 } };
                options.CustomRoomPropertiesForLobby = new string[] { "prop1", "prop2" };
                PhotonNetwork.CreateRoom(roomName+ PhotonNetwork.GetRoomList().Length.ToString(), options, TypedLobby.Default);
                //PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = 10 }, TypedLobby.Default);
            }*/
        }


    }



    void ShowPing()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Ping :");
        int ping = PhotonNetwork.GetPing();
        if (ping <= 50)
            GUI.contentColor = Color.green;
        else if (ping <= 100)
            GUI.contentColor = Color.yellow;
        else
            GUI.contentColor = Color.red;
        GUILayout.Label(ping.ToString());
        GUI.contentColor = Color.white;
        GUILayout.EndHorizontal();
    }

    public void OnConnectedToMaster()
    {
        // this method gets called by PUN, if "Auto Join Lobby" is off.
        // this demo needs to join the lobby, to show available rooms!

        PhotonNetwork.JoinLobby();  // this joins the "default" lobby
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(PhotonNetwork.room.CustomProperties["prop1"].ToString());
    }

}
