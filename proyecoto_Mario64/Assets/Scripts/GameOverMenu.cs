using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Asegúrate de que el nombre de la escena del menú principal sea correcto
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel actual
    }
}
