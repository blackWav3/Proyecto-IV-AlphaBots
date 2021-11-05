using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;


public class myphoton : MonoBehaviourPunCallbacks
{

    public GameObject spawnred1, spawnred2,spawnblue1, spawnblue2;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, null);
    }

    public override void OnJoinedRoom()
    {
        int Idplayer = PhotonNetwork.CountOfPlayers;
        print(Idplayer);

        #region spawn posicionado
        if (Idplayer == 1)
        {
            GameObject newPlayer = PhotonNetwork.Instantiate("Character1", spawnred1.transform.position, Quaternion.identity);
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;
        }
        if (Idplayer == 2)
        {
            GameObject newPlayer = PhotonNetwork.Instantiate("Character1", spawnred2.transform.position, Quaternion.identity);
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;

        }
        if (Idplayer == 3)
        {
            GameObject newPlayer = PhotonNetwork.Instantiate("Character2", spawnblue1.transform.position, Quaternion.Euler(0, 180, 0));
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;

        }
        if (Idplayer == 4)
        {
            GameObject newPlayer = PhotonNetwork.Instantiate("Character2", spawnblue2.transform.position, Quaternion.Euler(0, 180, 0));
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;

        }
        #endregion

        #region spawn1 
        /*if(Idplayer==2 || Idplayer == 3)
        {
            GameObject newPlayer = PhotonNetwork.Instantiate("Character1", spawnred.transform.position, Quaternion.identity);
            //GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().transform.rotation = (Quaternion.Euler(20, 1, 1));
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;
        }
        if (Idplayer == 0 || Idplayer == 1)
        {
            GameObject newPlayer = PhotonNetwork.Instantiate("Character2", spawnblue.transform.position, Quaternion.identity);
            //GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().transform.rotation = (Quaternion.Euler(24, 180, 0));
            //GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().transform.position = new Vector3(0, 5, 36);
            //GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = newPlayer.transform;
        }*/
        #endregion
    }
}
