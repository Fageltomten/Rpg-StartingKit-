using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;
    [SerializeField] TMP_Text masterText;
    [SerializeField] TMP_Text SFXText;
    [SerializeField] TMP_Text ambienceText;



    public void SetMasterVolume(float volume)
    {
        SetVolume(volume, masterText, "MasterVolume");
    }

    public void SetSFXVolume(float volume)
    {
        SetVolume(volume, SFXText, "SFXVolume");
    }

    public void SetAmbienceVolume(float volume)
    {
        SetVolume(volume, ambienceText, "AmbienceVolume");
    }


    void SetVolume(float volume, TMP_Text displayText, string type)
    {
        int displayVolume = (int)Mathf.Clamp(volume * 10, 0f, 20f);
        displayText.text = displayVolume.ToString();

        mixer.SetFloat(type, Mathf.Log10(volume) * 20);
    }
    
}
