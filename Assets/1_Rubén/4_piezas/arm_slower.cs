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
    GameObject muzzleIzq;
    GameObject muzzleDrch;

    public GameObject roboto;
    ActivadorAnim animatorPlay;

    private void Start()
    {
        photonview = GetComponent<PhotonView>();
        if (!photonview.IsMine) return;
        muzzleIzq = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzleIzq").gameObject;
        muzzleDrch = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzleDrch").gameObject;
        muzzleDirection = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;

        animatorPlay = roboto.GetComponent<ActivadorAnim>();
    }

    private void Update()
    {
        if (!photonview.IsMine) return;
        if (transform.parent.name == "leftarm" && PRUEBARED.pauseAct)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                muzzleOrigin = muzzleIzq;
                Slower();
                StartCoroutine(animatorPlay.Laser());
            }
        }
        if (transform.parent.name == "rightarm" && PRUEBARED.pauseAct)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                muzzleOrigin = muzzleDrch;
                Slower();
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
