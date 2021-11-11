using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class db : MonoBehaviour
{
    public bool canRegister;
    public class User
    {
        public int idPlayer, score, coins;
        public string username, password;

        public User(int idPlayer, int score, int coins, string username, string password)
        {
            this.idPlayer = idPlayer;
            this.score = score;
            this.coins = coins;
            this.username = username;
            this.username = username;
        }

    }
    public User player;
    public bool userReceived;
    public string domain;

    //configuration
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Loggin(string name, string pass) // 1
    {
        // http://localhost/
        connectionInProcess = true;
        //Read data from ddbb
        string url = domain + "/Proyecto4/loggin.php?NAME=" + name + "&PASS=" + pass;
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        StartCoroutine(WaitForRequest_Select(www, 1));
    }

    public void comprobarUsuarios(string name) // 1
    {
        // http://localhost/
        connectionInProcess = true;
        //Read data from ddbb
        string url = domain + "/Proyecto4/comprobarUsuario.php?NAME=" + name;
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        StartCoroutine(WaitForRequest_Select(www, 1));
    }

    public void insertarUsuario(string name, string pass)
    {
        connectionInProcess = true;
        //Read data from ddbb
        string url = domain + "/Proyecto4/insertarusuario.php?NAME=" + name + "&PASS=" + pass;
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        StartCoroutine(WaitForRequestCreate(www, 1));
    }

    public void topPlayers() // 4
    {
        connectionInProcess = true;
        //Read data from ddbb
        string url = domain + "/Proyecto4/topPlayers.php";
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        StartCoroutine(WaitForRequest_Select(www, 1));
    }

    // D D B B
    [Header("Connection variables")]
    public string ip;

    public string puerto;

    private string answerDB;
    private bool connectionInProcess = false, connectionEnd;
    private int connectionType = 0;

    [Header("User Read")]
    public List<User> userList = new List<User>();

    [Header("Id from Type created")]
    public int idType;


    private IEnumerator WaitForRequest_Select(UnityWebRequest www, int mode = 0)
    {
        userReceived = false;
        yield return www.SendWebRequest();
        //connectionType = 0;
        string[] finalString = new string[0];
        // check for errors
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("WWW Error: " + www.error);
            connectionEnd = true;
            yield break;
        }

        userList.Clear();
        string JsonStringHP = www.downloadHandler.text;
        if (JsonStringHP.Contains("},{"))
        {
            string[] Text0 = JsonStringHP.Split(new[] { "},{" }, StringSplitOptions.None);
            finalString = new string[Text0.Length];
            for (int i = 0; i < Text0.Length; i++)
            {
                if (i == 0)
                {
                    finalString[i] = Text0[i] + "}]";
                }
                else
                {
                    if (i == Text0.Length - 1)
                    {
                        finalString[i] = "[{" + Text0[i];
                    }
                    else
                    {
                        finalString[i] = "[{" + Text0[i] + "}]";
                    }
                }

            }
            string temp = Text0[0] + "}]";
            JsonStringHP = temp;
        }
        else
        {
            finalString = new string[1] { JsonStringHP };
        }
        for (int i = 0; i < finalString.Length; i++)
        {
            finalString[i] = finalString[i].Replace("[", "");
            finalString[i] = finalString[i].Replace("]", "");
            Debug.Log(finalString[i]);
            User userAux = JsonUtility.FromJson<User>(finalString[i]);
            userList.Add(userAux);
            if (mode == 1) // datos del jugador
            {
                player = userAux;
                if (finalString[i] == "")
                    canRegister = true;
                
                else
                {
                    if (!userAux.username.Equals(""))
                        userReceived = true;
                }
                
            }
        }

        connectionEnd = true;
    }

    private IEnumerator WaitForRequestCreate(UnityWebRequest www, int idConnectionType)
    {
        yield return www.SendWebRequest();
        // check for errors
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("WWW Error: " + www.error);
        }
        else
        {
            //   listaArchivos = www.text.Split(';');
            answerDB = www.downloadHandler.text;
        }
        //if we want to check both at the same time, we need to change the logic
        if (idConnectionType >= 0)
            connectionType = idConnectionType;

        if (idConnectionType == 1)
        {
            canRegister = false;
        }

        connectionEnd = true;
    }
}
