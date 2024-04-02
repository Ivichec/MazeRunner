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
    public GameObject objeto;
    public int contadorLlaves;
    public static KeysInteraccion instancia;
    public TextMeshProUGUI contador;
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
    }
    #endregion

    #region Metodos Originales

    #endregion
}
