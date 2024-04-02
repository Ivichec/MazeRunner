using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager instancia;

    public DatosPlayer datosPlayer;

    private void Awake()
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

    #region 3) METODOS ORIGINALES
    #region 3.1) METODOS PARA LA VIDA
    public void SumarVida(float _incremento)
    {
        datosPlayer.vidaActual += _incremento;

        if (datosPlayer.vidaActual <= datosPlayer.vidaMax)
        {
            Debug.Log("Se incrementa la vida, pero no ha superado la vida maxima");
        }
        else
        {
            datosPlayer.vidaActual = datosPlayer.vidaMax;
            Debug.Log("Se incrementa la vida, y como supera la maxima... vida actual es vida max");
        }

        HudManager.instancia.Actualizar_BarraVida();
    }

    public void RestarVida (float _decremento)
    {
        datosPlayer.vidaActual -= _decremento;

        if (datosPlayer.vidaActual > 0f)
        {
            Debug.Log("Player recibe danno, pero tiene aun vida. SIGUE LUCHANDO..");
        }
        else
        {
            datosPlayer.vidaActual = 0f;
            Debug.Log("Player no tiene vida");
            GameManager.instancia.EstablecerEstado(EstadosJuego.FinJuego);
        }

        HudManager.instancia.Actualizar_BarraVida();
    }
    #endregion
    #endregion
}

[Serializable]
public class DatosPlayer
{
    public float vidaActual;
    public float vidaMax;
    public int llaves;
    // Player
    public Vector3 posicion;
    public Quaternion rotacion;

    // Camara
    public float rotCamH;
    public float rotCamV;

}

[Serializable]
public class EnemigoData
{
    public Vector3 posicion;
    public Quaternion rotacion;
}