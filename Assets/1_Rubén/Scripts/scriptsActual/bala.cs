using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bala : MonoBehaviour
{
    [HideInInspector]
    public int speed;
    //public GameObject area;
    private void Start()
    {
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Slower")
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Sceneario")
            {
                PhotonNetwork.Instantiate("Area", transform.position = new Vector3(transform.position.x, 7.7f, transform.position.z), transform.rotation * Quaternion.Euler(0f, 0f, 0f));
                Destroy(gameObject);
            }
        }
       
        if(collision.gameObject.tag=="Player"||collision.gameObject.tag=="Scenario")
        {
            if(gameObject.tag == "Area") PhotonNetwork.Instantiate("Area", transform.position = new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            Destroy(gameObject);
        }

    }

    /*private void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.tag == "floor" && this.gameObject.tag == "slow" || other.gameObject.tag == "Player" && this.gameObject.tag == "slow")
        {
            Instantiate(area, transform.position = new Vector3(transform.position.x,-3.4f,transform.position.z), transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            //Destroy(this.gameObject);

        }
        Destroy(this.gameObject);
    }*/
}
