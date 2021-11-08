using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    Basic,    //estado basico
    Special   //estado proyectil
}
public class PlayerController : MonoBehaviour
{
    public ShotType shotType;

    [Header("Rendering")]
    public Material basicMat;
    public Material specialMat;
    public Renderer rendBrazo;

    [Header("Shoot Parameters")]
    public Transform spawnShot;

    public GameObject basicBullet;
    public float basicFireRate;

    public GameObject specialBullet;
    public float specialFireRate;

    private float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shotType = ShotType.Basic;
            rendBrazo.material = basicMat;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shotType = ShotType.Special;
            rendBrazo.material = specialMat;
        }
    }

    void Shoot()
    {
        if (shotType == ShotType.Basic)
        {
            nextFire = Time.time + basicFireRate;
            Instantiate(basicBullet, spawnShot.position, Quaternion.identity);
        }
        if (shotType == ShotType.Special)
        {
            nextFire = Time.time + specialFireRate;
            Instantiate(specialBullet, spawnShot.position, Quaternion.identity);
        }

    }
}
