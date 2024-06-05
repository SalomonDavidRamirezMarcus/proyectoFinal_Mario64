using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator anim;
    private int sceneToLoad;

    // Update is called once per frame
    /*
    void Update()
    {
     if(Input.GetMouseButtonDown(0))
        {
            fadeScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    */
    
    private void fadeScene(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        anim.SetTrigger("FadeOut");

    }

    public void OnfadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
