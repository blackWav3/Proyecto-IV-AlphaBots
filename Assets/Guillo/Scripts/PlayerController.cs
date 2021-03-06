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
    [Header("Player Parameters")]
    public CharacterController player;
    private float horizontalMove;   //movimiento en x
    private float verticalMove;    //movimiento en z
    public float playerSpeed;     //velocidad player

    /*[Header("Rendering")]
    public Material basicMat;
    public Material specialMat;         //para cuando a?adamos el disparo basico

    public Renderer rendBrazo;*/

    [Header("Shoot Parameters")]
    public ShotType shotType;      
    public Transform spawnShot;    //spawn de las balas

    /*public GameObject basicBulletPrefab;
    public float basicFireRate;*/               //para cuando a?adamos el disparo basico

    public GameObject specialBulletPrefab;
    public float specialFireRate;

    public bool healDeployed = false;

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

        Vector3 playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        playerInput = transform.TransformDirection(playerInput);

        player.Move(playerInput * playerSpeed * Time.deltaTime);

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Shoot();
        }
        if (Input.GetButton("Fire2") && healDeployed == false)
        {

        }

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shotType = ShotType.Basic;
            rendBrazo.material = basicMat;
        }                                                   
        if (Input.GetKeyDown(KeyCode.Alpha2))                   //para cuando a?adamos el disparo basico
        {
            shotType = ShotType.Special;
            rendBrazo.material = specialMat;
        }*/                                                     //para cuando a?adamos el disparo basico

    }

    void Shoot()
    {
        /*if (shotType == ShotType.Basic)
        {
            nextFire = Time.time + basicFireRate;
            Instantiate(basicBulletPrefab, spawnShot.position, Quaternion.identity);    //para cuando a?adamos el disparo basico
        }*/

        if (shotType == ShotType.Special)
        {
            nextFire = Time.time + specialFireRate;
            //Instantiate(specialBulletPrefab, spawnShot.position, spawnShot.rotation);
            Instantiate(specialBulletPrefab, spawnShot.position, spawnShot.rotation * Quaternion.Euler(0f, 0f, 0f));
        }
    }
}

