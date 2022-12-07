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
    [SerializeField] private GameObject descriptionParent;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private TMP_Text description;


    public Item currentLootDisplayed;

    public void HideDescription()
    {
        currentLootDisplayed = null;
        descriptionParent.SetActive(false);
    }

    public void ShowDescription(Item item)
    {
        descriptionParent.SetActive(true);

        icon.sprite = item.icon;
        itemName.text = item.itemName;
        stats.text = item.Stats();
        description.text = item.Desription();

        currentLootDisplayed = item;
    }
}
