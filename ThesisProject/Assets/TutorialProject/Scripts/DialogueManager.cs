using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance { get; private set; }


    bool isInDialogue;
    bool isTyping;
    Queue<SO_Dialogue.Info> infoQueue;
    string completeString;
    [SerializeField]float textDelay;

    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject dialogueText;

    TMP_Text dialogueShowText;

    PlayerInput playerControlls;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        infoQueue = new Queue<SO_Dialogue.Info>();
        playerControlls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        dialogueShowText = dialogueText.GetComponent<TMP_Text>();
    }


    IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isTyping = true;
        foreach (char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueShowText.text += c;
        }
        isTyping = false;
    }

    void CompleteText()
    {
        dialogueShowText.text = completeString;
        isTyping = false;
    }

    void EndDialogue()
    {
        isInDialogue = false;
        playerControlls.enabled = true;
        dialogueBox.SetActive(false);
    }

    void OnInteract(InputValue input)
    {
        if (isInDialogue)
        {
            DeQueue();
        }
    }

    public void Queue(SO_Dialogue dia)
    {
        foreach (SO_Dialogue.Info line in dia.dialogueInfo)
        {
            infoQueue.Enqueue(line);
        }
        dialogueBox.SetActive(true);
        playerControlls.enabled = false;
        isInDialogue = true;

        completeString = infoQueue.ElementAt(0).dialogue;

        DeQueue();
    }

    void DeQueue()
    {
        if (isTyping)
        {
            CompleteText();
            StopAllCoroutines();
            return;
        }

        if (infoQueue.Count <= 0)
        {
            EndDialogue();
            return;
        }

        dialogueShowText.text = "";
        SO_Dialogue.Info info = infoQueue.Dequeue();
        completeString = info.dialogue;
        StartCoroutine(TypeText(info));

    }

}
