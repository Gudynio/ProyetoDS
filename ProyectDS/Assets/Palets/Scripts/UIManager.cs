using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalCreditos;
    [SerializeField] private TMP_Text textoCreditos;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    private void Start()
    {
        Credito.sumaCredito += SumarCreditos;
    }

    private void SumarCreditos(int credito)
    {
        totalCreditos += credito;
        textoCreditos.text = totalCreditos.ToString();
    }

    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }

}
