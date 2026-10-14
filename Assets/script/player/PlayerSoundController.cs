using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoSalto;
    public AudioClip sonidoFin;
    public AudioClip sonidoFondo;
    public AudioClip sonidoMoneda;
    public AudioClip sonidoCaida;
    void Start()
    {
        playFondo();
    }

    public void playSalto()
    {
        audioSource.PlayOneShot(sonidoSalto);
    }
    public void playFin()
    {
        audioSource.PlayOneShot(sonidoFin);
    }
    public void playMoneda()
    {
        audioSource.PlayOneShot(sonidoMoneda);
    }
    public void playCaida()
    {
        audioSource.PlayOneShot(sonidoCaida);
    }
    public void playFondo()
    {
        audioSource.PlayOneShot(sonidoFondo);
    }

    public void pararFondo()
    {
        audioSource.Stop();
    }
    
}