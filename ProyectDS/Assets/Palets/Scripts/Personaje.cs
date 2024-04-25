using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Personaje: MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;

    private int vidaPersonaje = 3;

    [SerializeField] UIManager uiManager;


    private float posColX = 1;
    private float posColY = 0;
    

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Atacar");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CausarHerida();
        }
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(horizontal, vertical) * velocidad;
        anim.SetFloat("Camina", Mathf.Abs(rig.velocity.magnitude));

        if (horizontal > 0)
        {
            colEspada.offset = new Vector2(posColX, posColY);
            spritePersonaje.flipX = false;

        }
        else if (horizontal < 0)
        {
            colEspada.offset = new Vector2(-posColX, posColY);
            spritePersonaje.flipX = true;
        }

    }

    public void CausarHerida()
    {
        if (vidaPersonaje > 0)
        {
            vidaPersonaje--;
            uiManager.RestaCorazones(vidaPersonaje);
            if (vidaPersonaje == 0)
            {
                anim.SetTrigger("Muere");
                Invoke(nameof(Morir),1f);
                Debug.Log("Muerto");

            }
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
