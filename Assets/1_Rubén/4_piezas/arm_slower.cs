using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class arm_slower : MonoBehaviour
{
    [Header("Propiedades")]
    public int bulletSpeed;

    PhotonView photonview;
    GameObject muzzleOrigin;
    GameObject muzzleDirection;

    ActivadorAnim animatorPlay;

    private void Start()
    {
        photonview = GetComponent<PhotonView>();
        if (!photonview.IsMine) return;
        muzzleOrigin = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzle").gameObject;
        muzzleDirection = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;

        animatorPlay = GameObject.Find("Roboto").GetComponent<ActivadorAnim>();
    }

    private void Update()
    {
        if (!photonview.IsMine) return;
        if (transform.parent.name == "leftarm" && PRUEBARED.pauseAct)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Slower();
                animatorPlay.Laser();
            }
        }
        if (transform.parent.name == "rightarm" && PRUEBARED.pauseAct)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Slower();
                animatorPlay.Laser();
            }
        }
    }

    public void Slower()
    {
        photonview.RPC("RPCslower", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCslower()
    {
        GameObject bala = PhotonNetwork.Instantiate("Proyectiles/slower_proyectile", muzzleOrigin.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        bala.transform.LookAt(muzzleDirection.transform);
        bala.GetComponent<bala>().speed = bulletSpeed;
    }
}
