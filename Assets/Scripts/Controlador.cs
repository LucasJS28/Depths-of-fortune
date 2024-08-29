using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public Text contadorMonedasText;
    public Text contadorVidasText;
    public Text TextoPerdisteVida;
    public Text TextoPortal;
    public Text TextoMuerto;
    public Button BotonRevivir;
    public GameObject objetoTransicionEscena;
    public GameObject PersonajePrincipal;

    private int contadorMonedas = 0;
    public int TotalVidas = 3;
    public int totalMonedas = 7;
    private bool portalMostrado = false;

    public Text contadorText;
    public float tiempoInicial = 30f; // 2 minutos en segundos

    public AudioClip sonidoMuerte;
    public AudioClip sonidoMenosVida;
    private void Start()
    {
        ActualizarContadores();
        StartCoroutine(ComenzarCuentaRegresiva());
    }

    private IEnumerator ComenzarCuentaRegresiva()
    {
        float tiempoRestante = tiempoInicial;

        while (tiempoRestante > 0)
        {
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            contadorText.text = string.Format("{0}:{1:00}", minutos, segundos);
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
        }

        contadorText.text = "0:00";
        // Aquí puedes llamar a la función que simula la muerte del personaje
        PersonajeMuerto();
    }


    public void SumarMoneda(int cantidad)
    {
        contadorMonedas += cantidad;
        ActualizarContadores();
    }

    public void RestarVida(int cantidad)
    {
        TotalVidas -= cantidad;
        ActualizarContadores();

        if (TotalVidas <= 0)
        {
            TextoMuerto.gameObject.SetActive(true);
            BotonRevivir.gameObject.SetActive(true);
            PersonajeMuerto();
            AudioSource.PlayClipAtPoint(sonidoMuerte, transform.position);
            if (portalMostrado)
            {
                TextoPortal.gameObject.SetActive(false);
            }
        }
        else
        {
            StartCoroutine(AnimarTextoPerdidaVida());
            AudioSource.PlayClipAtPoint(sonidoMenosVida, transform.position);
        }

        Scene escenaActual = SceneManager.GetActiveScene();

        switch (escenaActual.name)
        {
            case "Cueva":
                PersonajePrincipal.transform.position =  new Vector2(-2.44f, -1.207f);
                break;
            case "Castillo":
                PersonajePrincipal.transform.position =  new Vector2(-5.78f, -4.15f);
                break;
            default:
                break;
        }
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ActualizarContadores()
    {
        contadorMonedasText.text = "Moneda " + contadorMonedas.ToString() + "/" + totalMonedas.ToString();
        contadorVidasText.text = "Vidas: " + TotalVidas.ToString();

        if (contadorMonedas >= totalMonedas && !portalMostrado)
        {
            objetoTransicionEscena.SetActive(true);
            StartCoroutine(AnimarTextoPortal());
            portalMostrado = true;
        }
    }

    private IEnumerator AnimarTextoPerdidaVida()
    {
        TextoPerdisteVida.gameObject.SetActive(true);

        for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime)
        {
            Color color = TextoPerdisteVida.color;
            color.a = alpha;
            TextoPerdisteVida.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            Color color = TextoPerdisteVida.color;
            color.a = alpha;
            TextoPerdisteVida.color = color;
            yield return null;
        }

        TextoPerdisteVida.gameObject.SetActive(false);
    }

    private IEnumerator AnimarTextoPortal()
    {
        TextoPortal.gameObject.SetActive(true);

        for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime)
        {
            Color color = TextoPortal.color;
            color.a = alpha;
            TextoPortal.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            Color color = TextoPortal.color;
            color.a = alpha;
            TextoPortal.color = color;
            yield return null;
        }

        TextoPortal.gameObject.SetActive(false);
    }

    private void PersonajeMuerto()
    {
        TextoMuerto.gameObject.SetActive(true);
        BotonRevivir.gameObject.SetActive(true);
        Destroy(PersonajePrincipal);

        if (portalMostrado)
        {
            TextoPortal.gameObject.SetActive(false);
        }
    }
}
