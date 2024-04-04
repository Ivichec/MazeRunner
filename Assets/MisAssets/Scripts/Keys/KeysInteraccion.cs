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

    public Transform puerta;
    public Transform personaje;
    #endregion


    #region Funciones de Unity
    public void Awake()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        Controlador_Personaje _script = personaje.GetComponent<Controlador_Personaje>();
        contadorLlaves = _script.contadorActual();
        this.gameObject.SetActive(false);
        contadorLlaves--;
        _script.actualizarContador();
        contador.text = contadorLlaves.ToString();
        llaveMapa.gameObject.SetActive(false);
        luzLLave.gameObject.SetActive(false);
        particulasLlave.gameObject.SetActive(false);

        Debug.Log(LayerMask.LayerToName(this.gameObject.layer));
        if (LayerMask.LayerToName(this.gameObject.layer) == "llaveAnimacion")
        {
            activadorAnimacionPuertaLadoPortal _script1 = puerta.GetComponent<activadorAnimacionPuertaLadoPortal>();
            Debug.Log("ENtraaaaaaa");
            _script1.abrirPuerta();
        }

    }
    #endregion

    #region Metodos Originales

    #endregion
}
