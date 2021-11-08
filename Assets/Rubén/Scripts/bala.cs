using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public int speed;
    public GameObject area;
    private void Start()
    {
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed ;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);

        if(other.gameObject.tag == "floor" && this.gameObject.tag == "slow")
        {
            Instantiate(area, transform.position = new Vector3(transform.position.x,-3.4f,transform.position.z), transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            //Destroy(this.gameObject);

        }
    }
}
