using UnityEngine;

public class monedas : MonoBehaviour
{
    private UIManager uiManager;

    private void Awake()
    {
        // Buscamos el UIManager al despertar la moneda, no al chocar. 
        // Esto evita retrasos y fallos en el momento de la recolección.
        uiManager = Object.FindAnyObjectByType<UIManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 1. Primero avisamos al UI
            if (uiManager != null)
            {
                uiManager.ColectandoMonedas();
            }

            // 2. Luego ordenamos reproducir el sonido en el jugador
            PlayerSoundController sonido = collision.GetComponent<PlayerSoundController>();
            if (sonido != null)
            {
                sonido.playMoneda();
            }
            
            // 3. Al final de todo, destruimos la moneda
            Destroy(gameObject);
        }
    }
}
