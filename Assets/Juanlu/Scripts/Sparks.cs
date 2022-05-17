using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{

    public ParticleSystem chispa1;
    public ParticleSystem chispa2;

    public void ActivarChispas()
    {
        chispa1.Play();
        chispa2.Play();
    }

    public void DesactivarChispas()
    {
        chispa1.Stop();
        chispa2.Stop();
    }
}
