using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla la obtención de créditos por parte del jugador.
/// </summary>
public class Credito : MonoBehaviour
{
    /// <summary>
    /// Delegado utilizado para eventos relacionados con la suma de créditos.
    /// </summary>
    /// <param name="credito">La cantidad de créditos que se sumará.</param>
    public delegate void SumaCredito(int credito);

    /// <summary>
    /// Evento que se activa cuando se suma crédito.
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
    /// Suma la cantidad de crédito al evento de suma de créditos.
    /// </summary>
    private void SumarCredito()
    {
        sumaCredito(cantidadCredito);
    }
}
