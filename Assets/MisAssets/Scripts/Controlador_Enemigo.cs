using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Controlador_Enemigo;

/// <summary>
/// 
/// </summary>

public class Controlador_Enemigo : MonoBehaviour
{	
    #region Variables
    public NavMeshAgent agente;
    public Estados estado;
    public Transform objetivo;
    public static Controlador_Enemigo instancia;

    Vector3 posInicial;
    Quaternion rotInicial;
    public float contadorTiempo;

    Animator anim;

    private SphereCollider sphereCollider;
    private BoxCollider boxCollider;
    #endregion

    #region Funciones de Unity
    void Awake()
    {
        instancia = this;
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
                anim.SetBool("corriendo", false);
                break;
            // --------------------------------------------
            case Estados.PlayerDetectado:
                agente.isStopped = false;
                agente.stoppingDistance = 1.25f;
                contadorTiempo = 0f;
                Lacerador.instancia.Andar();
                break;
            // --------------------------------------------
            case Estados.PlayerPerdido:
                agente.stoppingDistance = 0f;
                contadorTiempo = 0f;
                anim.SetBool("corriendo", false);
                break;
            // --------------------------------------------
            case Estados.PlayerAtacado:
                Lacerador.instancia.Atacar();
                break;
            case Estados.Volviendo:
                agente.stoppingDistance = 0f;
                contadorTiempo = 0f;
                agente.SetDestination(posInicial);
                Lacerador.instancia.Andar();
                break;
           
                // --------------------------------------------
        }
    }
    #endregion
    public enum Estados
    {
        Quieto,
        PlayerDetectado,
        PlayerPerdido,
        PlayerAtacado,
        Volviendo
    }
}
