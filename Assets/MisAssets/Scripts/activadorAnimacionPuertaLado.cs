using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class activadorAnimacionPuertaLado : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entra");
        animator.SetBool("lado", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("sale");
        animator.SetBool("lado", false) ;
    }
    #endregion

    #region Metodos Originales

    #endregion
}