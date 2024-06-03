using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthImage; // Asigna esta variable en el Inspector
    public Sprite[] healthSprites; // Asigna tus sprites en el Inspector
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // Aquí puedes implementar la lógica para reducir la salud.
        // Por ejemplo, reducir salud cuando se recibe daño:
        // currentHealth -= damageAmount;
        // UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        int spriteIndex = Mathf.FloorToInt((currentHealth / maxHealth) * (healthSprites.Length - 1));
        healthImage.sprite = healthSprites[spriteIndex];
    }
}
