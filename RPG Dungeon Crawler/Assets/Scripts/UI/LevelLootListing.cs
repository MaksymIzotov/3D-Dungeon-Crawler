using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelLootListing : MonoBehaviour
{
    public static LevelLootListing Instance;
    private void Awake()
    {
        Instance = this;
    }

    private struct Listing
    {
        public string lootName;
        public GameObject itemPrefab;
    }

    [SerializeField] private CurrentInventory inventory;
    [SerializeField] private GameObject layout;

    public void DisplayLoot()
    {
        ListingDelayed(UpdateListingItems());
    }

    private Listing[] UpdateListingItems()
    {
        List<Listing> currentItemsToDisplay = new List<Listing>();

        foreach (LootInfo item in inventory.LevelInventory)
        {
            bool isAlreadyInTheList = false;

            foreach (Listing displayItem in currentItemsToDisplay)
            {
                if (item.lootName == displayItem.lootName)
                {
                    isAlreadyInTheList = true;
                    break;
                }
            }

            if (isAlreadyInTheList) { continue; }

            Listing data = new Listing();
            data.lootName = item.lootName;
            data.itemPrefab = item.iconPrefab;

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
            foreach (LootInfo item in inventory.LevelInventory)
            {
                if (item.lootName == itemsToDisplay[index].lootName)
                    amount++;
            }

            lootIcon.GetComponentInChildren<TMP_Text>().text = "x" + amount;

            index++;
        }
    }
}
