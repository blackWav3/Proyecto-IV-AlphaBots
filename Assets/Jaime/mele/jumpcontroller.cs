using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpcontroller : MonoBehaviour
{
    

        public Vector3 jumpVector;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
            }
        }
    
}
