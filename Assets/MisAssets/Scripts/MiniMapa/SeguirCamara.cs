using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/// <summary>
/// 
/// </summary>

public class SeguirCamara : MonoBehaviour
{
    #region Variables
    public Transform player;
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
    private void LateUpdate()
    {
        Vector3 posicion = player.position;
        posicion.y = transform.position.y;
        transform.position = posicion;
    }
    #endregion

    #region Metodos Originales
    
    #endregion
}
