using UnityEngine;

public class TrainingDummyInteract : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with Training Dummy!");
    }
}
