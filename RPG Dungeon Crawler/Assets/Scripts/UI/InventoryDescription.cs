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
    [SerializeField] private GameObject evolveImage;
    [SerializeField] private GameObject evolveButton;
    [SerializeField] private TMP_Text levelText;



    public Item currentLootDisplayed;

    public void EvolveItem()
    {
        int amount = 0;
        foreach(Item item in MenuInventoryController.Instance.inventory.GlobalInventory)
        {
            if (item.itemName == currentLootDisplayed.itemName)
                amount++;
        }

        if (currentLootDisplayed.evolvePrice > amount) { return; } //Cant afford

        if (currentLootDisplayed.evolvePrice == amount)
        {
            switch (currentLootDisplayed.type)
            {
                case Item.ItemType.Weapon:
                    if (MenuInventoryController.Instance.inventory.weapon == currentLootDisplayed)
                    {
                        MenuInventoryController.Instance.inventory.weapon = null;
                    }
                    break;
                case Item.ItemType.Armor:
                    if (MenuInventoryController.Instance.inventory.armor == currentLootDisplayed)
                    {
                        MenuInventoryController.Instance.inventory.armor = null;
                    }
                    break;
                case Item.ItemType.Usable:
                    if (MenuInventoryController.Instance.inventory.usable == currentLootDisplayed)
                    {
                        MenuInventoryController.Instance.inventory.usable = null;
                    }
                    break;
            }
        }

        for (int i = 0; i < currentLootDisplayed.evolvePrice; i++)
        {
            MenuInventoryController.Instance.inventory.GlobalInventory.Remove(currentLootDisplayed);
        }

        currentLootDisplayed = currentLootDisplayed.evolutionItem;
        MenuInventoryController.Instance.inventory.GlobalInventory.Add(currentLootDisplayed);

        MenuUIManager.Instance.UpdateItemButtons();
        MenuUIManager.Instance.UpdateItemIcons();
        ShowDescription(currentLootDisplayed);
    }

    public void UpgradeItem()
    {

    }

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
        levelText.text = "Lvl " + item.lvl;

        if (item.evolutionItem == null)
        {
            evolveButton.SetActive(false);
            evolveImage.SetActive(false);
        }
        else
        {
            evolveButton.SetActive(true);
            evolveImage.SetActive(true);

            evolveImage.GetComponent<Image>().sprite = item.icon;
            evolveImage.GetComponentInChildren<TMP_Text>().text = "x" + item.evolvePrice;
        }

        currentLootDisplayed = item;
    }
}
