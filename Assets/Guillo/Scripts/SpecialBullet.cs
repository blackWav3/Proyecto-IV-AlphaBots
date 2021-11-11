using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float damage;
    public float range;

    float lifeTime = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > range)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
