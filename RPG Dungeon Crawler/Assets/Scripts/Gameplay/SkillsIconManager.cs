using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillsIconManager : MonoBehaviour
{
    public static SkillsIconManager Instance;

    public Image[] skillsIcons;
    [SerializeField] private Image usableImage;
    [SerializeField] private TMP_Text usableAmount;

    [SerializeField] private Sprite emptySpellSlot;
    [SerializeField] private Sprite emptyUsableSlot;

    private void Awake()
    {
        Instance = this;
    }

    public void SetupIcon(Spell[] spells)
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i] == null)
            {
                skillsIcons[i].sprite = emptySpellSlot;
                foreach (Transform child in skillsIcons[i].transform)
                {
                    child.gameObject.SetActive(false);
                }
                continue;
            }

            skillsIcons[i].sprite = spells[i].icon;
        }
    }

    public void SetupUsable(Item item, out int itemAmount)
    {
        if (item == null)
        {
            usableImage.sprite = emptyUsableSlot;
            foreach (Transform child in usableImage.transform)
            {
                child.gameObject.SetActive(false);
            }
            itemAmount = 0;
            return;
        }

        usableImage.sprite = item.icon;

        int amount = 0;
        foreach(Item allItem in LootInventory.Instance.inventory.GlobalInventory)
        {
            if (item.itemName == allItem.itemName) {
                amount++;
            }
        }

        usableAmount.text = "x" + amount;

        itemAmount = amount;
    }

    public void UpdateAmount(int amount)
    {
        if (amount <= 0)
            usableImage.gameObject.SetActive(false);

        usableAmount.text = "x" + amount;
    }
}
