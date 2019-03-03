using UnityEngine;
using System.Collections;

using Hashtable = ExitGames.Client.Photon.Hashtable;
public class CGameManager : Photon.MonoBehaviour
{

    // this is a object name (must be in any Resources folder) of the prefab to spawn as player avatar.
    // read the documentation for info how to spawn dynamically loaded game objects at runtime (not using Resources folders)
    public string playerPrefabName = "Personnage";
    public string player2PrefabName = "Personnage";
    public GameObject rouge;
    public GameObject bleu;
    private string roomName = "myRoom2";
    //public CSpawnManager spawnManager;

    void Start()
    {
        StartGame();
    }

    private void OnConnectedToMaster()
    {
        if (PhotonNetwork.GetRoomList().Length == 0)

            PhotonNetwork.CreateRoom(roomName = null);
        else
            PhotonNetwork.JoinRandomRoom(); 
    }

    IEnumerator OnLeftRoom()
    {
        //Easy way to reset the level: Otherwise we'd manually reset the camera

        //Wait untill Photon is properly disconnected (empty room, and connected back to main server)
        while (PhotonNetwork.room != null || PhotonNetwork.connected == false)
            yield return 0;

        

    }

    void StartGame()
    {
        //empeche le groupe 1 d'evoyer 
        //PhotonNetwork.SetSendingEnabled(1, false);

        //empeche le groupe 1 de recevoir 
        //PhotonNetwork.SetReceivingEnabled(1, false);

        Camera.main.farClipPlane = 1000; //Main menu set this to 0.4 for a nicer BG    

        //prepare instantiation data for the viking: Randomly diable the axe and/or shield
        /*bool[] enabledRenderers = new bool[2];
        enabledRenderers[0] = Random.Range(0, 2) == 0;//Axe
        enabledRenderers[1] = Random.Range(0, 2) == 0; ;//Shield

        object[] objs = new object[1]; // Put our bool data in an object array, to send
        objs[0] = enabledRenderers;*/

        // Spawn our local player
        GameObject cube;
        //PhotonNetwork.player.se
        if (PhotonNetwork.playerList.Length<3)
        {
            PhotonNetwork.player.SetTeam(PunTeams.Team.red);
            cube = rouge;
        }            
        else
        {
            PhotonNetwork.player.SetTeam(PunTeams.Team.blue);
            cube = bleu;
        }

        string name = this.playerPrefabName;
        if (PhotonNetwork.playerList.Length %2==1)
            name = this.player2PrefabName;
        else
            name = this.playerPrefabName;
        GameObject player = PhotonNetwork.Instantiate(name, cube.transform.position, Quaternion.identity, 0/*, objs*/);

        //spawnManager.spawnStart();
    }

     void OnGUI()
     {
        if (PhotonNetwork.room == null) return; //Only display this GUI when inside a room

        /*if (GUILayout.Button("Leave Room"))
        {
            PhotonNetwork.LeaveRoom();
        }
        */
        ShowPing();
     }

    void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("OnDisconnectedFromPhoton");
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
}
