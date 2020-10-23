using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public Image itemImageUi;
    public Text itemNameUi;
    public Sprite emptyItemImage;

    public List<Item> content = new List<Item>();
    private int contentCurrentIndex = 0;

    public PlayerEffect playerEffect;

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

    private void Start()
    {
        UpdateInventoryUi();
    }

    public void  GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex=0;
        }
        UpdateInventoryUi();
    }

    public void  GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUi();
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
        if (content.Count == 0)
        {
            return;
        }
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffect.AddSpedd(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUi();
    }

    public void UpdateInventoryUi()
    {
        if (content.Count > 0) {
            Debug.LogWarning(" PAS EMPTY : " + content.Count);
            itemImageUi.sprite = content[contentCurrentIndex].image;
            itemNameUi.text = content[contentCurrentIndex].name;
        }
        else
        {
            Debug.LogWarning("EMPTY : " + content.Count);
            itemImageUi.sprite = emptyItemImage;
            itemNameUi.text = "";
        }
    }
}
