using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class activadorAnimacionPuertaLadoPortal : MonoBehaviour
{	
    #region Variables
    Animator animator;
    #endregion
    
    #region Funciones de Unity
    void Awake()
    {
        animator = GetComponent<Animator>();
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
    public void abrirPuerta()
    {
        animator.SetBool("llaveCojida", true);
    }
    #endregion
}
