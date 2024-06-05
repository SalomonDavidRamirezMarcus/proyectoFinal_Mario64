using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameOver : MonoBehaviour
{
    public Animator anim;
    private int sceneToLoad;

    public void StartFadeScene()
    {
        //sceneToLoad = sceneIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnfadeComplete()
    {
        SceneManager.LoadScene(2);
    }
}


