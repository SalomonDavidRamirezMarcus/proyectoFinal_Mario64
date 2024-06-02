using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valormoneda = 1; // Valor de la moneda

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.CollectCoin(valormoneda);
                Destroy(gameObject); // Destruye la moneda una vez recolectada
            }
        }
    }
}
