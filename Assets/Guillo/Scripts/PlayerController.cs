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

    public Material basicMat;
    public Material specialMat;
    public Renderer rendBrazo;

    public Transform spawnShot;
    public GameObject basicBullet;
    public GameObject specialBullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            Instantiate(basicBullet, spawnShot.position, Quaternion.identity);
        }
        if (shotType == ShotType.Special)
        {
            Instantiate(specialBullet, spawnShot.position, Quaternion.identity);
        }

    }
}
