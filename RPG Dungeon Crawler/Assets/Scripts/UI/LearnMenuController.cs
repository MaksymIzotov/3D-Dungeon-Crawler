using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LearnMenuController : MonoBehaviour
{
    #region Singleton Init

    public static LearnMenuController Instance;
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

    [SerializeField] private GameObject blueScrolls;
    [SerializeField] private GameObject purpleScrolls;
    [SerializeField] private GameObject redScrolls;

    [SerializeField] private GameObject bluePriceScrolls;
    [SerializeField] private GameObject purplePriceScrolls;
    [SerializeField] private GameObject redPriceScrolls;


    [SerializeField] List<Spell> allBlueSpells;
    [SerializeField] List<Spell> allPurpleSpells;
    [SerializeField] List<Spell> allRedSpells;

    [SerializeField] private const int learnSpellPrice = 5;

    public void HideDescription()
    {
        descriptionParent.SetActive(false);
    }

    private void ShowDescription(Spell spell)
    {
        descriptionParent.SetActive(true);

        icon.sprite = spell.icon;
        spellName.text = spell.name;
        stats.text = spell.Stats();
        description.text = spell.Desription();
    }

    public void UpdateLearnPrice()
    {
        bluePriceScrolls.GetComponentInChildren<TMP_Text>().text = "x" + learnSpellPrice;
        purplePriceScrolls.GetComponentInChildren<TMP_Text>().text = "x" + learnSpellPrice;
        redPriceScrolls.GetComponentInChildren<TMP_Text>().text = "x" + learnSpellPrice;
    }

    public void UpdateScrollsAmount()
    {
        blueScrolls.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls;
        purpleScrolls.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls;
        redScrolls.GetComponentInChildren<TMP_Text>().text = "x" + MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls;
    }

    public void LearnNewSpellBlue()
    {
        if (allBlueSpells.Count <= 0) { return; } //Show all spells learned message

        if (MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls < learnSpellPrice) { return; }

        int index = Random.Range(0,allBlueSpells.Count);

        Spell learnedSpell = allBlueSpells[index];
        allBlueSpells.RemoveAt(index);
        MenuInventoryController.Instance.inventory.spellsInventory.Add(learnedSpell);

        MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls -= learnSpellPrice;

        UpdateScrollsAmount();
        ShowDescription(learnedSpell);
    }

    public void LearnNewSpellPurple()
    {
        if (allPurpleSpells.Count <= 0) { return; } //Show all spells learned message

        if (MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls < learnSpellPrice) { return; }

        int index = Random.Range(0, allPurpleSpells.Count);

        Spell learnedSpell = allPurpleSpells[index];
        allPurpleSpells.RemoveAt(index);
        MenuInventoryController.Instance.inventory.spellsInventory.Add(learnedSpell);

        MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls -= learnSpellPrice;

        UpdateScrollsAmount();
        ShowDescription(learnedSpell);
    }

    public void LearnNewSpellRed()
    {
        if (allRedSpells.Count <= 0) { return; } //Show all spells learned message

        if (MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls < learnSpellPrice) { return; }

        int index = Random.Range(0, allRedSpells.Count);

        Spell learnedSpell = allRedSpells[index];
        allRedSpells.RemoveAt(index);
        MenuInventoryController.Instance.inventory.spellsInventory.Add(learnedSpell);

        MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls -= learnSpellPrice;

        UpdateScrollsAmount();
        ShowDescription(learnedSpell);
    }
}
