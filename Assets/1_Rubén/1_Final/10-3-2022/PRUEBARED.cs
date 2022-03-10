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
    public Text infoPieza1;
    public Text infoPieza2;
    public Text infoPieza3;
    string info1;
    string info2;
    string info3;
    //dropdowns

    //public Dropdown brazoIzq, brazoDer, cabeza, pecho, piernas;
    public Dropdown brazoIzq;
    public Dropdown brazoDer;


    [Header("GUI")]
    [Space(15)]    
    public GameObject[] playersReady;
    public GameObject canvas_dropdowns;
    public GameObject canvas_match;
    
    private void Start()
    {
        info2 = "Al activarse aumenta la velocidad de movimiento durante unos segundos";
        playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        StartCoroutine(empezarpartida());
    }
    IEnumerator empezarpartida()
    {
        yield return new WaitForSeconds(10f);
        canvas_match.SetActive(true);
        SetUpPlayerAndCamera();
    }
    private void Update()
    {
        infoPieza1.text = info1;
        infoPieza2.text = info2;
        infoPieza3.text = info3;
        SetInfoDP();
    }
    private void SetInfoDP()
    {
        
        if (brazoIzq.value == 0) info1 = "Canalizado de 8 proyeciles seguidos. Alcance medio y da�o moderado";//gatling
        if (brazoIzq.value == 1) info1 = "Proyectil que al impactar deja inmovilizado al objetivo";//stun
        if (brazoIzq.value == 2) info1 = "Proyectil en parabola que al tocar el suelo se expande en un area ralentizadora";//slow
        if (brazoIzq.value == 3) info1 = "Proyectil de alto da�o , distancia y velocidad";//sniper
        if (brazoIzq.value == 4) info1 = "Canalizado de 12 proyectiles que dejan da�o en el tiempo";//flamethrower
        if (brazoIzq.value == 5) info1 = "Tajo con la espada en un area de 180 grados. Da�o moderado";//sword
        if (brazoIzq.value == 6) info1 = "Golpe descendente contra el suelo. Alto da�o y atudirmiento al impactar";//hamer

        if (brazoDer.value == 0) info3 = "Canalizado de 8 proyeciles seguidos. Alcance medio y da�o moderado";//gatling
        if (brazoDer.value == 1) info3 = "Proyectil que al impactar deja inmovilizado al objetivo";//stun
        if (brazoDer.value == 2) info3 = "Proyectil en parabola que al tocar el suelo se expande en un area ralentizadora";//slow
        if (brazoDer.value == 3) info3 = "Proyectil de alto da�o , distancia y velocidad";//sniper
        if (brazoDer.value == 4) info3 = "Canalizado de 12 proyectiles que dejan da�o en el tiempo";//flamethrower
        if (brazoDer.value == 5) info3 = "Tajo con la espada en un area de 180 grados. Da�o moderado";//sword
        if (brazoDer.value == 6) info3 = "Golpe descendente contra el suelo. Alto da�o y atudirmiento al impactar";//hamer
    }

    #region spawnjugadores
    public void SetUpPlayerAndCamera()//instancia pj y settea los componentes de camara y jugador por id
    {
        
        //set actie false de la mierda
        canvas_dropdowns.SetActive(false);
        PJcamara.GetComponent<PJ_camara>().enabled = true;
        //spawn jugador - movimiento camara al jugador
        PJplayer = PhotonNetwork.Instantiate("Characters/"+playerID.ToString(), spawnPoints[playerID-1].transform.position, spawnPoints[playerID-1].transform.rotation);
        PJcamara.GetComponent<PJ_camara>().player = GameObject.Find(playerID.ToString() + "(Clone)").gameObject.transform;
        GameObject.Find(playerID + "(Clone)").GetComponent<PJ_movement>().target = PJcamara.transform.GetChild(0).gameObject.transform;
        PJcamara.GetComponent<PJ_camara>().can = true;
        //montaje robot




        GameObject.Find(playerID + "(Clone)").transform.Find("leftarm").GetChild(brazoIzq.value).gameObject.SetActive(true);
        GameObject.Find(playerID + "(Clone)").transform.Find("rightarm").GetChild(brazoDer.value).gameObject.SetActive(true);

        //PJplayer.transform.Find("leftarm").GetChild(brazoIzq.value).gameObject.SetActive(true);
        //PJplayer.transform.Find("rightarm").GetChild(brazoDer.value).gameObject.SetActive(true);

        photonView.RPC(nameof(RPCmontaje), RpcTarget.OthersBuffered, brazoIzq.value, brazoDer.value, playerID);
        
    }
    [PunRPC]
    void RPCmontaje(int dpI,int dpD,int id)
    {
        GameObject.Find(id + "(Clone)").transform.Find("leftarm").GetChild(brazoIzq.value).gameObject.SetActive(true);
        GameObject.Find(id + "(Clone)").transform.Find("rightarm").GetChild(brazoDer.value).gameObject.SetActive(true);
        //PJplayer.transform.Find("leftarm").GetChild(dpI).gameObject.SetActive(true);
        //PJplayer.transform.Find("rightarm").GetChild(dpD).gameObject.SetActive(true);
    }

    #endregion
}
