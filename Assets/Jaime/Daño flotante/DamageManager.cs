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
            if (this.gameObject.name == GameObject.Find("4(Clone)").name || this.gameObject.name == GameObject.Find("5(Clone)").name || this.gameObject.name == GameObject.Find("6(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("1(Clone)").name || other.gameObject.name == GameObject.Find("2(Clone)").name || other.gameObject.name == GameObject.Find("3(Clone)").name)
                {
                    mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
                }
            }
            else if (this.gameObject.name == GameObject.Find("1(Clone)").name || this.gameObject.name == GameObject.Find("2(Clone)").name || this.gameObject.name == GameObject.Find("3(Clone)").name)
            {
                if (other.gameObject.name == GameObject.Find("4(Clone)").name || other.gameObject.name == GameObject.Find("5(Clone)").name || other.gameObject.name == GameObject.Find("6(Clone)").name)
                {
                    mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
                }
            }

        }
    }
}
