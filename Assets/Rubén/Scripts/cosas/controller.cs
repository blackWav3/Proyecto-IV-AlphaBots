using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    Vector2 turn;

    public int playerHP;
    //PARTES
    public GameObject[] BI;
    public GameObject[] BD;
    public GameObject[] PS;
    public GameObject bala;

    //UI
    [Header("UI")]
    public bool b_q, b_m1, b_e;
    GameObject hp_player;
    Text t_hp;




    //red electrica - - - - - - - - - 
    public GameObject redElectrica;
    bool _redelectrica;
    PhotonView photonView;
    public GameObject muzzle;
    //area slow - - - - - - - - - - - 
    public GameObject areaslow;


    private void Start()
    {
        hp_player = GameObject.Find("Hp");
        t_hp = hp_player.GetComponent<Text>();
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (!photonView.IsMine) return;

        t_hp.text = playerHP.ToString();

        float horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove = Input.GetAxis("Vertical");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        turn.x += Input.GetAxis("Mouse X");
        //turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        Vector3 move = transform.forward * verticalmove + transform.right * horizontalmove;
        characterController.Move(speed * Time.deltaTime * move);
        if(playerHP <= 0)
        {
            GameObject Vcamera = GameObject.Find("CM vcam1");
            print(Vcamera.name);
            Vcamera.transform.position = new Vector3(-33f, 18.46f, -0.81f);
            Vcamera.transform.rotation = Quaternion.Euler(30f, 90f, 0);
            Dead();

        }


        //habilidades - - - - - - - - - - - - - - - - - - - - - - 
        if (Input.GetKeyDown(KeyCode.Mouse0)&& b_m1==true)//2 sec
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E)&&b_e==true)//15 sec
        {
            redelectrica();
        }
        if (Input.GetKeyDown(KeyCode.Q)&& b_q==true)//10 sec
        {
            Areaslow();
        }
    }

    #region WinText
    public void Dead()
    {
        photonView.RPC("RPCDead", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCDead()
    {
        if (this.gameObject.name == "Character1(Clone)")
        {
            myphoton.red++;
        }
        else
        {
            myphoton.blue++;
        }
        Destroy(this.gameObject);
    }

    #endregion

    #region Shoot
    public void Shoot()
    {
        photonView.RPC("RPCShoot", RpcTarget.AllBuffered);
        StartCoroutine(cdm1());
    }
    IEnumerator cdm1() //mouse 1 cd
    {
        b_m1= false;
        yield return new WaitForSeconds(2f);
        b_m1 = true;
    }
   
    [PunRPC]
    void RPCShoot()
    {
        Instantiate(bala, muzzle.transform.position, transform.rotation* Quaternion.Euler(0f, 0f, 0f));
    }
    #endregion

    #region Red eléctrica
    public void redelectrica()
    {
        photonView.RPC("RPCredelectrica", RpcTarget.AllBuffered);
        StartCoroutine(cde());
    }
    [PunRPC]
    void RPCredelectrica()
    {
        Instantiate(redElectrica, muzzle.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
    }
    IEnumerator cde() //mouse 1 cd
    {
        b_e = false;
        yield return new WaitForSeconds(15f);
        b_e = true;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "redelectrica")
        {
            print("redelectrica");
            StartCoroutine(stunRedElectrica());
        }
        if(other.gameObject.tag == "slow")
        {
            print("slow");
            speed = 1;
        }
        if(other.gameObject.tag == ("proyectil"))
        {
            playerHP--;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "slow")
        {
            print("Slow exit");
            speed = 6;
        }
        
    }
    IEnumerator stunRedElectrica()
    {

        speed = 0;
        yield return new WaitForSeconds(5f);
        speed = 9;
    }
    IEnumerator cdRedElectrica()
    {
        _redelectrica = false;
        yield return new WaitForSeconds(3f);
        _redelectrica = true;
    }
    #endregion

    #region Area slow

    public void Areaslow()
    {
        photonView.RPC("RPCAreaslow", RpcTarget.AllBuffered);
        StartCoroutine(cdq());
    }
    IEnumerator cdq()//cd mouse
    {
        b_q = false;
        yield return new WaitForSeconds(10f);
        b_q = true;
    }
    [PunRPC]
    public void RPCAreaslow()
    {
        Instantiate(areaslow, muzzle.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
    }
    #endregion

}

