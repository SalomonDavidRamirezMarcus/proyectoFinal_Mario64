using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthImage; // Asigna esta variable en el Inspector
    public Sprite[] healthSprites; // Asigna tus sprites en el Inspector
    private int spriteIndex;

    void Start()
    {
        spriteIndex = 0;
        healthImage.sprite = healthSprites[spriteIndex]; // Inicializa con el primer sprite
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
    }

    private void TakeDamage()
    {
        if (spriteIndex < healthSprites.Length - 1) // Aseg�rate de no exceder el tama�o del array
        {
            spriteIndex += 1;
            healthImage.sprite = healthSprites[spriteIndex];
            Debug.Log("DA�O");
        }
        else
        {
            Debug.Log("No m�s vida");
            // Aqu� podr�as implementar l�gica adicional, como destruir al personaje, mostrar una pantalla de game over, etc.
        }
    }
    void cambiarImagen()
    {
        healthImage.sprite = healthSprites[1];
    }

}








