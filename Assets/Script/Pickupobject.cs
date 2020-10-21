using UnityEngine;

public class Pickupobject : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sound);
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject); 
        }
        
    }
}
