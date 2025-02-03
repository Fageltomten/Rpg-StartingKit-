using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    enum MovementType { Walk, Run, Crouch }

    Rigidbody characterRB;
    Vector3 movementInput;
    Vector3 movementVector;

    MovementType currentMovementType;

    Animator animator;

    [Header("Walking")]
    [SerializeField] float movementSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float runSpeed;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCastRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentMovementType = MovementType.Walk;
    }

    private void Update()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        if (movementInput != null)
        {
            Vector3 xComp = transform.right * movementInput.x;
            Vector3 zComp = transform.forward * movementInput.z;

            Vector3 direction = Vector3.Normalize(xComp + zComp);

            movementVector = (direction) * getCurrentSpeed() * Time.fixedDeltaTime;

            Vector3 velocityVector = new Vector3(movementVector.x, characterRB.linearVelocity.y, movementVector.z);
            
            characterRB.linearVelocity = velocityVector;
        }
    }

    float getCurrentSpeed()
    {
        switch (currentMovementType)
        {
            
            case MovementType.Run:
                return runSpeed;
                break;
            case MovementType.Crouch:
                return crouchSpeed;
                break;
        }
        return movementSpeed;
    }

    private void OnMovement(InputValue input)
    {
        Vector2 takenInput = input.Get<Vector2>();
        movementInput = new Vector3(takenInput.x, 0, takenInput.y);
        animator.SetBool("isMoving", true);
    }

    private void OnMovementStop(InputValue input)
    {
        movementInput = Vector3.zero;
        animator.SetBool("isMoving", false);
    }

    private void OnJump(InputValue input)
    {
        characterRB.AddForce(new Vector3(0, jumpForce, 0));

    }

    private void OnCrouch(InputValue input)
    {
        if (currentMovementType == MovementType.Crouch)
        {
            currentMovementType = MovementType.Walk;
        } else
        {
            currentMovementType = MovementType.Crouch;
        }
    }

    private void OnSprint(InputValue input)
    {
        if (currentMovementType == MovementType.Run)
        {
            currentMovementType = MovementType.Walk;
        }
        else
        {
            currentMovementType = MovementType.Run;
        }
    }

}
