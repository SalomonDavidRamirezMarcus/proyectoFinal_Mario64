using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarController : MonoBehaviour
{
    public Image healthImage; // Asigna esta variable en el Inspector
    public Sprite[] healthSprites; // Asigna tus sprites en el Inspector
    private int spriteIndex;
    private Coroutine fadeCoroutine;

    void Start()
    {
        spriteIndex = 0;
        healthImage.sprite = healthSprites[spriteIndex]; // Inicializa con el primer sprite
        healthImage.canvasRenderer.SetAlpha(0.0f); // Inicializa con la imagen invisible
    }

    void Update()
    {
        // Aqu� puedes implementar la l�gica para reducir la salud.
        // Por ejemplo, reducir salud cuando se recibe da�o:
        // currentHealth -= damageAmount;
        // UpdateHealthBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        else if (collision.transform.CompareTag("Heal"))
        {
            HealDamage();
        }
    }

    private void TakeDamage()
    {
        if (spriteIndex < healthSprites.Length - 1) // Aseg�rate de no exceder el tama�o del array
        {
            spriteIndex += 1;
            healthImage.sprite = healthSprites[spriteIndex];
            Debug.Log("DA�O");

            // Si hay una corrutina de desvanecimiento corriendo, detenerla
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            // Mostrar la imagen y comenzar la corrutina para desvanecerla
            healthImage.canvasRenderer.SetAlpha(1.0f);
            fadeCoroutine = StartCoroutine(FadeOutAfterDelay(4.0f));
        }
        else
        {
            Debug.Log("No m�s vida");
            // Aqu� podr�as implementar l�gica adicional, como destruir al personaje, mostrar una pantalla de game over, etc.
        }
    }

    private void HealDamage()
    {
        if (spriteIndex > 0) // Aseg�rate de no exceder el tama�o del array
        {
            spriteIndex -= 1;
            healthImage.sprite = healthSprites[spriteIndex];
            Debug.Log("CURACI�N");

            // Si hay una corrutina de desvanecimiento corriendo, detenerla
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            // Mostrar la imagen y comenzar la corrutina para desvanecerla
            healthImage.canvasRenderer.SetAlpha(1.0f);
            fadeCoroutine = StartCoroutine(FadeOutAfterDelay(4.0f));
        }
        else
        {
            Debug.Log("Vida completa");
            // Aqu� podr�as implementar l�gica adicional, como evitar curar m�s all� de la vida m�xima.
        }
    }

    private IEnumerator FadeOutAfterDelay(float delay)
    {
        // Espera por el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Desvanecer la imagen gradualmente
        float fadeDuration = 1.0f; // Duraci�n del desvanecimiento
        float fadeSpeed = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            progress += Time.deltaTime * fadeSpeed;
            healthImage.canvasRenderer.SetAlpha(1.0f - progress);
            yield return null;
        }

        healthImage.canvasRenderer.SetAlpha(0.0f);
    }
}

