using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject Da�oFlotante;
    public int da�oRealizado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        da�oRealizado = Random.Range(1,20);
    }

    public void mostrarDa�oRealizado(Transform spawnPadre)
    {
        Debug.Log("void");
        GameObject X = Instantiate(Da�oFlotante, spawnPadre.transform.position, Quaternion.identity, spawnPadre);
        X.GetComponent<DamageMarker>().HacerDa�o(da�oRealizado);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            Debug.Log("colision");
            mostrarDa�oRealizado(other.gameObject.transform.Find("Da�oVolador"));
        }
    }
    
}
