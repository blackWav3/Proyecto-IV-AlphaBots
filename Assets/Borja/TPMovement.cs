using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public Transform target;
    public bool bajando = false;
    private bool jump = true;
    public bool doubleJump = true;

    private Vector3 movimiento;
    private Vector3 gravedad;
    private Vector3 checkGravityPos;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            doubleJump = true;
            jump = true;
        }

        else if (groundedPlayer == false && jump == false && doubleJump == true)
            StartCoroutine(doubleJumpF());

        if (this.transform.position.y <= checkGravityPos.y && groundedPlayer == false)
            bajando = true;
            
        else if (this.transform.position.y >= checkGravityPos.y)
            bajando = false;
        
        checkGravityPos = this.transform.position;


        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);

        
        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 targetDirection = new Vector3(h, 0f, v);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;

        movimiento = targetDirection * Time.deltaTime * playerSpeed;

        if (targetDirection != Vector3.zero)
            gameObject.transform.forward = targetDirection;
        
        if (Input.GetButtonDown("Jump") && groundedPlayer && jump)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jump = false;
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime;

        gravedad = playerVelocity * Time.deltaTime;

        controller.Move(movimiento + gravedad);
    }

    private IEnumerator doubleJumpF()
    {
        yield return new WaitForSeconds(0.1f);

        if (Input.GetButtonDown("Jump") && doubleJump)
        {
            if (bajando == true)
                jumpHeight = 3;
            
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            doubleJump = false;
            jumpHeight = 1;
        }
    }
}
