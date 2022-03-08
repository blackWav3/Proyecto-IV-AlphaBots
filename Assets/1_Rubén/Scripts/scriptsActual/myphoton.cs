using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class myphoton : MonoBehaviourPunCallbacks
{
    public GameObject BlueWins, RedWins, exitButton;
    public static int blue, red;
    public GameObject spawnred1, spawnred2,spawnblue1, spawnblue2;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        

        blue = 0;
        red = 0;

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
    }
    private void Update()
    {
        if(blue == 2)
        {
            RedWins.SetActive(true);
            StartCoroutine(backtoLobby());
        }
        if (red == 2)
        {
            BlueWins.SetActive(true);
            StartCoroutine(backtoLobby());
        }
    }
    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, null);
    }
    IEnumerator backtoLobby(){
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("ConnectTo");

    }

   
}