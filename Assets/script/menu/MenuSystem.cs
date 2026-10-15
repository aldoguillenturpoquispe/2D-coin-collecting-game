
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Jugar desde el menú principal
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    // Abrir la escena de selección de niveles
    public void Niveles()
    {
        SceneManager.LoadScene("seleccionNiveles");
    }

    // Salir del juego
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Abrir el nivel 1
    public void AbrirNivel1()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    // Abrir el nivel 2
    public void AbrirNivel2()
    {
        SceneManager.LoadScene("Nivel 2");
    }

    // Abrir el nivel 3
    public void AbrirNivel3()
    {
        SceneManager.LoadScene("Nivel 3");
    }

    // Volver al menú principal
    public void VolverMenu()
    {
        SceneManager.LoadScene("menu");
    }

    // Botón SALIR de la selección de niveles:
    // vuelve al menú principal
    public void SalirNiveles()
    {
        SceneManager.LoadScene("menu");
    }
}
