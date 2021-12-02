using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployHealing : MonoBehaviour
{
    public GameObject Target;           //target a quien apunta el rayo sanador
    private Transform targetpoint;      //punto del target al que apunta el rayo sanador
    public GameObject myLine = null;    //gameobject del rayo
    private bool isIn;                   //bool para comprobar si esta dentro del area de sanacion o fuera
    public Material lineMaterial;

    public float lifeTime = 5f;

    void Start()
    {
        isIn = false;
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        if (myLine == null)
        {
            myLine = new GameObject();
            myLine.AddComponent<LineRenderer>();   
        }

        myLine.name = "Cuerda";
        myLine.transform.position = start;

        LineRenderer lineRend = myLine.GetComponent<LineRenderer>();

        lineRend.material = lineMaterial;
        lineRend.startWidth = 0.1f;
        lineRend.SetPosition(0, start);              //asignamos las caracteristicas del rayo
        lineRend.SetPosition(1, end);
    }

    void Update()
    {
        if (isIn)
        {
            targetpoint = Target.transform;
            DrawLine(transform.position, targetpoint.position);            
        }

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            isIn = false;
            Target = null;
            Destroy(myLine);
            myLine = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isIn = true;
            Target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isIn = false;
            Target = null;
            Destroy(myLine);
            myLine = null;
        }
    }
}
