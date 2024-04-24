using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int totalCreditos;
    [SerializeField] private TMP_Text textoCreditos;

    private void Start()
    {
        Credito.sumaCredito += SumarCreditos;
    }

    private void SumarCreditos(int credito)
    {
        totalCreditos += credito;
        textoCreditos.text = totalCreditos.ToString();
    }

}
