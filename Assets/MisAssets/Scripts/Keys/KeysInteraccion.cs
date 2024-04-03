using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class KeysInteraccion : MonoBehaviour
{
    #region Variables
    public int contadorLlaves;
    public static KeysInteraccion instancia;
    public TextMeshProUGUI contador;
    public Transform llaveMapa;
    public Transform luzLLave;
    public Transform particulasLlave;
    #endregion


    #region Funciones de Unity
    public void Awake()
    {
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {
            contadorLlaves = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        contadorLlaves--;
        contador.text = contadorLlaves.ToString();
        llaveMapa.gameObject.SetActive(false);
        luzLLave.gameObject.SetActive(false);
        particulasLlave.gameObject.SetActive(false);
    }
    #endregion

    #region Metodos Originales

    #endregion
}
