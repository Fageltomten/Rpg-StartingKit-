using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    void OnMovement(InputValue input)
    { 

        if (audioSource.isPlaying)
        {
            if (input.Get<Vector2>() == Vector2.zero)
            {
                audioSource.Stop();
                return;
            }
        }

        audioSource.clip = SoundBank.Instance.stepAudio;
        audioSource.Play();
        
            
    }
}
