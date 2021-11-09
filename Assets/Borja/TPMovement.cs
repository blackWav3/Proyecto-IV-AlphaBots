using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public Transform target;
    public bool bajando = false;
    public bool jump = true;
    public bool doubleJump = true;

    private Vector3 movimiento;
    private Vector3 gravedad;
    private Vector3 checkGravityPos;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        //Bloquea el cursor mientras juegas
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        //Recoje si esta tocando el suelo del Character Controller
        groundedPlayer = controller.isGrounded;
        //Si esta tocando el suelo se reinician los bools de saltar
        if (groundedPlayer)
        {
            doubleJump = true;
            jump = true;
        }

        //Si no esta en el suelo y ya ha saltado llama a la funcion de doble salto
        else if (groundedPlayer == false && jump == false && doubleJump == true)
            StartCoroutine(doubleJumpF());

        //Si la ultima posicion de altura recogida es más baja que la anterior significa que esta cayendo. Si no esta subiendo
        if (this.transform.position.y <= checkGravityPos.y && groundedPlayer == false)
            bajando = true;
            
        else if (this.transform.position.y >= checkGravityPos.y)
            bajando = false;
        
        checkGravityPos = this.transform.position;

        //Recoje el target que tiene la camara como hijo y siempre esta mirando hacia el
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);

        //Si esta en el suelo que la velocidad de caida sea 0
        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //Recoge la rotacion de la camara y hace que se mueva respecto a ella
        Vector3 targetDirection = new Vector3(h, 0f, v);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        
        movimiento = targetDirection * Time.deltaTime * playerSpeed;
        
        //Solo pueeds saltar si estas en el suelo y aun no has saltado
        if (Input.GetButtonDown("Jump") && groundedPlayer && jump)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jump = false;
        }
        //Añades la gravedad estandar a la velocidad en Y
        playerVelocity.y += gravityValue * Time.deltaTime;

        //Añades la velocidad total de Y
        gravedad = playerVelocity * Time.deltaTime;

        //Lo sumas y lo mueves
        controller.Move(movimiento + gravedad);
    }

    private IEnumerator doubleJumpF()
    {

        yield return new WaitForSeconds(0.01f);

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
