using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // ==========================================
    // MENÚ PRINCIPAL Y NAVEGACIÓN GENERAL
    // ==========================================

    // Botón JUGAR: Inicia directo en el Nivel 1
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    // Botón NIVELES: Abre la pantalla de selección de niveles
    public void Niveles()
    {
        SceneManager.LoadScene("seleccionNiveles");
    }

    // Botón VOLVER AL MENÚ: Regresa a la pantalla de título principal (desde selección de niveles)
    public void VolverMenu()
    {
        SceneManager.LoadScene("menu");
    }

    // Botón SALIR DEL JUEGO: Cierra la aplicación por completo
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // ==========================================
    // SELECCIÓN DE NIVELES (Carga de los 3 niveles)
    // ==========================================

    // Carga el Nivel 1
    public void AbrirNivel1()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    // Carga el Nivel 2
    public void AbrirNivel2()
    {
        SceneManager.LoadScene("Nivel 2");
    }

    // Carga el Nivel 3
    public void AbrirNivel3()
    {
        SceneManager.LoadScene("Nivel 3");
    }

    // ==========================================
    // NUEVA FUNCIÓN DIRECTA PARA TU ENGRANAJE / MENÚ
    // ==========================================

    // Botón SALIR A MENÚ: Conéctalo a tu engranaje o botón de escape para volver directo al menú principal
    public void SalirAMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo del juego se reanude para que el menú principal funcione bien
        SceneManager.LoadScene("menu"); // Carga tu escena llamada "menu"
    }
}
