using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del menú inicial del juego.
/// </summary>
public class MenuInicial : MonoBehaviour
{
    /// <summary>
    /// Carga la escena del juego principal al hacer clic en el botón "Jugar".
    /// </summary>
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// Sale de la aplicación al hacer clic en el botón "Salir".
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
}
