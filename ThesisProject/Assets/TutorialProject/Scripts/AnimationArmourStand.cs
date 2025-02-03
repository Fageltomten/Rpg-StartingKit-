using UnityEngine;

public class AnimationArmourStand : MonoBehaviour, IInteractable
{

    Animation spinAnimation;

    private void Start()
    {
        spinAnimation = GetComponent<Animation>();
    }

    public void Interact()
    {
        if (!spinAnimation.isPlaying)
        {
            spinAnimation.Play();
        }
    }

    
}
