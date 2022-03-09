using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMisiles : MonoBehaviour
{
    [Header("Parámetros salva misiles")]
    public int cantidadMisiles;
    public float tiempoEntreMisiles;

    [Header("------------------------")]
    public GameObject g_misil;
    public GameObject bala;
    public GameObject muzzle;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(salvaMisiles());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            basurita();
        }
    }

    IEnumerator salvaMisiles()
    {
        int i = 0;
        while (i < cantidadMisiles)
        {
            Instantiate(g_misil, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(tiempoEntreMisiles);
            i++;
        }
    }
    void basurita()
    {
        Instantiate(bala, muzzle.transform.position, muzzle.transform.rotation);
    }
}
