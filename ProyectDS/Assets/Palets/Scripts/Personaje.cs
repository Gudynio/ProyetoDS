using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje: MonoBehaviour
{
    [SerializeField] private float velocidad;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
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
            spritePersonaje.flipX = false;
        }
        else if (horizontal < 0)
        {
            spritePersonaje.flipX = true;
        }

    }
}
