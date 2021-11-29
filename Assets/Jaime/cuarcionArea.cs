using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuarcionArea : MonoBehaviour
{
    public GameObject area;

    
    public bool activadaCuracion;

    // Start is called before the first frame update
    void Start()
    {
        activadaCuracion = false;
        area.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
             if (activadaCuracion == false)
             {
                StartCoroutine(cooldown());
             }
        }



    }

    IEnumerator cooldown()
    {
        area.SetActive(true);
        activadaCuracion = true;
        yield return new WaitForSeconds(4f); //duracion de la habilidad
        area.SetActive(false);
        yield return new WaitForSeconds(10f); //cooldown hasta poder volver a usarla
        activadaCuracion = false;
    }
}
