using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animController : MonoBehaviour
{

    [Header("Comprobantes de si ya tiene las piezas")]
    [HideInInspector] public bool piernas = false;
    [HideInInspector] public bool torso = false;
    [HideInInspector] public bool brazoDerecho = false;
    [HideInInspector] public bool brazoIzquierdo = false;
    [HideInInspector] public bool cabeza = false;

    [Header("Botones")]
    public Dropdown brazoDDrop;
    public Dropdown brazoIDrop;
    public Dropdown piernasDrop;

    [Header("Prefabs")]
    public GameObject[] prefBrazoD;
    public GameObject[] prefBrazoI;
    public GameObject[] prefPiernas;

    [Header("Instance positions")]
    public Transform headPosition;
    public Transform bodyposition;
    public Transform arm1Position;
    public Transform arm2Position;
    public Transform legsPosition;

    [Header("GameObjects Instanciados")]
    public GameObject instanBrazoD, instanBrazoI, instanCabeza, instanTorso, instanPiernas;

    private Vector3 instancePosition;

    

    /*
    public void InstanceBrazoD(string nombre)
    {
        for (int i = 0; i < prefBrazoD.Length; i++)
        {
            if (brazoDDrop[i].name == nombre)
            {
                GameObject prefInstan = Instantiate(brazoDDrop[i], instancePosition, Quaternion.identity);
            }
        }
    }
    */
    public void InstanceBrazoD()
    {
        if (brazoDerecho == true)
        {
            Destroy(instanBrazoD);
        }
        instanBrazoD = Instantiate(prefBrazoD[brazoDDrop.value], instancePosition, Quaternion.identity);
        brazoDerecho = true;
    }

    public void InstanceBrazoI()
    {
        if (brazoIzquierdo == true)
        {
            Destroy(instanBrazoI);
        }
        instanBrazoI = Instantiate(prefBrazoI[brazoIDrop.value], instancePosition, Quaternion.identity);
        brazoIzquierdo = true;
    }
    
    public void InstancePiernas()
    {
        if (piernas == true)
        {
            Destroy(instanPiernas);
        }
        instanPiernas = Instantiate(prefPiernas[piernasDrop.value], instancePosition, Quaternion.identity);
        piernas = true;
    }

}
