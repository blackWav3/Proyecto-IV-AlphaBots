using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NametagLookAt : MonoBehaviour
{

    private Transform TRANSmainCam;
    // Start is called before the first frame update
    void Start()
    {
        TRANSmainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       transform.LookAt(transform.position + TRANSmainCam.rotation * Vector3.forward, TRANSmainCam.rotation * Vector3.up);
    }
}
