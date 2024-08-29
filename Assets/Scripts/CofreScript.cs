using UnityEngine;

public class CofreScript : MonoBehaviour
{
    public GameObject moneda; // Referencia al GameObject de la moneda
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el cofre chocó con algo
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hacer visible la moneda
            if (moneda != null)
            {
                moneda.SetActive(true); // Activar el GameObject de la moneda
            }

            animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Abierto", true);
                DestroyCofreAfterDelay(gameObject, 2f);
                Debug.Log("Abriste un Cofre");
            }
        }
    }

    private void DestroyCofreAfterDelay(GameObject cofreObject, float delay)
    {
        Destroy(cofreObject, delay); // Destruye el objeto del cofre después del retraso especificado
        // Invocar método para activar la moneda después de 3 segundos
        Invoke("ActivateMoneda", 3f);
    }

    private void ActivateMoneda()
    {
        if (moneda != null)
        {
            moneda.SetActive(true); // Activar el GameObject de la moneda después de 3 segundos
        }
    }
}
