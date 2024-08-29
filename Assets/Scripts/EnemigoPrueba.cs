using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemigoPrueba : MonoBehaviour
{
    public int valor = 1; // Valor de la moneda a sumar al contador
    public Text textoFinal;
    public GameObject PersonajePrincipal;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textoFinal.gameObject.SetActive(true);
            Destroy(PersonajePrincipal);
            Debug.Log("Chocaste con un Enemigo");
        }
    }
}
