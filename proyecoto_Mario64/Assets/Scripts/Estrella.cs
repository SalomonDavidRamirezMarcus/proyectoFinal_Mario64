using UnityEngine;

public class Estrella: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que tu jugador tenga el tag "Player"
        {
            // Aqu� puedes agregar la l�gica para ganar el juego
            Debug.Log("�Has ganado el juego!");
            // Puedes cargar una nueva escena, mostrar un mensaje de victoria, etc.
            // Ejemplo:
            // SceneManager.LoadScene("WinScene");
        }
    }
}