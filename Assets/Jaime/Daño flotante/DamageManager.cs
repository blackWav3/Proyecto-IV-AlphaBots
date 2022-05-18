using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject DañoFlotante;
    public int dañoRealizado;
    public bala balaScript;

    private void Start()
    {
        balaScript = GetComponent<bala>();
    }
    public void mostrarDañoRealizado(Transform spawnPadre)
    {
        GameObject X = Instantiate(DañoFlotante, spawnPadre.transform.position, Quaternion.identity, spawnPadre);
        X.GetComponent<DamageMarker>().HacerDaño(dañoRealizado);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            mostrarDañoRealizado(other.gameObject.transform.Find("DañoVolador"));
        }
    }
}
