using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;  //<--
using Photon.Realtime;  //<--

public class mp_ejemplo : MonoBehaviourPunCallbacks
{
    PhotonView photonView; //<--
    Transform target;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView)return;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        target = GameObject.Find("Main Camera").gameObject.transform.GetChild(0).gameObject.transform.transform;

        if (Input.GetKeyDown(KeyCode.Mouse0)) accion();
    }

    void accion()
    {
        if (!photonView.IsMine) return;
        photonView.RPC("RPCaccion", RpcTarget.AllBuffered);
    }

    [PunRPC]

    void RPCaccion()
    {

    }
}
