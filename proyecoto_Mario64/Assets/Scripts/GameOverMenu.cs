using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que el nombre de la escena del men� principal sea correcto
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel actual
    }
}
