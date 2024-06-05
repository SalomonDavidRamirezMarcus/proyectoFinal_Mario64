using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Estrella : MonoBehaviour
{
    public AudioClip winSound; // Sonido de recolección de la estrella
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            PlaySound(winSound); // Reproduce el sonido de recolección de la estrella
            Debug.Log("¡Has ganado el juego!");
            StartCoroutine(LoadVictoryScene()); // Iniciar la corrutina para cambiar de escena
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private IEnumerator LoadVictoryScene()
    {
        // Espera un segundo para permitir que el sonido se reproduzca
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Victory"); // Cambia a la escena de victoria (asegúrate de que el nombre de la escena sea correcto)
    }
}


