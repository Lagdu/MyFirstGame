using UnityEngine;

public class PickupCoin : MonoBehaviour
{

    public AudioClip sound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject); 
        }
        
    }
}
