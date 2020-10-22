using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundChest;

    private Text interactUi;
    private bool isInRange;

    private void Awake()
    {
        interactUi = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange )
        {
            OpenChest();
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

    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoin(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundChest, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUi.enabled = false;
    }
}
