using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float damage;

    float lifeTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(0, 0, 1) * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > 2)
        {
            Destroy(gameObject);
        }
    }
}
