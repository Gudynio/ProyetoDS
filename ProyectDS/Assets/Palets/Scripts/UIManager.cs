using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla la interfaz de usuario (UI) del juego, incluyendo el manejo de créditos y corazones.
/// </summary>
public class UIManager : MonoBehaviour
{
    private int totalCreditos;
    [SerializeField] private TMP_Text textoCreditos;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    private void Start()
    {
        // Suscribe el método SumarCreditos al evento sumaCredito de la clase Credito
        Credito.sumaCredito += SumarCreditos;
    }

    /// <summary>
    /// Suma créditos al total y actualiza el texto de créditos en la UI.
    /// </summary>
    /// <param name="credito">La cantidad de créditos a sumar.</param>
    private void SumarCreditos(int credito) //
    {
        totalCreditos += credito;
        textoCreditos.text = totalCreditos.ToString();
        // Si el total de créditos supera cierta cantidad, carga la escena "GameOver"
        if (totalCreditos > 442)
        {
            totalCreditos = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    /// Desactiva un corazón en la UI en la posición indicada.
    /// </summary>
    /// <param name="indice">La posición del corazón en la lista de corazones.</param>
    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }

}
