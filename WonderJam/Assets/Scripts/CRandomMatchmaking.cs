using UnityEngine;
using System.Collections;

public class CRandomMatchmaking : MonoBehaviour
{
    GUIStyle style;
    bool Joined = false;
    bool Created = false;
    bool RandomJoined = false;
    bool SelectJoined = false;
    bool ChampSelect = false;
    void Awake()
    {
        //PhotonNetwork.logLevel = NetworkLogLevel.Full;²

        //Connect to the main photon server. This is the only IP and port we ever need to set(!)
        if (!PhotonNetwork.connected)
            PhotonNetwork.ConnectUsingSettings("v3.0"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)

        //Load name from PlayerPrefs
        PhotonNetwork.playerName = PlayerPrefs.GetString("playerName", "Pascal" + Random.Range(1, 9999));

        //Set camera clipping for nicer "main menu" background
        Camera.main.farClipPlane = Camera.main.nearClipPlane + 0.1f;



    }

    private string roomName = "myRoom";
    private Vector2 scrollPos = Vector2.zero;

    void OnGUI()
    {

        if (!PhotonNetwork.connected)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none);
            ShowConnectingGUI();
            return;   //Wait for a connection
        }

        if (PhotonNetwork.room != null)
            return; //Only when we're not in a Room       

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none);


        GUILayout.BeginArea(new Rect(0, 0, 80, 300));
        ShowPing();

        GUILayout.EndArea();



        GUILayout.BeginArea(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 400, 300));

        GUILayout.Label("Main Menu");

        //Player name
        GUILayout.BeginHorizontal();
        GUILayout.Label("Player name:", GUILayout.Width(150));
        PhotonNetwork.playerName = GUILayout.TextField(PhotonNetwork.playerName);
        if (GUI.changed)//Save name
            PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
        GUILayout.EndHorizontal();

        GUILayout.Space(15);


        //Join room by title
        GUILayout.BeginHorizontal();
        GUILayout.Label("JOIN ROOM:", GUILayout.Width(150));
        roomName = GUILayout.TextField(roomName);
        if (GUILayout.Button("GO"))
        {
            Joined = true;
            ChampSelect = true;
            PhotonNetwork.JoinRoom(roomName);
        }
        GUILayout.EndHorizontal();

        //Create a room (fails if exist!)
        GUILayout.BeginHorizontal();
        GUILayout.Label("CREATE ROOM:", GUILayout.Width(150));
        roomName = GUILayout.TextField(roomName);
        if (GUILayout.Button("GO"))
        {
            // using null as TypedLobby parameter will also use the default lobby
            Joined = true;
            ChampSelect = true;
            RoomOptions options = new RoomOptions() { isVisible = true, maxPlayers = 4 };
            options.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "prop1", "MultiTest2" }, { "prop2", 4 } };
            options.CustomRoomPropertiesForLobby = new string[] { "prop1", "prop2" };
            PhotonNetwork.CreateRoom(roomName, options, TypedLobby.Default);

            //PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = 10 }, TypedLobby.Default);
        }
        GUILayout.EndHorizontal();

        //Join random room
        GUILayout.BeginHorizontal();
        GUILayout.Label("JOIN RANDOM ROOM:", GUILayout.Width(150));
        if (PhotonNetwork.GetRoomList().Length == 0)
        {
            GUILayout.Label("..no games available...");

        }
        else
        {
            if (GUILayout.Button("GO"))
            {
                RandomJoined = true;
                ChampSelect = true;
                PhotonNetwork.JoinRandomRoom();
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(30);
        GUILayout.Label("ROOM LISTING:");
        if (PhotonNetwork.GetRoomList().Length == 0)
        {
            GUILayout.Label("..no games available..");
        }
        else
        {
            //Room listing: simply call GetRoomList: no need to fetch/poll whatever!
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            foreach (RoomInfo game in PhotonNetwork.GetRoomList())
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(game.name + " " + game.playerCount + "/" + game.maxPlayers);
                if (GUILayout.Button("JOIN"))
                {
                    SelectJoined = true;
                    ChampSelect = true;
                    PhotonNetwork.JoinRoom(game.name);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }

        GUILayout.EndArea();
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
    void ShowConnectingGUI()
    {
        GUILayout.BeginArea(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 400, 300));

        GUILayout.Label("Connecting to Photon server.");
        GUILayout.Label("Hint: This demo uses a settings file and logs the server address to the console.");

        GUILayout.EndArea();
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

