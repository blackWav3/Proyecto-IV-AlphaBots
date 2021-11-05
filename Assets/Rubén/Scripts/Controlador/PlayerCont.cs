using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCont : MonoBehaviour
{
    public Vector3 _moveDirection;
    public CharacterController _controller;

    float speed = 6f;
    float jumpForce = 13.0f;
    float antiBump = 0f;
    float gravity = 30f;
    public GameObject bala;

    PhotonView photonView;



    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        _controller.Move(_moveDirection * Time.deltaTime);
        DefaultMovement();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void DefaultMovement()
    {
        photonView.RPC("RPCDefaultMovement", RpcTarget.AllBuffered);

    }
    [PunRPC]
    void RPCDefaultMovement()
    {
        if (_controller.isGrounded)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * speed;
            _moveDirection.z = input.y * speed;
            _moveDirection.y = antiBump;

            _moveDirection = transform.TransformDirection(_moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }
    }



    private void Jump()
    {
        photonView.RPC("RPCJump", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCJump()
    {
        _moveDirection.y += jumpForce;
    }




    public void Shoot()
    {
        photonView.RPC("RPCShoot", RpcTarget.AllBuffered);
    }
    [PunRPC]
    void RPCShoot()
    {
        Instantiate(bala, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
    }
}
