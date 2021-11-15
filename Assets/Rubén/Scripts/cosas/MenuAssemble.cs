using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuAssemble : MonoBehaviour
{
    //PARTES
    public GameObject[] BI;
    public GameObject[] BD;
    public GameObject[] PS;
    //ID PARTES
    public Dropdown bi_;
    public Dropdown bd_;
    public Dropdown ps_;
    public static int bi, bd, ps;
    private void Awake()
    {
        bd_ = GameObject.Find("BD").GetComponent<Dropdown>();
        bi_ = GameObject.Find("BI").GetComponent<Dropdown>();
        ps_ = GameObject.Find("PS").GetComponent<Dropdown>();
       
    }
    private void Start()
    {
       
        assemble();
    }

    private void Update()
    {
        
    }
    public void assemble()
    {
        bi = bi_.value;
        bd = bd_.value;
        ps = ps_.value;
        int i = 0;
        while (i < BI.Length)
        {
            BI[i].SetActive(false);
            BD[i].SetActive(false);
            PS[i].SetActive(false);
            i++;
        }
        BI[bi_.value].SetActive(true);
        BD[bd_.value].SetActive(true);
        PS[ps_.value].SetActive(true);
    }
}
