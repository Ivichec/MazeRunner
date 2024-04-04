using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 
/// </summary>

public class Controlador_Enemigo : MonoBehaviour
{	
    #region Variables
    public NavMeshAgent agente;
    public Estados estado;
    public Transform objetivo;

    Vector3 posInicial;
    Quaternion rotInicial;
    public float contadorTiempo;

    Animator anim;

    private SphereCollider sphereCollider;
    private BoxCollider boxCollider;

    Lacerador scriptAnim;
    #endregion

    #region Funciones de Unity
    void Awake()
    {
        scriptAnim = transform.GetChild(0).GetComponent<Lacerador>();

        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        objetivo = GameObject.FindWithTag("Player").transform;
        posInicial = transform.position;
        rotInicial = transform.rotation;
        sphereCollider = GetComponent<SphereCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == Estados.PlayerDetectado) agente.SetDestination(objetivo.position);
        if (estado == Estados.Volviendo)
        {
            //terminar en casa, para que coja que esta en la posicion con unos metros de diferencia.
            if ((agente.transform.position - posInicial).magnitude < 2f)
            {
                EstablecerEstado(Estados.Quieto);
            }
        }
    }
    #endregion
    /// <summary>
    /// Metodo de inteligencia del enemigo, 
    /// </summary>

    private void OnTriggerExit(Collider other)
    {
        EstablecerEstado(Estados.Volviendo);
    }
    #region Metodos Originales
    public void EstablecerEstado(Estados _nuevoEstado)
    {
        estado = _nuevoEstado;
        Debug.Log("Estado enemigo: <color=yellow> " + estado.ToString() + " </color>");

        switch (estado)
        {
            // --------------------------------------------
            case Estados.Quieto:
                agente.isStopped = true;
                agente.stoppingDistance = 1.25f;
                transform.rotation = rotInicial;
                scriptAnim.Quieto();
                break;
            // --------------------------------------------
            case Estados.PlayerDetectado:
                agente.isStopped = false;
                agente.stoppingDistance = 1.25f;
                contadorTiempo = 0f;
                scriptAnim.Andar();
                break;
            // --------------------------------------------
            case Estados.PlayerPerdido:
                agente.stoppingDistance = 0f;
                contadorTiempo = 0f;
                scriptAnim.Andar();
                break;
            // --------------------------------------------
            case Estados.PlayerAtacado:
                agente.isStopped = false;
                agente.stoppingDistance = 1.25f;
                contadorTiempo = 0f;
                scriptAnim.Atacar();
                break;
            case Estados.Volviendo:
                agente.stoppingDistance = 0f;
                contadorTiempo = 0f;
                agente.SetDestination(posInicial);
                scriptAnim.Andar();
                break;
           
                // --------------------------------------------
        }
    }
    #endregion

}

public enum Estados
{
    Quieto,
    PlayerDetectado,
    PlayerPerdido,
    PlayerAtacado,
    Volviendo
}
