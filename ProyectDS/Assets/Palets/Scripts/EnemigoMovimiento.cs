using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controla el movimiento y comportamiento de un enemigo en el juego.
/// </summary>
public class EnemigoMovimiento : MonoBehaviour
{
    public Transform personaje;
    public Transform[] puntosRuta;
    private int indiceRuta;
    public NavMeshAgent agente;
    private bool objetivoDetectado;
    private SpriteRenderer sprite;
    private Transform objetivo;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agente = GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    private void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);
        if (Vector3.Distance(this.transform.position, puntosRuta[indiceRuta].position) < 0.1f)
        {
            if (indiceRuta < puntosRuta.Length - 1)
            {
                indiceRuta++;
            }
            else if (indiceRuta == puntosRuta.Length - 1)
            {
                indiceRuta = 0;
            }
        }

        if (distancia < 3)
        {
            objetivoDetectado = true;
        }

        MovimientoEnemigo(objetivoDetectado);
        RotarEnemigo();
    }

    /// <summary>
    /// Controla el movimiento del enemigo hacia el objetivo detectado o los puntos de la ruta.
    /// </summary>
    /// <param name="esDetectado">Indica si el enemigo ha detectado al jugador.</param>
    void MovimientoEnemigo(bool esDetectado)
    {
        if (esDetectado)
        {
            agente.SetDestination(personaje.position);
            objetivo = personaje;
        }
        else
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            objetivo = puntosRuta[indiceRuta];
        }
    }

    /// <summary>
    /// Rota al enemigo para que mire hacia su objetivo.
    /// </summary>
    void RotarEnemigo()
    {
        if (this.transform.position.x > objetivo.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Ataca");
        }
    }
}
