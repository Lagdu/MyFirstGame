using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    
    public List<Item> content= new List<Item>();
    public int contentCurrentIndex = 0;

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

    public void  GetNextItem()
    {
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex=0;
        }
    }

    public void  GetPreviousItem()
    {

        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
    }

    public void AddCoin(int count)
    {
        coinsCount += count;
        UpdateTextUi();
    }
    public void RemoveCoin(int count)
    {
        coinsCount -= count;
        UpdateTextUi();
    }

    public void UpdateTextUi()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    public void ConsumeItem()
    {
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerMovement.instance.moveSpeed = currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
    }
}
