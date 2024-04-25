using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credito : MonoBehaviour
{
    public delegate void SumaCredito(int credito);
    public static event SumaCredito sumaCredito;

    [SerializeField] private int cantidadCredito;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(sumaCredito != null)
            {
                sumarCredito();
                Destroy(this.gameObject);
                
            }

        }
    }

    private void sumarCredito()
    {
        sumaCredito(cantidadCredito);
    }
}
