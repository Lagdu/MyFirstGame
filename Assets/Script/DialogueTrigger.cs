using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isInRange;
    private Text interactUi;

    void Awake()
    {
        interactUi = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();

    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUi.enabled = true;
        }   
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUi.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
