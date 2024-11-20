using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger4 : MonoBehaviour
{
    public Dialogue dialogue;
    public bool endsGame;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager3>().StartDialogue(dialogue, endsGame);
    }
}
