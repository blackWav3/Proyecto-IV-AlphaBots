using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque : MonoBehaviour
{
    public GameObject brazoD;public GameObject brazoI;public GameObject Rot;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            brazoD.GetComponent<Animator>().Play("basico");
            print(1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            brazoD.GetComponent<Animator>().Play("pesado");
            brazoI.GetComponent<Animator>().Play("pesadoIZq");
            Rot.GetComponent<Animator>().Play("rotacion_pesado");

            print(2);
        }
    }
}
