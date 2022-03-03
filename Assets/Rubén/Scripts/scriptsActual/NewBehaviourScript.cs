using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(tiempoDEstru());
    }
    IEnumerator tiempoDEstru()
    {
         yield return new WaitForSeconds(10f);

        Destroy(this.gameObject);

    }
}
