using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int coinCount = 0; // Contador de monedas
    public Text coinText; // Referencia al Text del UI que muestra las monedas
    public GameObject star; // Referencia al objeto estrella
    public AudioClip coinSound; // Sonido de recolección de monedas
    public AudioClip winSound; // Sonido de recolección de la estrella
    private AudioSource audioSource;

    private void Start()
    {
        UpdateCoinUI(); // Inicializa el UI con el contador actual de monedas
        star.SetActive(false); // Asegúrate de que la estrella esté inactiva al inicio
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource
    }

    public void CollectCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();
        PlaySound(coinSound); // Reproduce el sonido de la moneda

        if (coinCount >= 8)
        {
            ActivateStar();
        }
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Monedas: " + coinCount.ToString();
    }

    private void ActivateStar()
    {
        star.SetActive(true); // Activa la estrella
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
