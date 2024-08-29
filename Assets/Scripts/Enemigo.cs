using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int valor = 1; // Valor de la moneda a sumar al contador

    private Controlador controlador; // Referencia al script del contador

    private void Start()
    {
        controlador = GameObject.FindObjectOfType<Controlador>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            controlador.RestarVida(valor); 
            Debug.Log("Chocaste con un Enemigo");
        }
    }
}