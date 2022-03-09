using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject Da�oFlotante;
    public int da�oRealizado;

    public void mostrarDa�oRealizado(Transform spawnPadre)
    {
        Debug.Log("void");
        GameObject X = Instantiate(Da�oFlotante, spawnPadre.transform.position, Quaternion.identity, spawnPadre);
        X.GetComponent<DamageMarker>().HacerDa�o(da�oRealizado);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            Debug.Log("colision");
            mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
        }
    }
}
