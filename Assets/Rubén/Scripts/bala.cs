using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public int speed;
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
}
