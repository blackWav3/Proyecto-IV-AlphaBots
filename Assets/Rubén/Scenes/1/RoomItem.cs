using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    LobbyManager manager;
    public Text roomName;

    void Start(){
        manager = FindObjectOfType<LobbyManager>();
    }

    public void SetRoomName(string _roomName){
        roomName.text=_roomName;
    }

    public void OnClickItem(){
        manager.JoinRoom(roomName.text);
    }
}
