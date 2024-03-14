using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using static Controlador_Enemigo;
using static Personaje;

/// <summary>
/// 
/// </summary>

public class Personaje : MonoBehaviour
{
    #region Variables
    
    public Movimiento movimiento;

    Vector2 ejesVirtuales;
    Vector3 dirMovimiento;

    public CinemachineVirtualCamera cv_apunta;
    Transform cam;
    Rigidbody rb;
    public float velocidad;
    public float animMovimientoGradual;
    private SphereCollider sphereCollider;
    private BoxCollider boxCollider;
    public Transform enemigo;
    #endregion

    #region Funciones de Unity
    void Awake()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        sphereCollider = enemigo.GetComponent<SphereCollider>();
        boxCollider = enemigo.GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        EstablecerMovimiento(movimiento);

    }

    // Update is called once per frame
    void Update()
    {
        EstablecerEjesVirtuales();
        EstablecerDirMovimiento();
        ActualizarEstadoMovimiento();
        Refrescar_Animator();
        Rotacion();
        if (Input.GetMouseButton(1)) cv_apunta.m_Priority = 2;
        else cv_apunta.m_Priority = 0;
        if (ejesVirtuales.magnitude != 0f)
        {
            Debug.DrawRay(transform.position, dirMovimiento, Color.black);
            // ROTACION GRADUAL
            Quaternion rotFinal = Quaternion.LookRotation(dirMovimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotFinal, 3f * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = new Ray(transform.position,new Vector3(0,-1,0));
            RaycastHit hit;

            bool resultado = Physics.Raycast(ray, out hit, 0.5f);

            if (resultado)
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Saltar();
            }
            
        } //Personaje_Animator.instancia.SetSaltar(true);
        if (Input.GetKeyDown(KeyCode.LeftShift)) EstablecerDirMovimientoCorriendo();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift)) EstablecerDirMovimientoCorriendo();
        else velocidad = 2f; rb.MovePosition(rb.position + dirMovimiento * velocidad * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemigo"))
        {
            if (other == boxCollider)
            {
                Controlador_Enemigo.instancia.EstablecerEstado(Estados.PlayerAtacado);
            }
            else
            {   
                Controlador_Enemigo.instancia.EstablecerEstado(Estados.PlayerDetectado);
                Controlador_Enemigo.instancia.contadorTiempo = 0f;
            }
        }
    }
    #endregion

    #region Metodos Originales
    void EstablecerMovimiento(Movimiento nuevoEstado)
    {
        movimiento = nuevoEstado;

        switch (movimiento)
        {
            case Movimiento.Quieto:
                Personaje_Animator.instancia.SetStand();
                break;
            case Movimiento.Caminar:
                Personaje_Animator.instancia.SetCaminar();  
                break;
            case Movimiento.Corriendo:
                Personaje_Animator.instancia.SetCorrer();
                break;
        }
    }
    void Rotacion()
    {
        if (ejesVirtuales.x != 0f || ejesVirtuales.y != 0f)
        {
            // Rotacion
            Quaternion _rotActual = transform.rotation;
            Quaternion _rotFinal = Quaternion.LookRotation(dirMovimiento);
            Quaternion _rotGradual = Quaternion.RotateTowards(_rotActual, _rotFinal, 720f * Time.deltaTime);

            transform.rotation = _rotGradual;
        }
        if (Input.GetMouseButton(1))
        {
            transform.LookAt(transform.position + dirMovimiento);
        }
        else if (ejesVirtuales.magnitude != 0f)
        {
            Quaternion rotFinal = Quaternion.LookRotation(dirMovimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotFinal, 1f * Time.deltaTime);
        }

    }
    void EstablecerEjesVirtuales()
    {
        ejesVirtuales.x = Input.GetAxisRaw("Horizontal");
        ejesVirtuales.y = Input.GetAxisRaw("Vertical");
    }
    void EstablecerDirMovimiento()
    {
        dirMovimiento = cam.right * ejesVirtuales.x + cam.forward * ejesVirtuales.y;
        dirMovimiento.y = 0f;
        dirMovimiento.Normalize();
    }
    void EstablecerDirMovimientoCorriendo()
    {
        velocidad = 3f;
        rb.MovePosition(rb.position + dirMovimiento * velocidad * Time.fixedDeltaTime);
    }

    void Saltar()
    {
        rb.velocity = Vector3.zero;

        float _fuerzaSalto = Mathf.Sqrt(1.5f * -1.5f * Physics.gravity.y);
        rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.VelocityChange);
    }
    void ActualizarEstadoMovimiento()
    {
        if (ejesVirtuales.magnitude == 0f && movimiento != Movimiento.Quieto)
        {
            EstablecerMovimiento(Movimiento.Quieto);
        }
        else if (ejesVirtuales.magnitude != 0f && movimiento != Movimiento.Caminar && velocidad != 3f)
        {
            EstablecerMovimiento(Movimiento.Caminar);
        }
        else if(ejesVirtuales.magnitude != 0f && movimiento != Movimiento.Corriendo && Input.GetKey(KeyCode.LeftShift))
        {
            EstablecerMovimiento(Movimiento.Corriendo);
        }
    }
    void Refrescar_Animator()
    {

        if (movimiento == Movimiento.Quieto)
        {
            animMovimientoGradual = Mathf.MoveTowards(animMovimientoGradual, 0f, 10f * Time.deltaTime);
        }

        if (movimiento == Movimiento.Caminar)
        {
            animMovimientoGradual = Mathf.MoveTowards(animMovimientoGradual, 1f, 10f * Time.deltaTime);
        }

        if (movimiento == Movimiento.Corriendo)
        {
            animMovimientoGradual = Mathf.MoveTowards(animMovimientoGradual, 2f, 10f * Time.deltaTime);
        }

        Personaje_Animator.instancia.ActualizarMovimientoFloat(animMovimientoGradual);
    }
    #endregion
    public enum Movimiento
    {
        Quieto,
        Caminar,
        Corriendo
    }
}
