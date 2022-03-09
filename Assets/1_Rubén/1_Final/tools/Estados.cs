using System.Collections;
using UnityEngine;

public class Estados : MonoBehaviour
{
    #region Parámetros
    [Header("Parámetros")]
    int velocidad;
    bool curacionA;
    bool dañoA;

    public int velocidadNormal;
    public int velocidadRalentizado;
    public int vida;

    PJ_movement pjmovement;

    #endregion
    private void Start() 
    {
        velocidad = velocidadNormal;
                
    }
    private void Update()
    {
        gameObject.GetComponent<PJ_movement>().playerSpeed = velocidad;
    }
    //-----------
    
    //-----------
    private void OnTriggerEnter(Collider other)
    {
        print("oooooooooooooooooooooooooooooo");
        #region Armas melee

        //Chainsaw
        if (other.gameObject.CompareTag("Chainsaw"))
            Daño(2);
        
        //Sword
        if (other.gameObject.CompareTag("Sword"))
            Daño(1);
        
        //Hammer
        if (other.gameObject.CompareTag("Hammer"))
            Daño(2);

        #endregion

        #region Armas distancia

        #region Rafagas(3)
        if (other.gameObject.CompareTag("Rafaga"))
            Daño(2);
        #endregion
        #region Lanzallamas
        if (other.gameObject.CompareTag("Lanzallamas"))
            StartCoroutine(DañoPorSegundo(1, 5, 1));
        #endregion
        #region Blaster
        if (other.gameObject.CompareTag("Blaster"))
            Daño(5);
        #endregion

        #endregion

        #region Armas utilidad

        #region DeployHealingPiece
        if (other.gameObject.CompareTag("DeployHeal"))
            StartCoroutine(CuracionActiva(1, 1f));
        #endregion
        #region Slow
        if (other.gameObject.CompareTag("Slower"))
            RalentizarActivado();
        #endregion
        #region Stun
        if (other.gameObject.CompareTag("Stun"))
            StartCoroutine(Inhabilitar(3));
        #endregion

        #endregion
    }
    private void OnTriggerExit(Collider other)
    {
        #region Deploy
        if (other.gameObject.CompareTag("DeployHeal"))
            StartCoroutine(CuracionActiva(1, 1f));
        #endregion
        #region Slow
        if (other.gameObject.CompareTag("Slower"))
            RalentizarDesactivado();
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

