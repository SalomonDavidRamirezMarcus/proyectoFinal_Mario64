
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int coinCount = 0; // Contador de monedas
    public Text coinText; // Referencia al Text del UI que muestra las monedas
    public GameObject star; // Referencia al objeto estrella

    private void Start()
    {
        UpdateCoinUI(); // Inicializa el UI con el contador actual de monedas
        star.SetActive(false); // Asegúrate de que la estrella esté inactiva al inicio
    }

    public void CollectCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();

        if (coinCount >= 10)
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
}