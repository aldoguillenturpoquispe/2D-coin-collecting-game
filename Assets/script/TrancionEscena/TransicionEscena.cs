using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrancionEscena : MonoBehaviour 
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 1. PARA EL BOTÓN JUGAR (MENÚ)
    public void BotonJugar()
    {
        StartCoroutine(CambiarEscena(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // 2. NUEVO: PARA EL BOTÓN NIVELES (MENÚ)
    public void BotonNiveles()
    {
        // "seleccionNiveles" debe ser el nombre exacto de tu escena de niveles
        StartCoroutine(CambiarEscenaPorNombre("seleccionNiveles")); 
    }

    // 3. PARA PASAR DE NIVEL (JUEGO)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(CambiarEscena(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    // Corrutina para cambiar por número de lista (Build Index)
    IEnumerator CambiarEscena(int indiceSiguienteEscena)
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        
        if (indiceSiguienteEscena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indiceSiguienteEscena);
        }
        else
        {
            Debug.LogWarning("¡Ya no hay más niveles configurados!");
        }
    }

    // Corrutina para cambiar por el nombre exacto de la escena
    IEnumerator CambiarEscenaPorNombre(string nombreEscena)
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(nombreEscena);
    }
}
