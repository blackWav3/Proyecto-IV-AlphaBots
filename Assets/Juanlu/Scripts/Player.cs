using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public int maxSpeed = 10;
    Rigidbody rb;
    Vector3 movementInput;

    

    // Start is called before the first frame update
    void Start()
    {
        speed = maxSpeed;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.z = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1;
        }
    }

    protected void FixedUpdate()
    {
        Move(movementInput);
    }

    void Move(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);

        //rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);

        //transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
