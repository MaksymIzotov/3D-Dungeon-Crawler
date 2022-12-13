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
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject upgradePrice;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private GameObject moneyAmount;

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
        if (MenuInventoryController.Instance.inventory.moneyInventory.amountCoins < currentLootDisplayed.upgradePrice) { return; } // Not enough coins

        //Upgrade item
        MenuInventoryController.Instance.inventory.moneyInventory.amountCoins -= currentLootDisplayed.upgradePrice;

        for (int i = 0; i < MenuInventoryController.Instance.inventory.GlobalInventory.Count; i++)
        {
            if(MenuInventoryController.Instance.inventory.GlobalInventory[i].itemName == currentLootDisplayed.itemName)
            {
                MenuInventoryController.Instance.inventory.GlobalInventory[i].lvl++;
                MenuInventoryController.Instance.inventory.GlobalInventory[i].itemReference.UpgradeStats();
                break;
            }
        }

        UpdateCurrentMoney();
        ShowDescription(currentLootDisplayed);
    }

    public void UpdateCurrentMoney()
    {
        moneyAmount.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountCoins;
    }

    public void ResetAll()
    {
        foreach(Item item in MenuInventoryController.Instance.inventory.AllItemsInTheGame)
        {
            item.Reset();
        }

        if (currentLootDisplayed != null)
            ShowDescription(currentLootDisplayed);
    }

    public void ResetCurrentItem()
    {
        if (currentLootDisplayed == null) { return; }

        currentLootDisplayed.Reset();
        ShowDescription(currentLootDisplayed);
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


        if (item.lvl >= item.maxLvl) //Level is maximum
        {
            upgradeButton.SetActive(false);
            upgradePrice.SetActive(false);

            levelText.text = "Lvl max";
        }
        else //Show upgrade button and set it up
        {
            upgradeButton.SetActive(true);
            upgradePrice.SetActive(true);

            levelText.text = "Lvl " + item.lvl;

            //TODO: get price for current level
            upgradePrice.GetComponentInChildren<TMP_Text>().text = "x" + item.upgradePrice;
        }

        if (item.evolutionItem == null) //Cant evolve
        {
            evolveButton.SetActive(false);
            evolveImage.SetActive(false);
        }
        else //Show evolve button and set it up
        {
            evolveButton.SetActive(true);
            evolveImage.SetActive(true);

            evolveImage.GetComponent<Image>().sprite = item.icon;
            evolveImage.GetComponentInChildren<TMP_Text>().text = "x" + item.evolvePrice;
        }

        currentLootDisplayed = item;
    }
}
