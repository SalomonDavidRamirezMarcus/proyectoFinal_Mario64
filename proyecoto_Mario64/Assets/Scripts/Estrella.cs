using UnityEngine;

public class Star : MonoBehaviour
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
            // Aquí puedes agregar la lógica para ganar el juego
            Debug.Log("¡Has ganado el juego!");
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
