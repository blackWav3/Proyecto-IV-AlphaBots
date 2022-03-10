using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBrazo : MonoBehaviour
{
    public Transform cam;
    public float pene;

    void Update()
    {
        pene = cam.transform.rotation.y;
        transform.rotation = Quaternion.EulerAngles(0, cam.transform.rotation.y, 0);
    }
}
