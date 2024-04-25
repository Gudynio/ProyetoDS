using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoMovimiento : MonoBehaviour
{
    public Transform personaje;
    public Transform [] puntosRuta;
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
        this.transform.position = new Vector3(transform.position.x, transform.position.y,0);
        float distancia  = Vector3.Distance(personaje.position, this.transform.position);
        if (Vector3.Distance(this.transform.position, puntosRuta[indiceRuta].position) < 0.1f)
        {
            if (indiceRuta < puntosRuta.Length - 1)
            {
                indiceRuta++;
            }
            else if(indiceRuta == puntosRuta.Length - 1)
            {
                indiceRuta = 0;
            }
        }

        if (distancia < 3) {
            objetivoDetectado = true;
        }



        MovimientoEnemigo(objetivoDetectado);
        RotarEnemigo();
    }

    void MovimientoEnemigo (bool esDetectado)
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

    void RotarEnemigo()
    {
        if(this.transform.position.x > objetivo.position.x)
        {
            //transform.localScale = new Vector2(-1, 1);
            sprite.flipX = true;
        }
        else
        {
            //transform.localScale = new Vector2(1, 1);
            sprite.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            anim.SetTrigger("Ataca");
        }
    }
}
