using UnityEngine;
using UnityEngine.InputSystem;


public interface IInteractable
{
    void Interact();
}

public class PlayerInteract : MonoBehaviour
{

    Camera cam;
    [SerializeField] float interactRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    void OnInteract(InputValue input)
    {
        Vector3 rayPos = cam.transform.position;
        Vector3 rayDir = cam.transform.forward;

        RaycastHit hit;
        Physics.Raycast(rayPos, rayDir, out hit, interactRange);

        IInteractable interactable = hit.transform.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Interact();
        }

    }

    
}
