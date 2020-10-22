using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    
    
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la sscene");
            return;
        }

        instance = this;

    }

    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUi();
        Debug.LogWarning(PlayerPrefs.GetInt("playerHealth", 0));
        
        /*int currentHealth = PlayerPrefs.GetInt("playerHealth", 0);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/
    }


    void Update()
    {

    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1)) { 
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }
        //PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);
    }


}
