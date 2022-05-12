using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRotatoria : MonoBehaviour
{
    public Animator plataformaRotatoriaAnim;
    public int PlataformaRotatoriaSpeed = 2;
    public int random;

    public void Awake()
    {
        GetNewRandom();
    }

    private void GetNewRandom()
    {
        random = Random.Range(1, 7);
        //StartCoroutine(changeSpeed());
        plataformaRotatoriaAnim.speed = PlataformaRotatoriaSpeed;
    }

    private IEnumerator changeSpeed()
    {
        
        if (random > PlataformaRotatoriaSpeed)
        {
            yield return new WaitForSeconds(5);
            PlataformaRotatoriaSpeed++;
        }
        else if (random < PlataformaRotatoriaSpeed)
        {
            yield return new WaitForSeconds(5);
            PlataformaRotatoriaSpeed--;
        }
        if (random == PlataformaRotatoriaSpeed)
        {
            yield return new WaitForSeconds(15);
            GetNewRandom();
        }
        else
        {
            plataformaRotatoriaAnim.speed = PlataformaRotatoriaSpeed;
            StartCoroutine(changeSpeed());
        }
    }

}
