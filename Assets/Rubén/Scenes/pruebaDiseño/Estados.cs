using System.Collections;
using System.Collections.Generic;
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
    public CharacterController characterController;


    #endregion
    private void Start() {
        velocidad = velocidadNormal;
    }
    private void Update()
    {
        #region  Movimiento AWSD
        float horizontalmove = Input.GetAxis("Horizontal");
        float verticalmove = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * verticalmove + transform.right * horizontalmove;
        characterController.Move(velocidad * Time.deltaTime * move);
        #endregion  


    }
    

// LISTA DE ESTADOS
// I N H A B I L I T A R
// StartCoroutine(Inhabilitar(x)) ---------------------- se inhabilita durante x segundos
#region Inhabilitar
    IEnumerator Inhabilitar(float o){ 
        velocidad = 0;
        yield return new WaitForSeconds(o);
        velocidad = 6;
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
// StartDaño(DañoActivo(x,y)) -------------------------- recibe x puntos de daño cada y segundos(el efecto termina cuando se vuelve a llamar la coroutina)
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
// Curacion() ------------------------------------------ recibe x puntos de curacion instantaneamente
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