using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject DañoFlotante;
    public int dañoRealizado;

    public void mostrarDañoRealizado(Transform spawnPadre)
    {
        Debug.Log("void");
        GameObject X = Instantiate(DañoFlotante, spawnPadre.transform.position, Quaternion.identity, spawnPadre);
        X.GetComponent<DamageMarker>().HacerDaño(dañoRealizado);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            Debug.Log("colision");
            mostrarDañoRealizado(other.gameObject.transform.Find("DañoVolador"));
        }
    }
}
