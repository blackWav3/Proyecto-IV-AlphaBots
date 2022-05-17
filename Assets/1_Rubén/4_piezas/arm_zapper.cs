using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class arm_zapper : MonoBehaviour
{
    [Header("Propiedades")]
    public int bulletSpeed;
    public int cooldown;
    public int actualcd;
    bool canUseAbility = true;

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
        if (transform.parent.name == "leftarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canUseAbility == true)
            {
                muzzleOrigin = muzzleIzq;
                Zapper();
                StartCoroutine(StartCooldown("txt_q"));
                StartCoroutine(animatorPlay.Laser());
            }
        }
        if (transform.parent.name == "rightarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && canUseAbility == true)
            {
                muzzleOrigin = muzzleDrch;
                Zapper();
                StartCoroutine(StartCooldown("txt_e"));
            }
        }
    }
    IEnumerator StartCooldown(string txt)
    {
        canUseAbility = false;
        actualcd = cooldown;

        while (actualcd > 0)
        {
            GameObject.Find(txt).GetComponent<Text>().text = actualcd.ToString();
            yield return new WaitForSeconds(1f);
            actualcd--;
        }       
        canUseAbility = true;
        GameObject.Find(txt).GetComponent<Text>().text = "zapper";
    }

    public void Zapper()
    {
        photonview.RPC("RPCzapper", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCzapper()
    {
        //GameObject bala = PhotonNetwork.Instantiate("Proyectiles/zapper_proyectile", muzzleOrigin.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        GameObject bala = PhotonNetwork.Instantiate("Proyectiles/zapper_proyectile", muzzleOrigin.transform.position, muzzleDirection.transform.rotation);
        //bala.transform.LookAt(muzzleDirection.transform);
        bala.GetComponent<bala>().speed = bulletSpeed;
    }

    //------------ ANIMACIONES
}
