using UnityEngine;

public class Star : MonoBehaviour
{
    public AudioClip winSound; // Sonido de recolecci�n de la estrella
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que tu jugador tenga el tag "Player"
        {
            PlaySound(winSound); // Reproduce el sonido de recolecci�n de la estrella
            // Aqu� puedes agregar la l�gica para ganar el juego
            Debug.Log("�Has ganado el juego!");
            // Puedes cargar una nueva escena, mostrar un mensaje de victoria, etc.
            // Ejemplo:
            // SceneManager.LoadScene("WinScene");
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
