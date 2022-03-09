using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class arm_gatling : MonoBehaviour
{
    PhotonView photonview;
    GameObject muzzleOrigin;
    GameObject muzzleDireciton;

    private void Start()
    {
        
        photonview = GetComponent<PhotonView>();
        if (!photonview.IsMine) return;
        muzzleOrigin = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzle").gameObject;
        muzzleDireciton = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (!photonview.IsMine) return;
        if (Input.GetKeyDown(KeyCode.E)) Gatling();
    }

    public void Gatling()
    {
        photonview.RPC("RPCgatling", RpcTarget.AllBuffered);
    }
    [PunRPC]
    IEnumerator RPCgatling()
    {
        for(int i = 0; i < 8; i++)
        {
            PhotonNetwork.Instantiate ("gutling_proyectile", muzzleOrigin.transform.position, muzzleDireciton.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(0.2f);
        }        
    }
}
