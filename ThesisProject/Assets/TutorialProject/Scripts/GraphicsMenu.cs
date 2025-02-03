using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{

    GameObject playerObject;
    TMP_Dropdown resolutionDropDown;
    Slider mouseSensitivitySlider;
    Resolution[] resolutions;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

}
