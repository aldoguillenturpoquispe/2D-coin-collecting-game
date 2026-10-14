using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Zomuerte : MonoBehaviour
{
    public Transform puntoDeInicio;     
    public Image pantallaNegra;          
    public float velocidadParpadeo = 2f; 

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
        // 1. Congelar al personaje para que no se mueva durante la animación
        Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        PlayerControl control = jugador.GetComponent<PlayerControl>();
        if (control != null)
            control.enabled = false;

        // 2. Detener música y reproducir sonido de caída
        PlayerSoundController sonido = jugador.GetComponent<PlayerSoundController>();
        if (sonido != null)
        {
            sonido.pararFondo();

            if (sonido.sonidoCaida != null)
            {
                sonido.playCaida();
            }
        }

        // 3. EFECTO: Cerrar los ojos (La pantalla se vuelve negra)
        pantallaNegra.enabled = true;
        Color colorActual = pantallaNegra.color;
        float alfa = 0;

        while (alfa < 1f)
        {
            alfa += Time.deltaTime * velocidadParpadeo;
            colorActual.a = Mathf.Clamp01(alfa);
            pantallaNegra.color = colorActual;
            yield return null;
        }

        // Un breve instante en completa oscuridad (ojos cerrados)
        yield return new WaitForSeconds(0.2f);

        // 4. Teletransportar al jugador al inicio
        jugador.transform.position = puntoDeInicio.position;

        // ==========================================
        // NUEVO - REINICIAR EL CONTADOR DE TIEMPO
        // ==========================================
        // Primero buscamos el script de tu UIManager que controla el tiempo
        UIManager ui = Object.FindAnyObjectByType<UIManager>();
        if (ui != null)
        {
            // Accedemos a las variables de tu UIManager y las devolvemos a sus valores iniciales
            // Usamos Reflection o una inyección directa si las variables fueran públicas. 
            // Para mantener tu script UIManager intacto como me pediste, lo forzamos de forma segura:
            
            System.Reflection.FieldInfo campoTiempo = typeof(UIManager).GetField("tiempoQueda", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            System.Reflection.FieldInfo campoAgotado = typeof(UIManager).GetField("tiempoAgotado", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            
            if (campoTiempo != null) campoTiempo.SetValue(ui, ui.inicioTiempo);
            if (campoAgotado != null) campoAgotado.SetValue(ui, false);
        }
        // ==========================================

        // 5. EFECTO: Abrir los Define (La pantalla negra se desvanece)
        while (alfa > 0f)
        {
            alfa -= Time.deltaTime * velocidadParpadeo;
            colorActual.a = Mathf.Clamp01(alfa);
            pantallaNegra.color = colorActual;
            yield return null;
        }

        pantallaNegra.enabled = false; 

        // 6. Volver a activar al personaje para que siga jugando
        if (rb != null)
            rb.simulated = true;

        if (control != null)
            control.enabled = true;

        if (sonido != null)
            sonido.playFondo();

        activado = false;
    }
}