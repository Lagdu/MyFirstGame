using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public AudioClip weakSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(weakSound, transform.position);
            Destroy(objectToDestroy);
        }

    }
}
