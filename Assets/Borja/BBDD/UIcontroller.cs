using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public db manager;
    public int formulario = 0;
    public Text username;
    public Text password;


    public void Click()
    {
        switch (formulario)
        {
            case 0:
                manager.Loggin(username.text, password.text);
                break;
            case 1:
                manager.comprobarUsuarios(username.text);
                StartCoroutine(registro());
                break;
            case 2:
                manager.topPlayers();
                break;
        }
    }

    private IEnumerator registro()
    {
        yield return new WaitForSeconds(2);
        if (manager.canRegister)
            manager.insertarUsuario(username.text, password.text);
    }

}
