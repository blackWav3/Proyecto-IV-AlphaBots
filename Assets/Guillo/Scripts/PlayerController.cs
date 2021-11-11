using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    Basic,    //disparo basico
    Special   //disparo proyectil
}
public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public CharacterController player;
    private float horizontalMove;   //movimiento en x
    private float verticalMove;    //movimiento en z
    public float playerSpeed;     //velocidad player

    /*[Header("Rendering")]
    public Material basicMat;
    public Material specialMat;         //para cuando añadamos el disparo basico

    public Renderer rendBrazo;*/

    [Header("Shoot Parameters")]
    public ShotType shotType;      
    public Transform spawnShot;    //spawn de las balas

    /*public GameObject basicBulletPrefab;
    public float basicFireRate;*/               //para cuando añadamos el disparo basico

    public GameObject specialBulletPrefab;
    public float specialFireRate;

    private float nextFire = 0f;
    void Start()
    {
        player = GetComponent<CharacterController>();

        shotType = ShotType.Special;
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Shoot();
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shotType = ShotType.Basic;
            rendBrazo.material = basicMat;
        }                                                   
        if (Input.GetKeyDown(KeyCode.Alpha2))                   //para cuando añadamos el disparo basico
        {
            shotType = ShotType.Special;
            rendBrazo.material = specialMat;
        }*/    //para cuando añadamos el disparo basico

    }
    private void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        /*if (shotType == ShotType.Basic)
        {
            nextFire = Time.time + basicFireRate;
            Instantiate(basicBulletPrefab, spawnShot.position, Quaternion.identity);    //para cuando añadamos el disparo basico
        }*/

        if (shotType == ShotType.Special)
        {
            nextFire = Time.time + specialFireRate;
            //Instantiate(specialBulletPrefab, spawnShot.position, spawnShot.rotation);
            Instantiate(specialBulletPrefab, spawnShot.position, spawnShot.rotation * Quaternion.Euler(0f, 0f, 0f));
        }
    }
}

