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

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!PV.IsMine) return;
        if(Input.GetKeyDown(KeyCode.Mouse0)) PV.RPC("disparacion", RpcTarget.AllBuffered);
    }

    
    void disparo()
    {
        StartCoroutine(disparacion());        
    }
    [PunRPC]
    IEnumerator disparacion()
    {
        print("c_disparo");
        for (int i = 0; i < cantidad; i++)//poner prefab en carpeta que toca
        {
            GameObject balaActual = PhotonNetwork.Instantiate("Bala", Muzzle.transform.position, Quaternion.identity); 
            balaActual.GetComponent<Rigidbody>().AddForce(transform.forward * velocidadaBala);
            yield return new WaitForSeconds(TiempoEspaciado);
        }
    }
}
