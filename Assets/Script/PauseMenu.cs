using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {

        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }


    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }
}
