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
            if (balaScript.parentName == GameObject.Find("4(Clone)").name || balaScript.parentName == GameObject.Find("5(Clone)").name || balaScript.parentName == GameObject.Find("6(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("1(Clone)").name || other.gameObject.name == GameObject.Find("2(Clone)").name || other.gameObject.name == GameObject.Find("3(Clone)").name)
                {
                    mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
                }
            }
            else if (balaScript.parentName == GameObject.Find("1(Clone)").name || balaScript.parentName == GameObject.Find("2(Clone)").name || balaScript.parentName == GameObject.Find("3(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("4(Clone)").name || other.gameObject.name == GameObject.Find("5(Clone)").name || other.gameObject.name == GameObject.Find("6(Clone)").name)
                {
                    mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
                }
            }

        }
    }
}
