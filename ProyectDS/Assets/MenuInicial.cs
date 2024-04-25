using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del men� inicial del juego.
/// </summary>
public class MenuInicial : MonoBehaviour
{
    /// <summary>
    /// Carga la escena del juego principal al hacer clic en el bot�n "Jugar".
    /// </summary>
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// Sale de la aplicaci�n al hacer clic en el bot�n "Salir".
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
}
