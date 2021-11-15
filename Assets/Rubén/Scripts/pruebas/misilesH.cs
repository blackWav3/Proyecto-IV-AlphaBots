using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misilesH : MonoBehaviour
{
    [Header("Parametros misil")]
    public float velocidadUP;
    public float velocidadDOWN;
    public float tiempoAltura;

    bool asciende = false;
    bool desciende = false;
    GameObject target;
    Transform _target;
    Vector3 Tgt;


    private void Start()
    {
        target = GameObject.Find("objetivo");
        //transform.LookAt(target.transform.position);
        
        print(target.transform.position);

        StartCoroutine(ascender());
    }


    void Update()
    {
        if (asciende)
        {
            transform.position += transform.up * Time.deltaTime * velocidadUP;
        }

        if (desciende)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,velocidadDOWN*Time.deltaTime);
        }

    }


    IEnumerator ascender()
    {
        asciende = true;
        yield return new WaitForSeconds(tiempoAltura);
        //Tgt = target.transform.position;
        asciende = false;
        desciende = true;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Finish"))
        {
            Destroy(this.gameObject);
        }
    }

}
