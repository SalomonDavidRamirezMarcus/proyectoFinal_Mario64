using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOverController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string menuSceneName = "MainMenu"; // Nombre de la escena del menú principal

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd; // Agregar un evento para cuando termine el video
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(menuSceneName); // Cargar la escena del menú principal
    }
}
