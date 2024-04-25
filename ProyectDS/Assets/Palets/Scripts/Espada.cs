using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el comportamiento de la espada del jugador.
/// </summary>
public class Espada : MonoBehaviour
{
    private BoxCollider2D colEspada;

    private void Awake()
    {
        colEspada = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Detecta colisiones con objetos y destruye al enemigo si colisiona con él.
    /// </summary>
    /// <param name="collision">El collider con el que colisiona esta espada.</param>
    private void OnTriggerEnter2D(Collider2D collision) //comportamiento
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }
}
