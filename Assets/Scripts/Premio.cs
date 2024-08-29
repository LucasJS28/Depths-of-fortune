using UnityEngine;

public class Premio : MonoBehaviour
{
    public int valor = 1; // Valor de la moneda a sumar al contador

    private Controlador controlador; // Referencia al script del contador

    public AudioClip collisionSound;

    private void Start()
    {
        controlador = GameObject.FindObjectOfType<Controlador>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador ha tocado la moneda
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
            controlador.SumarMoneda(valor); // Suma la moneda al contador
            Destroy(gameObject); // Destruye la moneda
            Debug.Log("Recolectaste una Moneda");
        }
    }
}