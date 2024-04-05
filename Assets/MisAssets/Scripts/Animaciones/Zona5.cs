using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Zona5 : MonoBehaviour
{
    #region Variables
    public Transform plano15;
    public Transform plano8;
    #endregion
    
    #region Funciones de Unity
    void Awake()
    {
	
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
    public void animacionTerminada()
    {
        plano15.gameObject.SetActive(true);
        plano8.gameObject.SetActive(false);
    }
    #endregion
}
