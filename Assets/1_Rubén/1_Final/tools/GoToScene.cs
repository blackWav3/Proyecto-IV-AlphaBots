using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string gotoscene;

    public void OnClickGoToScene()
    {
        SceneManager.LoadScene(gotoscene);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
