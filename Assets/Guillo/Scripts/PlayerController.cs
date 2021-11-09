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
    private float horizontalMove;
    private float verticalMove;
    public float playerSpeed;

    [Header("Rendering")]
    public Material basicMat;
    public Material specialMat;
    public Renderer rendBrazo;

    [Header("Shoot Parameters")]
    public ShotType shotType;
    public Transform spawnShot;

    public GameObject basicBulletPrefab;
    public float basicFireRate;

    public GameObject specialBulletPrefab;
    public float specialFireRate;

    private float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

        shotType = ShotType.Basic;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

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
    private void FixedUpdate()
    {
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (shotType == ShotType.Basic)
        {
            nextFire = Time.time + basicFireRate;
            Instantiate(basicBulletPrefab, spawnShot.position, Quaternion.identity);
        }
        if (shotType == ShotType.Special)
        {
            nextFire = Time.time + specialFireRate;
            Instantiate(specialBulletPrefab, spawnShot.position, spawnShot.rotation);
        }
    }
}
