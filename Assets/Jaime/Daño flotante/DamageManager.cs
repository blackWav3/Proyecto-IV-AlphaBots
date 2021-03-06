using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject DaņoFlotante;
    public int daņoRealizado;

    public void mostrarDaņoRealizado(Transform spawnPadre)
    {
        Debug.Log("void");
        GameObject X = Instantiate(DaņoFlotante, spawnPadre.transform.position, Quaternion.identity, spawnPadre);
        X.GetComponent<DamageMarker>().HacerDaņo(daņoRealizado);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            Debug.Log("colision");
            mostrarDaņoRealizado(other.gameObject.transform.Find("DaņoVolador"));
        }
    }
}
