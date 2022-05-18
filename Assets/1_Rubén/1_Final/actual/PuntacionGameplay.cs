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

    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject jugador3;
    public GameObject jugador4;
    public GameObject jugador5;
    public GameObject jugador6;

    public GameObject canvasDesaparecer;
    public GameObject textoVictoriaRojos;
    public GameObject textoVictoriaAzules;

    
    
    public Animator animacion;


    private void Start()
    {
        int_score1 = 2;
        int_score2 = 0;

        

        


        StartCoroutine(CuentaAtras());
    }

    IEnumerator CuentaAtras()
    {
        for(int i = tiempoPartida; i >= 0; i--)
        {
            txt_time.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        tiempoPartida = 0;
    }
    

     void Update()
    {
        txt_score1.text = int_score1.ToString();
        txt_score2.text = int_score2.ToString();

        jugador1 = GameObject.Find("1(Clone)");

        if (GameObject.Find("2(Clone)") != null)
        {
            jugador2 = GameObject.Find("2(Clone)");
        }

        if (GameObject.Find("3(Clone)") != null)
        {
            jugador3 = GameObject.Find("3(Clone)");
        }

        if (GameObject.Find("4(Clone)") != null)
        {
            jugador4 = GameObject.Find("4(Clone)");
        }

        if (GameObject.Find("5(Clone)") != null)
        {
            jugador5 = GameObject.Find("5(Clone)");
        }

        if (GameObject.Find("6(Clone)") != null)
        {
            jugador6 = GameObject.Find("6(Clone)");
        }

        if (tiempoPartida<=0 ) //poner tambien si se llega a x puntuacion
        {

            if (int_score1>int_score2) //gana equipo azul
            {
                
                jugador4.GetComponent<PJ_movement>().CanTP = true;
                jugador4.transform.SetParent(posicionGANADOR1.transform);
                jugador4.transform.position = posicionGANADOR1.transform.position;

                jugador5.GetComponent<PJ_movement>().CanTP = true;
                jugador5.transform.SetParent(posicionGANADOR2.transform);
                jugador5.transform.position = posicionGANADOR2.transform.position;

                jugador6.GetComponent<PJ_movement>().CanTP = true;
                jugador6.transform.SetParent(posicionGANADOR3.transform);
                jugador6.transform.position = posicionGANADOR3.transform.position;


                jugador1.GetComponent<PJ_movement>().CanTP = true;
                jugador1.transform.SetParent(posicionPERDEDOR1.transform);
                jugador1.transform.position = posicionPERDEDOR1.transform.position;

                jugador2.GetComponent<PJ_movement>().CanTP = true;
                jugador2.transform.SetParent(posicionPERDEDOR2.transform);
                jugador2.transform.position = posicionPERDEDOR2.transform.position;

                jugador3.GetComponent<PJ_movement>().CanTP = true;
                jugador3.transform.SetParent(posicionPERDEDOR3.transform);
                jugador3.transform.position = posicionPERDEDOR3.transform.position;

                canvasDesaparecer.SetActive(false);
                textoVictoriaAzules.SetActive(true);
                camaraVictoria.SetActive(true);

                animacion.Play("ANIMACIONPUERTA");
            }

            if (int_score2 > int_score1) //gana equipo rojo
            {
                jugador1.GetComponent<PJ_movement>().CanTP = true;
                jugador1.transform.SetParent(posicionGANADOR1.transform);
                jugador1.transform.position = posicionGANADOR1.transform.position;

                jugador2.GetComponent<PJ_movement>().CanTP = true;
                jugador2.transform.SetParent(posicionGANADOR2.transform);
                jugador2.transform.position = posicionGANADOR2.transform.position;

                jugador3.GetComponent<PJ_movement>().CanTP = true;
                jugador3.transform.SetParent(posicionGANADOR3.transform);
                jugador3.transform.position = posicionGANADOR3.transform.position;


                jugador4.GetComponent<PJ_movement>().CanTP = true;
                jugador4.transform.SetParent(posicionPERDEDOR1.transform);
                jugador4.transform.position = posicionPERDEDOR1.transform.position;

                jugador5.GetComponent<PJ_movement>().CanTP = true;
                jugador5.transform.SetParent(posicionPERDEDOR2.transform);
                jugador5.transform.position = posicionPERDEDOR2.transform.position;

                jugador6.GetComponent<PJ_movement>().CanTP = true;
                jugador6.transform.SetParent(posicionPERDEDOR3.transform);
                jugador6.transform.position = posicionPERDEDOR3.transform.position;


                canvasDesaparecer.SetActive(false);
                textoVictoriaRojos.SetActive(true);
                camaraVictoria.SetActive(true);

                animacion.Play("ANIMACIONPUERTA");
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
