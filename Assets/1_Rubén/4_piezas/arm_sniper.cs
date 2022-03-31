using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;


public class arm_sniper : MonoBehaviour
{
    [Header("Propiedades")]
    public int bulletSpeed;
    public int cooldown;
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
        if (transform.parent.name == "leftarm")
        {
            if (Input.GetKeyDown(KeyCode.Q) && canUseAbility == true)
            {
                Sniper();
                StartCoroutine(StartCooldown("txt_q"));
            } 
        }
        if (transform.parent.name == "rightarm")
        {
            if (Input.GetKeyDown(KeyCode.E) && canUseAbility == true)
            {
                Sniper();
                StartCoroutine(StartCooldown("txt_e"));
            }
        }
    }
    IEnumerator StartCooldown(string txt)
    {
        canUseAbility = false;
        for (int i = cooldown; i > 0; i--)
        {
            GameObject.Find(txt).GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        canUseAbility = true;
        GameObject.Find(txt).GetComponent<Text>().text = "sniper";
    }
    public void Sniper()
    {
        photonview.RPC("RPCsniper", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCsniper()
    {
        //GameObject bala = PhotonNetwork.Instantiate("Proyectiles/sniper_proyectile", muzzleOrigin.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        GameObject bala = PhotonNetwork.Instantiate("Proyectiles/sniper_proyectile", muzzleOrigin.transform.position, muzzleDirection.transform.rotation);
        //bala.transform.LookAt(muzzleDirection.transform);
        bala.GetComponent<bala>().speed = bulletSpeed;
    }
}
