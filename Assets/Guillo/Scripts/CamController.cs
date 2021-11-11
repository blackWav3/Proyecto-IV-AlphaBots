using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform player;
    public float mouseX;
    public float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * speed;
        mouseY -= Input.GetAxis("Mouse Y") * speed;

        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
