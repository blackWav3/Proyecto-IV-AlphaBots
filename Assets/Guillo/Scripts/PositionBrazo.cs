using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBrazo : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.LookAt(target);
        transform.Rotate(-90, 0, 0, Space.Self);
    }
}
