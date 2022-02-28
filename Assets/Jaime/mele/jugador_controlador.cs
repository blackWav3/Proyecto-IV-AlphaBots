using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador_controlador : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 Mov = new Vector3(hor, 0, ver) * speed * Time.deltaTime;
        transform.Translate(Mov, Space.Self);

    }
}
