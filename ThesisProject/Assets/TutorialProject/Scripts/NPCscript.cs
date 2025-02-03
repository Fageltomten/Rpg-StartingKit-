using UnityEngine;

public class NPCscript : MonoBehaviour, IInteractable
{

    [SerializeField]SO_Dialogue dialogue;

    public void Interact()
    {
        DialogueManager.Instance.Queue(dialogue);
    }
}
