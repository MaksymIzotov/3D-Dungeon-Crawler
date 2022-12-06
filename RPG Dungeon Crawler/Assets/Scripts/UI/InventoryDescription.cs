using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDescription : MonoBehaviour
{
    #region Singleton Init
    public static InventoryDescription Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private TMP_Text description;

    public Item currentLootDisplayed;

    public void ShowDescription(Item item)
    {
        icon.sprite = item.icon;
        itemName.text = item.name;
        //stats.text = item.Stats();
        //description.text = item.description;

        currentLootDisplayed = item;
    }
}
