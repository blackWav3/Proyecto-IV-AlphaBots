using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiCD : MonoBehaviour
{
    public GameObject _Q, _M0, _E;
    public int a, b, c;
    public Text tQ, tM0, tE;
    public bool b_q, b_m0, b_e;
    
    
    
    
    private void Start()
    {
        
        b = 2;
        c = 15;
       
    }
    private void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Q) && b_q == true)
        {
            a = 10;
            b_q = false;
            _Q.SetActive(true);
            StartCoroutine(qCD());
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && b_m0 == true)
        {
            b = 2;
            b_m0 = false;
            _M0.SetActive(true);
            StartCoroutine(m0CD());
        }

        if (Input.GetKeyDown(KeyCode.E) && b_e == true)
        {
            c = 15;
            b_e = false;
            _E.SetActive(true);
            StartCoroutine(eCD());
        }

    }
    IEnumerator qCD()
    {
        int i = 0;
        while (i < 10)
        {
            tQ.text = a.ToString();
            yield return new WaitForSeconds(1f);
            i++;
            a--;
        }
        b_q = true;
        _Q.SetActive(false);
    }
    IEnumerator m0CD()
    {
        int i = 0;
        while (i < 2)
        {
            tM0.text = b.ToString();
            yield return new WaitForSeconds(1f);
            i++;
            b--;
        }
        b_m0 = true;
        _M0.SetActive(false);
    }
    IEnumerator eCD()
    {
        int i = 0;
        while (i < 15)
        {
            tE.text = c.ToString();
            yield return new WaitForSeconds(1f);
            i++;
            c--;
        }
        b_e = true;
        _E.SetActive(false);
    }



}
