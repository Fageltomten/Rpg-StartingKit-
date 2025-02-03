using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    bool isPaused;
    GameObject playerObject;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject menuList;


    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        isPaused = false;
        ResetPauseUI();
        pauseMenuObject.SetActive(false);
    }

    void OnPauseGame(InputValue input)
    {
        if (isPaused)
        {
            UnPauseGame();
        } else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuObject.SetActive(true);
    }

    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ResetPauseUI();
        pauseMenuObject.SetActive(false);
    }

    void ResetPauseUI()
    {
        int loopLength = menuList.transform.childCount;
        for (int i = 0; i < loopLength; i++)
        {
            menuList.transform.GetChild(i).gameObject.SetActive(false);
        }
        pauseStartMenuObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
