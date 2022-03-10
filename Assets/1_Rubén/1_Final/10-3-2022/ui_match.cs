using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ui_match : MonoBehaviour
{
    public Text vida;

    
    private void Update()
    {
        vida.text = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.GetComponent<Estados>().vida.ToString();        
    }   
}
