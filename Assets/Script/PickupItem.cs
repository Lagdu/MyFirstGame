using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public Item item;
    public AudioClip soundToPlay;
    private Text interactUi;
    private bool isInRange;

    private void Awake()
    {
        interactUi = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUi.enabled = true;
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUi.enabled = false;
            isInRange = false;
        }
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUi();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        interactUi.enabled = false;
        Destroy(gameObject);
    }

}
