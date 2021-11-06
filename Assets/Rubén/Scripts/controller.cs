using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class controller : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    Vector2 turn;
    //PARTES
    public GameObject[] BI;
    public GameObject[] BD;
    public GameObject[] PS;
    public GameObject bala;

    //red electrica - - - - - - - - - 
    public GameObject redElectrica;
    bool _redelectrica;
    PhotonView photonView;
    public GameObject muzzle;


    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (!photonView.IsMine) return;
        float horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove = Input.GetAxis("Vertical");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        turn.x += Input.GetAxis("Mouse X");
        //turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        Vector3 move = transform.forward * verticalmove + transform.right * horizontalmove;
        characterController.Move(speed * Time.deltaTime * move);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }



        //habilidades - - - - - - - - - - - - - - - - - - - - - - 
        if (Input.GetKeyDown(KeyCode.E))
        {
            redelectrica();
        }
    }

    #region shoot
    public void Shoot()
    {
        photonView.RPC("RPCShoot", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCShoot()
    {
        Instantiate(bala, transform.position, transform.rotation* Quaternion.Euler(0f, 0f, 0f));
    }
    #endregion

    #region red el�ctrica
    public void redelectrica()
    {
        photonView.RPC("RPCredelectrica", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCredelectrica()
    {
        Instantiate(redElectrica, muzzle.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "redelectrica")
        {
            print("hola");
            StartCoroutine(stunRedElectrica());
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
}

