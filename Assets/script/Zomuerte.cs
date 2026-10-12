using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zomuerte : MonoBehaviour
{
    private bool activado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !activado)
        {
            activado = true;
            StartCoroutine(Morir(collision));
        }
    }

    private IEnumerator Morir(Collider2D jugador)
    {
        // Congelar al personaje
        Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        PlayerControl control = jugador.GetComponent<PlayerControl>();
        if (control != null)
            control.enabled = false;

        // Sonido de caída
        float espera = 0f;
        PlayerSoundController sonido = jugador.GetComponent<PlayerSoundController>();
        if (sonido != null)
        {
            sonido.pararFondo();

            if (sonido.sonidoCaida != null)
            {
                sonido.playCaida();
                espera = sonido.sonidoCaida.length;
            }
        }

        // Esperar a que termine el sonido y reiniciar
        yield return new WaitForSecondsRealtime(espera);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}