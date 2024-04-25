using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el comportamiento del ataque de un enemigo.
/// </summary>
public class AtaqueEnemigo : MonoBehaviour
{
    /// <summary>
    /// Detecta colisiones con objetos y activa el ataque si el objeto colisionado es el jugador.
    /// </summary>
    /// <param name="collision">El collider con el que colisiona este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener el componente Personaje del objeto colisionado
            Personaje personaje = collision.gameObject.GetComponent<Personaje>();
            // Llamar al método CausarHerida() del componente Personaje
            personaje.CausarHerida();
        }
    }
}
