using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class explosionPJ : MonoBehaviour
{
    PhotonView photonview;
    private void Start()
    {
        photonview = GetComponent<PhotonView>();
    }
    public void InstanciarExplosion()
    {
        photonview.RPC("RPCinstanciarExplosion", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCinstanciarExplosion()
    {
        GameObject g_explosion = PhotonNetwork.Instantiate("Proyectiles/Explosion2.0 1", gameObject.transform.position, gameObject.transform.rotation);
    }
}
