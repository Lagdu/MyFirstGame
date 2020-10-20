
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthpoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            { 
                PlayerHealth.instance.HealPlayer(healthpoints);
                Destroy(gameObject);
            }
        }
    }
}
