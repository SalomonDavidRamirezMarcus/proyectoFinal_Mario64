using UnityEngine;

public class Estrella: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            // Aquí puedes agregar la lógica para ganar el juego
            Debug.Log("¡Has ganado el juego!");
            // Puedes cargar una nueva escena, mostrar un mensaje de victoria, etc.
            // Ejemplo:
            // SceneManager.LoadScene("WinScene");
        }
    }
}