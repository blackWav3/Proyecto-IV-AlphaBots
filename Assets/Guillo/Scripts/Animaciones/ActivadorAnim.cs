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
    public void Gatling()
    {
        anim.SetTrigger("Gatling");
    }
    public void Laser()
    {
        anim.SetTrigger("Laser");
    }
    public void Flamethrower()
    {
        anim.SetTrigger("Flamethrower");
    }
}
