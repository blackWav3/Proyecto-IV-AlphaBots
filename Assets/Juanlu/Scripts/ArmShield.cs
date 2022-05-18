using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmShield : MonoBehaviour
{
    public Animator shieldAnimation;
    public GameObject shield;
    public GameObject Player;
    public int lifeShield;
    bool activatedShield;

    bool spam = false;
    

    //uwu cool down del escudo
    public int cooldown; //<--esto se lo pones al yield return del coroutine y vas volando

    // Start is called before the first frame update
    void Start()
    {

        shieldAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeShield <= 0)
        {
            shieldAnimation.SetBool("shield", false);
            activatedShield = false;
            shield.SetActive(false);
            StartCoroutine(CDescudo());//<---cuando la vida del escudo llega  a 0 empieza el cooldown para que el escudo recupere la vida

        }

        //Activar habilidad (solo si la vida no es 0)
        if (Input.GetMouseButtonDown(0) && activatedShield == false && lifeShield !=0 && spam == false)
        {
            shieldAnimation.SetBool("shield", true); //Activamos la animación de sacar el escudo

            StartCoroutine("Delay");

            spam = true;
            StartCoroutine("ShieldSpam");

            Debug.Log("Activado");
            
        }
        else if (Input.GetMouseButtonDown(0) )
        {
            shieldAnimation.SetBool("shield", false);
            activatedShield = false;
            shield.SetActive(false);

            
            Debug.Log("Desactivado");

            Player.GetComponent<Player>().speed = Player.GetComponent<Player>().maxSpeed;  //Reestablecemos la velocidad
        }

        if (lifeShield <= 0)
        {
            Player.GetComponent<Player>().speed = Player.GetComponent<Player>().maxSpeed;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        shield.SetActive(true); //Hacemos aparecer el escudo

        Player.GetComponent<Player>().speed = Player.GetComponent<Player>().speed / 2;  //Reducimos la velocidad a la mitad cuando el escudo esté activo

        activatedShield = true; //El estado del escudo ahora es activo
    }
    

    //Cd para no spamear el escudo una vez lo desactivas
    IEnumerator ShieldSpam()
    {
        yield return new WaitForSeconds(4);
        spam = false; 
        
    }

    //CD escudo
    IEnumerator CDescudo()
    {
        yield return new WaitForSeconds(cooldown);
        lifeShield = 100;
    }
}
