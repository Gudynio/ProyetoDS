using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla la interfaz de usuario (UI) del juego, incluyendo el manejo de cr�ditos y corazones.
/// </summary>
public class UIManager : MonoBehaviour
{
    private int totalCreditos;
    [SerializeField] private TMP_Text textoCreditos;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    private void Start()
    {
        // Suscribe el m�todo SumarCreditos al evento sumaCredito de la clase Credito
        Credito.sumaCredito += SumarCreditos;
    }

    /// <summary>
    /// Suma cr�ditos al total y actualiza el texto de cr�ditos en la UI.
    /// </summary>
    /// <param name="credito">La cantidad de cr�ditos a sumar.</param>
    private void SumarCreditos(int credito) //
    {
        totalCreditos += credito;
        textoCreditos.text = totalCreditos.ToString();
        // Si el total de cr�ditos supera cierta cantidad, carga la escena "GameOver"
        if (totalCreditos > 442)
        {
            totalCreditos = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    /// Desactiva un coraz�n en la UI en la posici�n indicada.
    /// </summary>
    /// <param name="indice">La posici�n del coraz�n en la lista de corazones.</param>
    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }

}
