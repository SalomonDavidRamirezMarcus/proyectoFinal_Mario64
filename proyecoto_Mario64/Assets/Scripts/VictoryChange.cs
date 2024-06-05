using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryChange : MonoBehaviour
{
    public Animator anim;
    private int sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Inicia el fade y guarda la escena que quieres cargar
            fadeScene(0);
        }
    }

    private void fadeScene(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        anim.SetTrigger("FadeOut");
    }

    // Esta funci�n ser� llamada al final de la animaci�n de fade out
    public void OnfadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
