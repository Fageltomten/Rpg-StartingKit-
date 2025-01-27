using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform playerCamera;
    float xRotation;
    float yRotation;
    float mouseX;
    float mouseY;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXMovement = mouseX * Time.deltaTime * mouseSensitivity;
        float mouseYMovement = mouseY * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseYMovement;
        yRotation += mouseXMovement;

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    void OnLook(InputValue input) 
    {
        Vector2 mousePos = input.Get<Vector2>();
        mouseX = mousePos.x;
        mouseY = mousePos.y;
    }
}
