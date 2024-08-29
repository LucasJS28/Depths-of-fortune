using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] string escenaInicial = null;
    private string nombreEscenaDestino; // Variable para almacenar el nombre de la escena destino

    public void Iniciar()
    {
        print("Botón Iniciar");
        SceneManager.LoadScene(escenaInicial);
    }

    public void Prueba()
    {
        print("Botón Iniciar");
        nombreEscenaDestino="Prueba";
                    SceneManager.LoadScene(nombreEscenaDestino);
    }

    public void Salir()
    {
        print("Botón Salir");
        Application.Quit();
    }
}
