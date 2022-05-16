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
            if (this.gameObject.name == GameObject.Find("4(Clone)").name || this.gameObject.name == GameObject.Find("5(Clone)").name || this.gameObject.name == GameObject.Find("6(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("1(Clone)").name || other.gameObject.name == GameObject.Find("2(Clone)").name || other.gameObject.name == GameObject.Find("3(Clone)").name)
                {
                    mostrarDañoRealizado(other.gameObject.transform.Find("DañoVolador"));
                }
            }
            else if (this.gameObject.name == GameObject.Find("1(Clone)").name || this.gameObject.name == GameObject.Find("2(Clone)").name || this.gameObject.name == GameObject.Find("3(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("4(Clone)").name || other.gameObject.name == GameObject.Find("5(Clone)").name || other.gameObject.name == GameObject.Find("6(Clone)").name)
                {
                    mostrarDañoRealizado(other.gameObject.transform.Find("DañoVolador"));
                }
            }

        }
    }
}
