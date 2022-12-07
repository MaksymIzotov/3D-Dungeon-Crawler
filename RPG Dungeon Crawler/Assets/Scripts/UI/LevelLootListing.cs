using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelLootListing : MonoBehaviour
{
    #region Singleton Init
    public static LevelLootListing Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private struct Listing
    {
        public string lootName;
        public GameObject itemPrefab;
    }

    [SerializeField] private CurrentInventory inventory;
    [SerializeField] private GameObject layout;

    [SerializeField] private TMP_Text scrollsBlueAmount;
    [SerializeField] private TMP_Text scrollsPurpleAmount;
    [SerializeField] private TMP_Text scrollsRedAmount;
    [SerializeField] private TMP_Text coinsAmount;

    public void DisplayLoot()
    {
        ListingDelayed(UpdateListingItems());
        UpdateCollectedCoins();
    }

    private void UpdateCollectedCoins()
    {
        scrollsBlueAmount.text = "x" + LootInventory.Instance.collectedScrollsBlue;
        scrollsPurpleAmount.text = "x" + LootInventory.Instance.collectedScrollsPurple;
        scrollsRedAmount.text = "x" + LootInventory.Instance.collectedScrollsRed;
        coinsAmount.text = "x" + LootInventory.Instance.collectedCoins;
    }

    private Listing[] UpdateListingItems()
    {
        List<Listing> currentItemsToDisplay = new List<Listing>();

        foreach (Item item in inventory.LevelInventory)
        {
            bool isAlreadyInTheList = false;

            foreach (Listing displayItem in currentItemsToDisplay)
            {
                if (item.itemName == displayItem.lootName)
                {
                    isAlreadyInTheList = true;
                    break;
                }
            }

            if (isAlreadyInTheList) { continue; }

            Listing data = new Listing();
            data.lootName = item.itemName;
            data.itemPrefab = item.ingameIconPrefab;

            currentItemsToDisplay.Add(data);
        }

        return currentItemsToDisplay.ToArray();
    }


    private void ListingDelayed(Listing[] itemsToDisplay)
    {
        layout.SetActive(true);

        int index = 0;

        while (index < itemsToDisplay.Length)
        {
            GameObject lootIcon = Instantiate(itemsToDisplay[index].itemPrefab, layout.transform);

            int amount = 0;
            foreach (Item item in inventory.LevelInventory)
            {
                if (item.itemName == itemsToDisplay[index].lootName)
                    amount++;
            }

            lootIcon.GetComponentInChildren<TMP_Text>().text = "x" + amount;

            index++;
        }
    }
}
