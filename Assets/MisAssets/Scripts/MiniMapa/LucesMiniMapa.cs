using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class LucesMiniMapa : MonoBehaviour
{
    #region Variables
    public Transform mapaluces;
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        if (other.CompareTag("Mapa"))
        {
            Debug.Log("Entra1");
            int mapaIndex = other.transform.GetSiblingIndex();
            mapaluces.GetChild(mapaIndex).GetChild(0).gameObject.SetActive(true);
        }
    }
    #endregion

    #region Metodos Originales

    #endregion
}
