using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla la obtenci�n de cr�ditos por parte del jugador.
/// </summary>
public class Credito : MonoBehaviour
{
    /// <summary>
    /// Delegado utilizado para eventos relacionados con la suma de cr�ditos.
    /// </summary>
    /// <param name="credito">La cantidad de cr�ditos que se sumar�.</param>
    public delegate void SumaCredito(int credito);

    /// <summary>
    /// Evento que se activa cuando se suma cr�dito.
    /// </summary>
    public static event SumaCredito sumaCredito;

    [SerializeField] private int cantidadCredito;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaCredito != null)
            {
                SumarCredito();
                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Suma la cantidad de cr�dito al evento de suma de cr�ditos.
    /// </summary>
    private void SumarCredito()
    {
        sumaCredito(cantidadCredito);
    }
}
