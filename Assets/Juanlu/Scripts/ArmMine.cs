using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMine : MonoBehaviour
{
    public Rigidbody mine;
    public Transform minePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody mineInstance;
            mineInstance = Instantiate(mine, minePos.position, mine.rotation);

        }
    }
}
