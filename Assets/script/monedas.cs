using UnityEngine;

public class monedas : MonoBehaviour
{
    private UIManager uiManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSoundController sonido = collision.GetComponent<PlayerSoundController>();
            if (sonido != null)
                sonido.playMoneda();

            uiManager = Object.FindAnyObjectByType<UIManager>();
            
            if (uiManager != null)
            {
                uiManager.ColectandoMonedas();
            }
            
            Destroy(gameObject);
        }
    }
}