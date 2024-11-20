using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameField;
    public TMP_Text dialogueField;
    
    private Queue<string> sentences;

    public Animator animator;
    private bool resetLevel;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, bool restartLevel)
    {
        animator.SetBool("isOpen", true);
        
        nameField.text = dialogue.name;

        sentences.Clear();
        resetLevel = restartLevel;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            if (resetLevel) SceneManager.LoadScene("Workshop3");
            return;
        }

        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueField.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueField.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialogue()
    {
        StopAllCoroutines();
        
        animator.SetBool("isOpen", false);
        Debug.Log("Ending conversation");
        FindObjectOfType<PlatformerMovement>().AllowMove();
    }
}
