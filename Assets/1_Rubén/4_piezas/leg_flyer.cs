using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leg_flyer : MonoBehaviour
{
    [Header("Propiedades")]
    public int duracionSprint;
    public int cdSprint;
    public int velocidadSprint;
    bool canUseAbility = true;
    int actualcd = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canUseAbility == true)
        {
            StartCoroutine(correr());
        }
        gameObject.GetComponent<PJ_movement>().playerSpeed = velocidadSprint;
    }
    IEnumerator correr()
    {
        StartCoroutine(c_correr());
        canUseAbility = false;
        actualcd = cdSprint;

        while (actualcd > 0)
        {
            GameObject.Find("txt_x").GetComponent<Text>().text = actualcd.ToString();
            yield return new WaitForSeconds(1f);
            actualcd--;
        }
        canUseAbility = true;
        GameObject.Find("txt_x").GetComponent<Text>().text = "boost";
    }

    IEnumerator c_correr()
    {
        velocidadSprint = 14;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        velocidadSprint = 7;
    }
}
