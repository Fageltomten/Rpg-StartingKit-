using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphicsMenu : MonoBehaviour
{

    GameObject playerObject;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    Resolution[] resolutions;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
    }
    
    public void CharngeSenitivity()
    {
        float sliderValue = mouseSensitivitySlider.value;
        playerObject.GetComponent<PlayerLook>().MouseSensitivity = sliderValue;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    void PopulateResDropDown()
    {
        int currentResIndex = 0;
        List<string> resNames = new List<string>();

        resolutions = Screen.resolutions;

        for(int i = 0; i < resolutions.Length; i++)
        {
            resNames.Add(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());

            if (Screen.currentResolution.ToString() == resolutions[i].ToString())
            {
                currentResIndex = i;
            }
        }

        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(resNames);
        resolutionDropDown.value = currentResIndex;

    }

    public void ChangeResolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, Screen.fullScreen);
    }

}
