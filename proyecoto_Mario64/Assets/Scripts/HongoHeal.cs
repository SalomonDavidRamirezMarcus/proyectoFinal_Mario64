using UnityEngine;

public class HongoHeal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Destroy(gameObject); // Destruir Hongo
            }
        }
    }
}
