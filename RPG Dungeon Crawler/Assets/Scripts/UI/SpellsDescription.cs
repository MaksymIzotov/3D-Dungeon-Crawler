using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellsDescription : MonoBehaviour
{
    #region Singleton Init
    public static SpellsDescription Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private GameObject descriptionParent;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text spellName;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private TMP_Text description;
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject upgradeMoney;
    [SerializeField] private TMP_Text currentLevelText;
    [SerializeField] private Sprite blueScrollImage;
    [SerializeField] private Sprite purpleScrollImage;
    [SerializeField] private Sprite redScrollImage;
    [SerializeField] private GameObject blueScrolls;
    [SerializeField] private GameObject purpleScrolls;
    [SerializeField] private GameObject redScrolls;


    public Spell currentSpellDisplayed;

    public void UpgradeSpell()
    {
        //Money check and update
        switch (currentSpellDisplayed.scrollType) {
            case Spell.ScrollType.Blue:
                if (MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls < currentSpellDisplayed.upgradePrice) { return; }

                MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls -= currentSpellDisplayed.upgradePrice;
                break;
            case Spell.ScrollType.Purple:
                if (MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls < currentSpellDisplayed.upgradePrice) { return; }

                MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls -= currentSpellDisplayed.upgradePrice;
                break;
            case Spell.ScrollType.Red:
                if (MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls < currentSpellDisplayed.upgradePrice) { return; }

                MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls -= currentSpellDisplayed.upgradePrice;
                break;
        }

        //Upgrade spell stats
        for (int i = 0; i < MenuInventoryController.Instance.inventory.spellsInventory.Count; i++)
        {
            if(MenuInventoryController.Instance.inventory.spellsInventory[i].spellName == currentSpellDisplayed.spellName)
            {
                MenuInventoryController.Instance.inventory.spellsInventory[i].lvl++;
                MenuInventoryController.Instance.inventory.spellsInventory[i].spellReference.UpgradeStats();
            }
        }

        UpdateScrollsAmount();
        ShowDescription(currentSpellDisplayed);
    }

    public void UpdateScrollsAmount()
    {
        blueScrolls.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls;
        purpleScrolls.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls;
        redScrolls.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls;
    }

    public void ResetCurrentSpell()
    {
        currentSpellDisplayed.spellReference.Reset();

        ShowDescription(currentSpellDisplayed);
    }
    
    public void ResetAllSpells()
    {
        foreach(Spell spell in MenuInventoryController.Instance.inventory.AllSpellsInTheGame)
        {
            spell.spellReference.Reset();
        }

        ShowDescription(currentSpellDisplayed);
    }

    public void HideDescription()
    {
        currentSpellDisplayed = null;
        descriptionParent.SetActive(false);
    }

    public void ShowDescription(Spell spell)
    {
        descriptionParent.SetActive(true);

        if(spell.lvl >= spell.maxLvl)
        {
            currentLevelText.text = "Lvl max";
            upgradeButton.SetActive(false);
            upgradeMoney.SetActive(false);
        }
        else
        {
            currentLevelText.text = "Lvl: " + spell.lvl;
            upgradeMoney.SetActive(true);
            upgradeButton.SetActive(true);

            upgradeMoney.GetComponentInChildren<TMP_Text>().text = "x" + spell.upgradePrice;

            switch (spell.scrollType) {
                case Spell.ScrollType.Blue:
                    upgradeMoney.GetComponent<Image>().sprite = blueScrollImage;
                        break;
                case Spell.ScrollType.Purple:
                    upgradeMoney.GetComponent<Image>().sprite = purpleScrollImage;
                    break;
                case Spell.ScrollType.Red:
                    upgradeMoney.GetComponent<Image>().sprite = redScrollImage;
                    break;
            }
        }
        icon.sprite = spell.icon;
        spellName.text = spell.spellName;
        stats.text = spell.Stats();
        description.text = spell.Desription();

        currentSpellDisplayed = spell;
    }
}
