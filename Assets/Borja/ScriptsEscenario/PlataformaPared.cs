using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPared : MonoBehaviour
{
    private Animator PlataformaParedAnim;

    private void Awake()
    {
        PlataformaParedAnim = this.gameObject.GetComponent<Animator>();
        StartCoroutine(Salir());
    }

    private IEnumerator Salir()
    {
        int random = 10;
        yield return new WaitForSeconds(random);
        PlataformaParedAnim.Play("Salir");
    }

    private IEnumerator Entrar()
    {
        int random = 15;
        yield return new WaitForSeconds(random);
        PlataformaParedAnim.Play("Entrar");
    }

}
