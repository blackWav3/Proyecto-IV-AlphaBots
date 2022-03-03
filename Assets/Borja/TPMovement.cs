using UnityEngine;

public class TPMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 4.0f;
    public float jumpHeight = 10.0f;
    public float gravityValue = -9.81f;

    public Transform target;
    public bool bajando = false;
    public bool jump = true;

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
    private void Update()
    {
        //Solo pueeds saltar si estas en el suelo y aun no has saltado
        if (Input.GetButtonDown("Jump") && groundedPlayer && jump)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jump = false;
        }

        //Recoje si esta tocando el suelo del Character Controller
        groundedPlayer = controller.isGrounded;
        //Si esta tocando el suelo se reinician los bools de saltar
        if (groundedPlayer)
        {
            jump = true;
        }
        else if (groundedPlayer != true)
        {
            jump = false;
        }

        //Si la ultima posicion de altura recogida es más baja que la anterior significa que esta cayendo. Si no esta subiendo
        if (this.transform.position.y <= checkGravityPos.y && groundedPlayer == false)
            bajando = true;

        else if (this.transform.position.y >= checkGravityPos.y)
            bajando = false;

        checkGravityPos = this.transform.position;
    }

    void FixedUpdate()
    {
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
        
        
        //Añades la gravedad estandar a la velocidad en Y
        playerVelocity.y += gravityValue * Time.deltaTime;

        //Añades la velocidad total de Y
        gravedad = playerVelocity * Time.deltaTime;

        //Lo sumas y lo mueves
        controller.Move(movimiento + gravedad);
    }
}
