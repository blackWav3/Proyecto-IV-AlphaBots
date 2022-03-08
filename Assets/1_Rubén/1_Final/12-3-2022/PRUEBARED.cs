using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PRUEBARED : MonoBehaviourPunCallbacks
{

    int playerID;
    [Header("palyer-camera-spawnpoints")]
    public Transform[] spawnPoints;
    public GameObject PJcamara;
    public GameObject PJplayer;
    //dropdowns

    //public Dropdown brazoIzq, brazoDer, cabeza, pecho, piernas;
    [Header("GUI")]
    [Space(15)]    
    public GameObject[] playersReady;
    public GameObject canvas_dropdowns;
    
    private void Start()
    {
        playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        SetUpPlayerAndCamera();
    }

    #region spawnjugadores
    public void SetUpPlayerAndCamera()//instancia pj y settea los componentes de camara y jugador por id
    {

        //set actie false de la mierda
        //canvas_dropdowns.SetActive(false);

        //spawn jugador - movimiento camara al jugador
        PJplayer = PhotonNetwork.Instantiate("Characters/"+playerID.ToString(), spawnPoints[playerID-1].transform.position, spawnPoints[playerID-1].transform.rotation);
        PJcamara.GetComponent<PJ_camara>().player = GameObject.Find(playerID.ToString() + "(Clone)").gameObject.transform;
        GameObject.Find(playerID + "(Clone)").GetComponent<PJ_movement>().target = PJcamara.transform.GetChild(0).gameObject.transform;
        PJcamara.GetComponent<PJ_camara>().can = true;
        //montaje robot
        //photonView.RPC(nameof(RPCmontajeRobotEscena), RpcTarget.OthersBuffered, brazoIzq.options[brazoIzq.value].text, brazoDer.options[brazoIzq.value].text, cabeza.options[brazoIzq.value].text, pecho.options[brazoIzq.value].text, piernas.options[brazoIzq.value].text);
    }
    [PunRPC]
    void RPCmontajeRobotEscena(string brazoIzq, string brazoDer, string cabeza, string pecho, string piernas)
    {
        PhotonNetwork.Instantiate(brazoIzq,PJplayer.transform.Find("Piezas/leftArm").gameObject.transform.position,Quaternion.identity);
        PhotonNetwork.Instantiate(brazoDer, PJplayer.transform.Find("Piezas/rightArm").gameObject.transform.position, Quaternion.identity);
        PhotonNetwork.Instantiate(cabeza, PJplayer.transform.Find("Piezas/head").gameObject.transform.position, Quaternion.identity);
        PhotonNetwork.Instantiate(pecho, PJplayer.transform.Find("Piezas/chest").gameObject.transform.position, Quaternion.identity);
        PhotonNetwork.Instantiate(piernas, PJplayer.transform.Find("Piezas/legs").gameObject.transform.position, Quaternion.identity);
    }
    #endregion
}
