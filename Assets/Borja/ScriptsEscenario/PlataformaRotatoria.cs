using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRotatoria : MonoBehaviour
{
    public Animator plataformaRotatoriaAnim;
    public int PlataformaRotatoriaSpeed = 1;
    public int plataformaRotatoriaSpeed
    {
        get { return PlataformaRotatoriaSpeed; }
        set 
        {
            PlataformaRotatoriaSpeed = value;
            plataformaRotatoriaAnim.speed = PlataformaRotatoriaSpeed;
        }
    }
}
