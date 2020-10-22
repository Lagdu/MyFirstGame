using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsMenu;

    public void StartGameButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void OpenSettingsButton()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void CloseSettingsButton()
    {
        settingsMenu.SetActive(false);
    }

    public void QuitgameButton()
    {
        Application.Quit();
    }


}
