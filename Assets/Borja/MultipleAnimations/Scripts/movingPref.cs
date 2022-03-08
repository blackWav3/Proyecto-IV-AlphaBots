using UnityEngine;
using UnityEngine.UI;

public class movingPref : MonoBehaviour
{
    private animController contr;
    private Transform finalPosition;
    private float speed = 2f;

    public MP_piezas dataScripteable;

    public Text nombreT;
    public Text descripcionT;
    public Text danyoT;
    public Text cooldownT;

    public void Start()
    {
        nombreT = GameObject.Find("Nombre").GetComponent<Text>();
        descripcionT = GameObject.Find("Descripcion").GetComponent<Text>();
        danyoT = GameObject.Find("Daño").GetComponent<Text>();
        cooldownT = GameObject.Find("Cooldown").GetComponent<Text>();
        contr = GameObject.Find("animController").GetComponent<animController>();

        if (this.gameObject.name.Contains("Cabeza"))
        {
            finalPosition = GameObject.Find("HeadPosition").transform;
            transform.position = GameObject.Find("HeadSpawner").transform.position;
        }else if (this.gameObject.name.Contains("Torso"))
        {
            finalPosition = GameObject.Find("TorsoPosition").transform;
            transform.position = GameObject.Find("TorsoSpawner").transform.position;
        }
        else if (this.gameObject.name.Contains("Legs"))
        {
            finalPosition = GameObject.Find("LegsPosition").transform;
            transform.position = GameObject.Find("LegsSpawner").transform.position;
        }
        else if (this.gameObject.name.Contains("Arm"))
        {
            if (this.gameObject.name.Contains("DER"))
            {
                contr.brazoDerecho = true;
                finalPosition = GameObject.Find("Brazo2Position").transform;
                transform.position = GameObject.Find("Brazo2Spawner").transform.position;
            }
            else if (this.gameObject.name.Contains("IZQ"))
            {
                Debug.Log("a");
                finalPosition = GameObject.Find("Brazo1Position").transform;
                transform.position = GameObject.Find("Brazo1Spawner").transform.position;
            }
        }
        UpdateTextos();
    }

    void UpdateTextos()
    {
        nombreT.text = dataScripteable.name;
        descripcionT.text = dataScripteable.description;
        danyoT.text = ""+dataScripteable.damage;
        cooldownT.text = ""+dataScripteable.cooldown;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition.position, speed * Time.deltaTime);
    }
}
