using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraControlador : MonoBehaviour
{

    public float speed;
    public Transform Target;
    public Transform Player;
    public float mouseX;
    public float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
     void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * speed;
        mouseY -= Input.GetAxis("Mouse Y") * speed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
