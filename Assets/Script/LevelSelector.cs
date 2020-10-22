using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevelpassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
