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
    PhotonView photonView;


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
    }


    public void Shoot()
    {
        photonView.RPC("RPCShoot", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCShoot()
    {
        Instantiate(bala, transform.position, transform.rotation* Quaternion.Euler(0f, 0f, 0f));
    }

}

