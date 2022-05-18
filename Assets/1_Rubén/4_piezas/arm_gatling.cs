using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;

public class arm_gatling : MonoBehaviour
{
    [Header("Propiedades")]
    public int bulletSpeed;
    public float fireRatio;
    public int bulletsPerBurst;
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
                Gatling();
                StartCoroutine(StartCooldown("txt_q"));
                StartCoroutine(animatorPlay.Gatling());
            }
        }
        if (transform.parent.name == "rightarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && canUseAbility == true)
            {
                muzzleOrigin = muzzleDrch;
                Gatling();
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
        GameObject.Find(txt).GetComponent<Text>().text = "gatling";
    }
    public void Gatling()
    {
        photonview.RPC("RPCgatling", RpcTarget.AllBuffered);
    }
    [PunRPC]
    IEnumerator RPCgatling()
    {
        for(int i = 0; i < bulletsPerBurst; i++)
        {
            GameObject bala = null;
            //GameObject bala = PhotonNetwork.Instantiate ("Proyectiles/gatling_proyectile", muzzleOrigin.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            if (this.gameObject.transform.parent.parent.name == "1(Clone)" || this.gameObject.transform.parent.parent.name == "2(Clone)" || this.gameObject.transform.parent.parent.name == "3(Clone)")
            {
                bala = PhotonNetwork.Instantiate("Proyectiles/gatling_proyectile", muzzleOrigin.transform.position, muzzleDirection.transform.rotation);
            }
            else
            {
                bala = PhotonNetwork.Instantiate("Proyectiles/gatling_proyectile 1", muzzleOrigin.transform.position, muzzleDirection.transform.rotation);
            }
            //bala.transform.LookAt(muzzleDirection.transform);
            bala.GetComponent<bala>().speed = bulletSpeed;
            yield return new WaitForSeconds(fireRatio);
        }
    }

    //------------ ANIMACIONES
}
