using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDash : MonoBehaviour
{

    public Player Player;
    public float dashForce;
    public bool dashSpam = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Condición que no deja ejecutar el dash si no han pasado los segundos del cooldown
        if(dashSpam == false)
        {
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
            {
                Player.transform.position += new Vector3(0, 0, dashForce);
                dashSpam = true;
                StartCoroutine("SpamCooldown");
            }
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.A))
            {
                Player.transform.position += new Vector3(dashForce * -1, 0, 0);
                dashSpam = true;
                StartCoroutine("SpamCooldown");

            }
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S))
            {
                Player.transform.position += new Vector3(0, 0, dashForce * -1);
                dashSpam = true;
                StartCoroutine("SpamCooldown");

            }
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.D))
            {
                Player.transform.position += new Vector3(dashForce, 0, 0);
                dashSpam = true;
                StartCoroutine("SpamCooldown");

            }
        }
        
    }

    IEnumerator SpamCooldown()
    {
        yield return new WaitForSeconds(7);
        dashSpam = false;
    }
}
