using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class disparos : MonoBehaviour
{
    PhotonView PV;
    public Transform Muzzle;
    public int cantidad;
    public float TiempoEspaciado;
    public float velocidadaBala;
    public GameObject prefabBala;

    void OnMouseDown()
    {
        if (!PV.IsMine) return;
        PV.RPC("disparo", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void disparo()
    {
        StartCoroutine(disparacion());        
    }

    IEnumerator disparacion()
    {
        for (int i = 0; i <= cantidad; i++)
        {
            GameObject balaActual = PhotonNetwork.Instantiate("prefabBala", Muzzle.transform.position, Quaternion.identity);
            balaActual.GetComponent<Rigidbody>().AddForce(transform.forward * velocidadaBala);
            yield return new WaitForSeconds(TiempoEspaciado);
        }
    }
}
