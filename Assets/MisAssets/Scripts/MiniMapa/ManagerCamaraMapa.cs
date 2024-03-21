using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class ManagerCamaraMapa : MonoBehaviour
{	
    #region Variables
    public GameObject camaraMapaEntero;
    public GameObject camaraMapaActual;
    public RawImage mapa;
    #endregion
    
    #region Funciones de Unity
    void Awake()
    {
        camaraMapaEntero.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            camaraMapaActual.SetActive(false);
            camaraMapaEntero.SetActive(true);
            int width = 1024;
            int height = 1024;
            mapa.rectTransform.anchoredPosition = new Vector3(420f,-20f,0f);
            mapa.rectTransform.sizeDelta = new Vector2(width, height);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None; // El cursor se desbloquea
            Cursor.visible = true; // El cursor se muestra
        }
        else
        {
            camaraMapaActual.SetActive(true);
            camaraMapaEntero.SetActive(false);
            int width = 256;
            int height = 256;
            mapa.rectTransform.anchoredPosition = new Vector3(20f, -20f, 0f);
            mapa.rectTransform.sizeDelta = new Vector2(width, height);
            GameManager.instancia.EstablecerEstado(EstadosJuego.Jugando);
        }

    }
    #endregion

    #region Metodos Originales
    
    #endregion
}
