using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCscript : MonoBehaviour, IInteractable
{

    public enum DialogueType
    {
        Looping,
        Random, 
        Clamp
    }

    [SerializeField] DialogueType dialogueType;

    [SerializeField]SO_Dialogue[] dialogue;


    Queue<SO_Dialogue> dialogueQueue = new Queue<SO_Dialogue>();
    int numberOfDialoguesLeft = 0;

    void Start()
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogueQueue.Enqueue(dialogue[i]);
            numberOfDialoguesLeft++;
        }
        
    }

    public void Interact()
    {
        DialogueManager.Instance.Queue(SelectDialogue());
    }

    SO_Dialogue SelectDialogue()
    {
        SO_Dialogue selectedDialouge = dialogueQueue.ElementAt(0);

        switch (dialogueType)
        {
            case DialogueType.Looping:
                dialogueQueue.Enqueue(dialogueQueue.Dequeue());
                break;
            case DialogueType.Clamp:
                numberOfDialoguesLeft--;
                if (numberOfDialoguesLeft > 0)
                {
                    dialogueQueue.Dequeue();
                }
                break;
            case DialogueType.Random:
                int randomIndex = Random.Range(0, numberOfDialoguesLeft);
                return dialogue[randomIndex];
                break;
        }

        return selectedDialouge;

    }

    
}
