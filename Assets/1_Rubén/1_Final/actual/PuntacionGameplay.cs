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
