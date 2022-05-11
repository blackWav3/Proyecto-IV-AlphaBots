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
        int random = Random.Range(5, 15);
        yield return new WaitForSeconds(random);
        PlataformaParedAnim.Play("Salir");
    }

    private IEnumerator Entrar()
    {
        int random = Random.Range(5, 20);
        yield return new WaitForSeconds(random);
        PlataformaParedAnim.Play("Entrar");
    }

}
