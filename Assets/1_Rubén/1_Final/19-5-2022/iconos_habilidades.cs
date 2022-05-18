using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconos_habilidades : MonoBehaviour
{
    [Header("partes")]
    public GameObject[] brazoDerecho;
    public GameObject[] brazoIzquierdo;    
    public GameObject[] piernas;
    [Space(10)]
    [Header("dropdowns")]
    public Dropdown d_brazoderecho;
    public Dropdown d_brazoizquierdo;
    public Dropdown d_piernas;




    private void Start()
    {
        brazoDerecho[d_brazoderecho.value].SetActive(true);
        brazoIzquierdo[d_brazoizquierdo.value].SetActive(true);
        piernas[d_piernas.value].SetActive(true);

        d_brazoderecho.onValueChanged.AddListener(delegate { DropDownItemSelected_derecho(d_brazoderecho); });
        d_brazoizquierdo.onValueChanged.AddListener(delegate { DropDownItemSelected_izquierdo(d_brazoizquierdo); });
        d_piernas.onValueChanged.AddListener(delegate { DropDownItemSelected_piernas(d_piernas); });
    }
    void DropDownItemSelected_derecho(Dropdown dropdown)
    {
        foreach (GameObject a in brazoDerecho) a.SetActive(false);
        brazoDerecho[d_brazoderecho.value].SetActive(true);
    }
    void DropDownItemSelected_izquierdo(Dropdown dropdown)
    {
        foreach (GameObject a in brazoIzquierdo) a.SetActive(false);
        brazoIzquierdo[d_brazoizquierdo.value].SetActive(true);
    }
    void DropDownItemSelected_piernas(Dropdown dropdown)
    {
        foreach (GameObject a in piernas) a.SetActive(false);
        piernas[d_piernas.value].SetActive(true);
    }
}
