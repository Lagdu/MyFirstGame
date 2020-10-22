using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d\'une instance DialogueManager dans la sscene");
            return;
        }

        instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen",true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentense in dialogue.sentences)
        {
            sentences.Enqueue(sentense);
        }

        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentence));
    }

    IEnumerator TypeSentense(string sentense)
    {
        dialogueText.text = "";
        foreach (char letter in sentense.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

}
