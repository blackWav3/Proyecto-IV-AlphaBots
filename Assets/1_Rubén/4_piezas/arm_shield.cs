using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;

public class arm_shield : MonoBehaviour
{
    [Header("Propiedades")]
    public GameObject shield;
    public GameObject Player;
    public int lifeShield;


    public int cooldown;
    public int actualcd;
    public bool canUseAbility = true;

    PhotonView photonview;
    GameObject muzzleOrigin;
    GameObject muzzleDirection;
    GameObject muzzleIzq;
    GameObject muzzleDrch;

    [HideInInspector] public GameObject roboto;
    [HideInInspector] ActivadorAnim animatorPlay;

    private void Start()
    {
        Player = this.gameObject.transform.parent.parent.gameObject;
        photonview = GetComponent<PhotonView>();
        if (!photonview.IsMine) return;
        muzzleIzq = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzleIzq").gameObject;
        muzzleDrch = GameObject.Find(PhotonNetwork.LocalPlayer.ActorNumber + "(Clone)").gameObject.transform.Find("muzzleDrch").gameObject;
        muzzleDirection = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;

        //animatorPlay = roboto.GetComponent<ActivadorAnim>();
    }

    private void Update()
    {
        if (!photonview.IsMine) return;
        if (transform.parent.name == "leftarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canUseAbility == true)
            {
                Debug.Log("Preuba1");
                muzzleOrigin = muzzleIzq;
                Shield();
                StartCoroutine(StartCooldown("txt_q"));
            }
        }
        if (transform.parent.name == "rightarm" && PRUEBARED.pauseAct == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && canUseAbility == true)
            {
                Debug.Log("Preuba2");
                muzzleOrigin = muzzleDrch;
                Shield();
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
        GameObject.Find(txt).GetComponent<Text>().text = "shield";
    }
    public void Shield()
    {
        photonview.RPC("RPCshield", RpcTarget.AllBuffered);
    }
    [PunRPC]
    public void RPCshield()
    {
        Debug.Log("Borja Prueba");
        if (lifeShield <= 0)
        {
            shield.SetActive(false);
            StartCoroutine(CDescudo());//<---cuando la vida del escudo llega  a 0 empieza el cooldown para que el escudo recupere la vida
        }

        //Activar habilidad (solo si la vida no es 0)
        if (lifeShield != 0 && !shield.active)
        {
            StartCoroutine("Delay");
        }

        if (shield.active)
        {
            shield.SetActive(false);

            Player.GetComponent<PJ_movement>().playerSpeed = Player.GetComponent<PJ_movement>().playerMaxSpeed;  //Reestablecemos la velocidad
        }

        if (lifeShield <= 0)
        {
            Player.GetComponent<PJ_movement>().playerSpeed = Player.GetComponent<PJ_movement>().playerMaxSpeed;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        shield.SetActive(true); //Hacemos aparecer el escudo

        Player.GetComponent<PJ_movement>().playerSpeed = Player.GetComponent<PJ_movement>().playerSpeed / 2;  //Reducimos la velocidad a la mitad cuando el escudo esté activo
    }

    IEnumerator CDescudo()
    {
        yield return new WaitForSeconds(cooldown);
        lifeShield = 100;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            if (collision.gameObject.tag == "Gatling")
            {
                Debug.Log("Gatling");
                lifeShield -= 5;
            }
            else if (collision.gameObject.tag == "Flamethrower")
            {
                lifeShield -= 5;
            }
            else if (collision.gameObject.tag == "Sniper")
            {
                lifeShield -= 50;
            }
        }
    }

}
