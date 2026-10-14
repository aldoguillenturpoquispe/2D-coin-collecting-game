using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //contador de monedas
    public TMP_Text monedasText;
    
    private int totalMonedas = 0;
    private int monedasColectadas = 0;
    // temporizador
    public TMP_Text contadorText;

    public float inicioTiempo = 10;
    private float tiempoQueda;

    private PlayerSoundController playerSoundController;
    private bool tiempoAgotado;


    private void Start()
    {
        GameObject[] monedas = GameObject.FindGameObjectsWithTag("Monedas");
        totalMonedas = monedas.Length;
        UpdateMonedasText();

        tiempoQueda = inicioTiempo;

        playerSoundController = Object.FindAnyObjectByType<PlayerSoundController>();
        if (playerSoundController == null)
            Debug.LogWarning("UIManager: NO encontró PlayerSoundController");
    }
    private void Update()
    {
        if (tiempoAgotado) return;
        tiempoQueda -= Time.deltaTime;
        tiempoQueda = Mathf.Max(tiempoQueda, 0f);
        contadorText.text = tiempoQueda.ToString("F1");
        if (tiempoQueda <= 0)
        {
            tiempoAgotado = true;
            Debug.Log("Tiempo agotado");

            float espera = 0f;
            if (playerSoundController != null)
            {
                playerSoundController.pararFondo();

                if (playerSoundController.sonidoFin != null)
                {
                    playerSoundController.playFin();
                    espera = playerSoundController.sonidoFin.length;
                    Debug.Log("Sonando fin, espera: " + espera);
                }else
                {
                    Debug.LogWarning("sonidoFin NO está asignado en el jugador");
                }
            }

            StartCoroutine(ReiniciarEscena(espera));
        }
    }
    public void ColectandoMonedas()
    {
        if (tiempoAgotado) return;
        monedasColectadas++;
        if (monedasColectadas == totalMonedas)
        {
            LoadNextLevel();
        }
        UpdateMonedasText(); 
    }
    void UpdateMonedasText()
    {
        monedasText.text = $"{monedasColectadas} / {totalMonedas}";
    }
    private IEnumerator ReiniciarEscena(float espera)
    {
        yield return new WaitForSecondsRealtime(espera);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}