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
        if (transform.parent.name == "leftarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canUseAbility == true)
            {
                Gatling();
                StartCoroutine(StartCooldown("txt_q"));

            }
        }
        if (transform.parent.name == "rightarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && canUseAbility == true)
            {
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
            //GameObject bala = PhotonNetwork.Instantiate ("Proyectiles/gatling_proyectile", muzzleOrigin.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            GameObject bala = PhotonNetwork.Instantiate("Proyectiles/gatling_proyectile", muzzleOrigin.transform.position, muzzleDirection.transform.rotation);
            //bala.transform.LookAt(muzzleDirection.transform);
            bala.GetComponent<bala>().speed = bulletSpeed;
            yield return new WaitForSeconds(fireRatio);
        }        
    }

    //------------ ANIMACIONES
}
