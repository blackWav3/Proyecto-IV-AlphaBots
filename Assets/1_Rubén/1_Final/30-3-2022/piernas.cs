using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;
public class piernas : MonoBehaviour
{
    bool canUseAbility = true;
    public int cooldown;
    PhotonView photonview;
    Estados estados;

    private void Start()
    {
        photonview = GetComponent<PhotonView>();
        estados = GetComponent<Estados>();
    }

    private void Update()
    {
        if (!photonview.IsMine) return;
        if(Input.GetKeyDown(KeyCode.X)&&canUseAbility == true)
        {
            StartCoroutine(correr());
        }
    }
    IEnumerator correr()
    {
        StartCoroutine(c_correr());
        canUseAbility = false;
        for(int i = cooldown; i > 0; i--)
        {
            GameObject.Find("txt_x").GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        canUseAbility = true;
        GameObject.Find("txt_x").GetComponent<Text>().text = "boost";
    }
    IEnumerator c_correr()
    {
        gameObject.GetComponent<Estados>().velocidadNormal = 0;
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        gameObject.GetComponent<Estados>().velocidadNormal = 7;
    }
}
