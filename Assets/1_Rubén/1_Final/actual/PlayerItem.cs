using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPun
{
    public Text playerName;
    public Text playerName02;

    private void Start()
    {
        if (photonView.IsMine) 
        {  
            playerName02.text = PhotonNetwork.LocalPlayer.NickName;
            playerName.text = PhotonNetwork.LocalPlayer.NickName;
        }


        SetName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetName()
    {
        playerName02.text = photonView.Owner.NickName;
        playerName.text = photonView.Owner.NickName;
    }
}
