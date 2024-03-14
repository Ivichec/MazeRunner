using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Personaje_Animator : MonoBehaviour
{
    #region Variables
    Animator anim;
    public static Personaje_Animator instancia;
    #endregion

    #region Funciones de Unity
    void Awake()
    {
	    anim = GetComponent<Animator>();
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Metodos Originales
    public void SetStand()
    {
        anim.SetBool("Quieto", true);
        anim.SetBool("Caminando", false);
        anim.SetBool("Corriendo", false);
    }
    public void SetCaminar()
    {
        anim.SetBool("Quieto", false);
        anim.SetBool("Caminando", true);
        anim.SetBool("Corriendo", false);
    } 
    public void SetCorrer()
    {
        anim.SetBool("Quieto", false);
        anim.SetBool("Caminando", false);
        anim.SetBool("Corriendo", true);
    }
    public void ActualizarMovimientoFloat(float _nuevoValor)
    {
        anim.SetFloat("movimientoFloat", _nuevoValor);
    }
    /*
    public void SetSaltar(bool _nuevoValor)
    {
        anim.SetBool("Saltar", _nuevoValor);
    }
    */
    #endregion
}
