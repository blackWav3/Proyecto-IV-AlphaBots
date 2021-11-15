using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Assembled");
    }
    public void multi()
    {
        SceneManager.LoadScene("multiplayer");
    }
}
