using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwingAnimation : MonoBehaviour
{
   Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAttack(InputValue input)
    {
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("isSwinging");
        }
        
    }
}
