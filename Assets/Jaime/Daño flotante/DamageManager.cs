using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject Da�oFlotante;
    public int da�oRealizado;
    public bala balaScript;

    private void Start()
    {
        balaScript = GetComponent<bala>();
    }
    public void mostrarDa�oRealizado(Transform spawnPadre)
    {
        GameObject X = Instantiate(Da�oFlotante, spawnPadre.transform.position, Quaternion.identity, spawnPadre);
        X.GetComponent<DamageMarker>().HacerDa�o(da�oRealizado);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
        }
    }
}
