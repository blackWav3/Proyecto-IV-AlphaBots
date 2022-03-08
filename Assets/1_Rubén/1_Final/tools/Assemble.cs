using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Assemble : MonoBehaviour
{
    #region inputs
    [Header("Piezas")]
    public GameObject[] brazos;
    public GameObject[] piernas;
    //public GameObject[] cabeza;
    //public GameObject[] torso;
    [Header("-Posicion de instanciado")]
    public Transform t_brazoIzquierdo;
    public Transform t_brazoDerecho;
    public Transform t_piernas;
    //public Transform t_cabeza;
    //public Transform t_t;
    [Header("Dropdowns")]
    public Dropdown dp_brazoIzquierdo;
    public Dropdown dp_brazoDerecho;
    public Dropdown dp_piernas;
    //public Dropdown dp_cabeza;
    //public Dropdown dp_torso;
    #endregion

    private void Start() {
        FillerDropDownBrazos();//Set up automatico de los dropdowns con las piezas inputadas.
    }

    void InstanciadoDePiezasSeleccionadas(int brazoI,int brazoD,int piern){
        Instantiate(brazos[brazoI],t_brazoIzquierdo.position,t_brazoIzquierdo.rotation);
        Instantiate(brazos[brazoD],t_brazoDerecho.position,t_brazoDerecho.rotation);
        Instantiate(piernas[piern],t_piernas.position,t_piernas.rotation);
    }

    public void OnClickMontarRobot(){
        InstanciadoDePiezasSeleccionadas(dp_brazoIzquierdo.value,dp_brazoDerecho.value,dp_piernas.value);
    }

    void FillerDropDownBrazos(){
        for(int i = 0; i<brazos.Length ; i++){
            dp_brazoIzquierdo.options.Add(new Dropdown.OptionData(){text=brazos[i].name});
            dp_brazoDerecho.options.Add(new Dropdown.OptionData(){text=brazos[i].name});
        }
        for(int i = 0; i<piernas.Length ; i++){
            dp_piernas.options.Add(new Dropdown.OptionData(){text=piernas[i].name});        
        }
    }
}