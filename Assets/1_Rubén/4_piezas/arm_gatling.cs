using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class arm_gatling : MonoBehaviour
{
    PhotonView photonview;
    GameObject muzzle;
    public GameObject gutling_proyectile;

    private void Start()
    {
        muzzle = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + ("Clone")).gameObject.transform.Find("muzzle").gameObject;
        photonview = GetComponent<PhotonView>();
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
            Instantiate(gutling_proyectile, muzzle.transform.position, muzzle.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(0.5f);
        }        
    }
}
