using System.Collections;
using UnityEngine;

using Photon.Pun;
using UnityEngine.UI;
public class Estados : MonoBehaviour
{
    #region Parámetros
    [Header("Parámetros")]
    float velocidad;
    bool curacionA;
    bool dañoA;
    bool canUseAbility = true;
    [Header("piernas")]
    public int cooldown;

    public float velocidadNormal;
    public float velocidadRalentizado;
    public int vida;


    PhotonView photonview;


    PJ_movement pjmovement;

    #endregion
    private void Start() 
    {
        photonview = GetComponent<PhotonView>();
        velocidad = velocidadNormal;


    }
    IEnumerator correr()
    {
        StartCoroutine(c_correr());
        canUseAbility = false;
        for (int i = cooldown; i > 0; i--)
        {
            GameObject.Find("txt_x").GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        canUseAbility = true;
        GameObject.Find("txt_x").GetComponent<Text>().text = "boost";
    }
    IEnumerator c_correr()
    {
        velocidad = 14;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        velocidad = 7;
    }
    private void Update()
    {
       
        gameObject.GetComponent<PJ_movement>().playerSpeed = velocidad;
        if (!photonview.IsMine) return;
        if (Input.GetKeyDown(KeyCode.X) && canUseAbility == true)
        {
            StartCoroutine(correr());
        }
        if (vida <= 0)
        {
            if (!photonview.IsMine) return;
            GameObject.Find("Camera").GetComponent<Camera>().targetDisplay = 0;
            photonview.RPC("RPCsetactive", RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    void RPCsetactive()
    {
        gameObject.SetActive(false);
    }


    //-----------------------------------
    //-----------------------------------
    private void OnTriggerEnter(Collider other)
    {
        // S L O W
        if (other.gameObject.CompareTag("Slower")) RalentizarActivado();
        // S T U N
        if (other.gameObject.CompareTag("Zapper"))
        {
            StopCoroutine(Inhabilitar(0));
            StartCoroutine(Inhabilitar(3f));
        } 
        // G A T L I N G
        if (other.gameObject.CompareTag("Gatling")) Daño(8);
        // F L A M E T H R O W E R
        if (other.gameObject.CompareTag("Flamethrower"))
        {
            StopCoroutine(DañoPorSegundo(0, 0, 0));
            StartCoroutine(DañoPorSegundo(5,6,1));//hace 5 de daño por segundo durante 6 segundos no stackeable se reinicia el tiempo de sangrado
        }
        // S N I P E R
        if (other.gameObject.CompareTag("Sniper")) Daño(75);
        // S W O R D
        if (other.gameObject.CompareTag("Sword")) Daño(30);
        // M A R T I L L O
        if (other.gameObject.CompareTag("Hammer"))
        {
            Daño(45);
            StopCoroutine(Inhabilitar(0));
            StartCoroutine(Inhabilitar(2));
        }     
    }
    private void OnTriggerExit(Collider other)
    {
        // S L O W
        if (other.gameObject.CompareTag("Slower")) RalentizarDesactivado();
        #region Deploy
        if (other.gameObject.CompareTag("DeployHeal"))
            StartCoroutine(CuracionActiva(1, 1f));
        #endregion
    }

    /*private void OnTriggerStay(Collider other)
    {
        #region Deploy
        if (other.gameObject.CompareTag("DeployHeal"))
        {
            StartCoroutine(CuracionActiva(1, 1f));
        }
        #endregion
    }*/



// LISTA DE ESTADOS
// I N H A B I L I T A R
// StartCoroutine(Inhabilitar(x)) ---------------------- se inhabilita durante x segundos
#region Inhabilitar
    IEnumerator Inhabilitar(float o){ 
        velocidad = 0;
        yield return new WaitForSeconds(o);
        velocidad = velocidadNormal;
    }
#endregion
// R A L E N T I Z A R
// StartCoroutine(RalentizarTiempo(x)) ----------------- activa ralentizado durante x segundos
// RalentizarActivado() -------------------------------- activa ralentizado 
// RalentizarActivado() -------------------------------- desactiva ralentizado 
#region Ralentizar
    IEnumerator RalentizarTiempo(float o){
        velocidad = velocidadRalentizado;
        yield return new WaitForSeconds(o);
        velocidad = velocidadNormal;
    }
    void RalentizarActivado(){ 
        velocidad = velocidadRalentizado;
    }
    void RalentizarDesactivado(){ 
        velocidad = velocidadNormal;
    }
#endregion
// D A Ñ O
// Daño(x) --------------------------------------------- recibe x puntos de daño instantaneamente
// StartCoroutine(DañoPorSegundo(x,y,z)) --------------- rebice x puntos de daño durante y segundos cada z segundos
// StartCoroutine(DañoActivo(x,y)) -------------------------- recibe x puntos de daño cada y segundos(el efecto termina cuando se vuelve a llamar la coroutina)
#region Daño
    public void Daño(int o){
        vida-=o;
    }
    public IEnumerator DañoPorSegundo(int daño,int segundos,float csegundos){
        int i = 0;
        while(i<segundos){
            yield return new WaitForSeconds(csegundos);
            vida -= daño;
            i++;
        }  
    }
    public IEnumerator DañoActivo(int dañ,float seg){
    if(dañoA == false){
        dañoA = true;
        while(dañoA == true){
            yield return new WaitForSeconds(seg);
            vida -= dañ;
        }
    }
    else{
        dañoA = false;
    }
}
#endregion
// C U R A C I O N
// Curacion(x) ------------------------------------------ recibe x puntos de curacion instantaneamente
// StartCoroutine(CuracionPorSegundo(x,y,z)) ----------- recibe x puntos de curacion durante y segundos cada z segundos
// StartCoroutine(CuracionActiva(x,y)) ----------------- recibe x puntos de curacion cada y segundos(el efecto termina cuando se vuelve a llamar la coroutina)
#region Curacion
public void Curacion(int o){
    vida += o;
}
public IEnumerator CuracionPorSegundo(int curacion,int segundos,float csegundos){
        int i = 0;
        while(i<segundos){
            yield return new WaitForSeconds(csegundos);
            vida += curacion;
            i++;
        }  
    }
public IEnumerator CuracionActiva(int cur,float seg){
    if(curacionA == false){
        curacionA = true;
        while(curacionA == true){
            yield return new WaitForSeconds(seg);
            vida += cur;
        }
    }
    else{
        curacionA = false;
    }
}
#endregion
}
/* __________________________                       
  /\                         \                       
 /  \            ____         \                     
/ \/ \          /\   \         \                     
\ /\  \         \ \   \         \
 \  \  \     ____\_\   \______   \                   
  \   /\\   /\                \   \                 
   \ /\/ \  \ \_______    _____\   \                 
    \\/ / \  \/______/\   \____/    \               
     \ / /\\         \ \   \         \               
      \ /\/ \         \ \   \         \             
       \\/ / \         \ \   \         \             
        \ /   \         \ \   \         \           
         \\  /\\         \ \   \         \           
          \ /\  \         \ \___\         \         
           \\    \         \/___/          \         
            \  \/ \                         \       
             \ /\  \_________________________\       
              \  \ / ________________________ /      
               \  / ________________________ /        
                \/_________________________*/

