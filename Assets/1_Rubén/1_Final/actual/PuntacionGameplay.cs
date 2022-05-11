using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntacionGameplay : MonoBehaviour
{
    public Text txt_score2;
    public Text txt_score1;
    public Text txt_time;
    public int tiempoPartida;

    int int_score1;
    int int_score2;

    public GameObject posicionPERDEDOR1;
    public GameObject posicionPERDEDOR2;
    public GameObject posicionPERDEDOR3;

    public GameObject posicionGANADOR1;
    public GameObject posicionGANADOR2;
    public GameObject posicionGANADOR3;

    public GameObject camaraVictoria;

    private void Start()
    {
        int_score1 = 0;
        int_score2 = 0;
        StartCoroutine(CuentaAtras());
    }

    IEnumerator CuentaAtras()
    {
        for(int i = tiempoPartida; i > 0; i--)
        {
            txt_time.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
    }


    private void Update()
    {
        txt_score1.text = int_score1.ToString();
        txt_score2.text = int_score2.ToString();

        if (tiempoPartida<=0 ) //poner tambien si se llega a x puntuacion
        {
            if (int_score1>int_score2) //gana equipo azul
            {
                GameObject.Find("1(Clone)").GetComponent<PJ_movement>().CanTP = true;
                GameObject spwanPosition = posicionGANADOR1;
                GameObject.Find("1(Clone)").transform.parent = posicionGANADOR1.transform;
                GameObject.Find("1(Clone)").transform.position = new Vector3(0,0,0);
                camaraVictoria.SetActive(true);
            }

            if (int_score2 > int_score1) //gana equipo rojo
            {

            }
        }

    }
    public void Score1Up()
    {
        int_score1 += 1;
    }
    public void Score2Up()
    {
        int_score2 += 1;
    }
}
