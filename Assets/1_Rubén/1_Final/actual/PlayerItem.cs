using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPun
{
    public Text playerName;
    public Image icon;

    private void Start()
    {
        if (photonView.IsMine) 
        {  
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
        playerName.text = photonView.Owner.NickName;
    }
}
