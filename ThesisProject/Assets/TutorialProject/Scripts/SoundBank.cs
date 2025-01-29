using UnityEngine;

public class SoundBank : MonoBehaviour
{

    public static SoundBank Instance {  get; private set; }

    public AudioClip stepAudio;

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

}
