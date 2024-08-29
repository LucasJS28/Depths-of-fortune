using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para el cambio de escenas

public class TeleportFinal : MonoBehaviour
{
    private string nombreEscenaDestino; // Variable para almacenar el nombre de la escena destino
    private GameObject PersonajePrincipal;

    private void Start()
    {
        PersonajePrincipal = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Scene escenaActual = SceneManager.GetActiveScene();

            switch (escenaActual.name)
            {
                case "Cueva":
                    nombreEscenaDestino="Castillo";
                    SceneManager.LoadScene(nombreEscenaDestino);
                    PersonajePrincipal.transform.position =  new Vector2(-5.78f, -4.15f);
                    break;
                case "Castillo":
                    nombreEscenaDestino="Prueba";
                    SceneManager.LoadScene(nombreEscenaDestino);
                    PersonajePrincipal.transform.position =  new Vector2(-5.78f, -4.15f);
                    break;
                default:
                    break;
            }
        }
    }
}
