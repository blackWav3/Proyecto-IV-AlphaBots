using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivadorAnim : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public IEnumerator Gatling()
    {
        anim.SetBool("Gatling", true);
        yield return null;
        anim.SetBool("Gatling", false);
    }
    public IEnumerator Laser()
    {
        anim.SetBool("Laser", true);
        yield return null;
        anim.SetBool("Laser", false);
    }
    public IEnumerator Flamethrower()
    {
        anim.SetBool("Flamethrower", true);
        yield return null;
        anim.SetBool("Flamethrower", false);
    }
}
