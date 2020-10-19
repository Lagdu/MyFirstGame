using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;


    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d\'une instance d\'inventory dans la sscene");
            return;
        }

        instance = this;
    }

    public void AddCoin(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
}
