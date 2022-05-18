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
            if (balaScript.parentName == GameObject.Find("4(Clone)").name || balaScript.parentName == GameObject.Find("5(Clone)").name || balaScript.parentName == GameObject.Find("6(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("1(Clone)").name || other.gameObject.name == GameObject.Find("2(Clone)").name || other.gameObject.name == GameObject.Find("3(Clone)").name)
                {
                    mostrarDañoRealizado(other.gameObject.transform.Find("DañoVolador"));
                }
            }
            else if (balaScript.parentName == GameObject.Find("1(Clone)").name || balaScript.parentName == GameObject.Find("2(Clone)").name || balaScript.parentName == GameObject.Find("3(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("4(Clone)").name || other.gameObject.name == GameObject.Find("5(Clone)").name || other.gameObject.name == GameObject.Find("6(Clone)").name)
                {
                    mostrarDañoRealizado(other.gameObject.transform.Find("DañoVolador"));
                }
            }

        }
    }
}
