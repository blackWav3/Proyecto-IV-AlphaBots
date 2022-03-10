using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class arm_zapper : MonoBehaviour
{
    [Header("Propiedades")]
    public int bulletSpeed;

    PhotonView photonview;
    GameObject muzzleOrigin;
    GameObject muzzleDirection;

    private void Start()
    {
        photonview = GetComponent<PhotonView>();
        if (!photonview.IsMine) return;
        muzzleOrigin = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzle").gameObject;
        muzzleDirection = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (!photonview.IsMine) return;
        if (transform.parent.name == "leftarm")
        {
            if (Input.GetKeyDown(KeyCode.Q)) Zapper();
        }
        if (transform.parent.name == "rightarm")
        {
            if (Input.GetKeyDown(KeyCode.E)) Zapper();
        }
    }

    public void Zapper()
    {
        photonview.RPC("RPCzapper", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCzapper()
    {
        GameObject bala = PhotonNetwork.Instantiate("Proyectiles/zapper_proyectile", muzzleOrigin.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        bala.transform.LookAt(muzzleDirection.transform);
        bala.GetComponent<bala>().speed = bulletSpeed;
    }
}
