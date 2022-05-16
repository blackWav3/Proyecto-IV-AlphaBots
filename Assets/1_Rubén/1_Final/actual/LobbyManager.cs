using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;

    public Sprite[] iconos = new Sprite[6]; 
    public Sprite[] marcos = new Sprite[2]; 

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject playButton;

    [Space(10)]
    //LEVEL TO LOAD
    public string levelToLoad;


    void Start(){
        PhotonNetwork.JoinLobby();
        
    }
    public void OnClickCreate(){
        if(roomInputField.text.Length>=1){
            PhotonNetwork.CreateRoom(roomInputField.text,new RoomOptions(){MaxPlayers = 6});
        }
    }
    public override void OnJoinedRoom(){
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text="Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time>=nextUpdateTime){
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo>list){
        foreach (RoomItem item in roomItemsList){
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();
        foreach (RoomInfo room in list){
            RoomItem newRoom = Instantiate(roomItemPrefab,contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }
    public void OnClickLeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom(){
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }
    
    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }

   public void UpdatePlayerList(){
       foreach (PlayerItem item in playerItemsList)
       {
           Destroy(item.gameObject);
       }
       playerItemsList.Clear();

       if(PhotonNetwork.CurrentRoom == null){
           return;
       }
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList){
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.icon.sprite = iconos[playerItemsList.Count];
            playerItemsList.Add(newPlayerItem);
            for (int i = 0; i < playerItemsList.Count; i++)
            {
                playerItemsList[i].playerName.text = PhotonNetwork.PlayerList[i].NickName;

                if (playerItemsList.Count > 3)
                {
                    playerItemsList[i].border.sprite = marcos[1];
                }
                else
                {
                    playerItemsList[i].border.sprite = marcos[0];
                }
            }
        }

   }
   void Update() {
       UpdatePlayerList();
       if(PhotonNetwork.IsMasterClient){
           playButton.SetActive(true);
       }
       else{
           playButton.SetActive(false);
       }
   }
   public void OnClickPlayButton(){
       PhotonNetwork.LoadLevel(levelToLoad);
   }   
}
