using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageMarker : MonoBehaviour
{
    public TextMeshPro TextoFlotante;
    private Transform PlayerTransform;

    private float Duracion=1f;
    private float velocidad=3f;

    void Start()
    {
        PlayerTransform = Camera.main.transform;
    }

    public void HacerDaño(int Daño)
    {
        TextoFlotante.SetText(Daño.ToString());
    }

    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - PlayerTransform.position);
        transform.position += new Vector3(0f, velocidad * Time.deltaTime, 0f);
        Duracion -= Time.deltaTime;
        if (Duracion<=0f)
        {
            Destroy(gameObject);
        }
    }


}
