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

    private List<Spell> allBlueSpells = new List<Spell>();
    private List<Spell> allPurpleSpells = new List<Spell>();
    private List<Spell> allRedSpells = new List<Spell>();

    [SerializeField] private AudioClip learnSpellClip;

    [SerializeField] private const int learnSpellPrice = 5;

    private void OnEnable()
    {
        SetSpellsLists();
        UpdateSpellLists();
    }

    private void SetSpellsLists()
    {
        allBlueSpells.Clear();
        allPurpleSpells.Clear();
        allRedSpells.Clear();

        foreach(Spell spell in MenuInventoryController.Instance.allBlueSpellsReset)
        {
            allBlueSpells.Add(spell);
        }
        foreach (Spell spell in MenuInventoryController.Instance.allPurpleSpellsReset)
        {
            allPurpleSpells.Add(spell);
        }
        foreach (Spell spell in MenuInventoryController.Instance.allRedSpellsReset)
        {
            allRedSpells.Add(spell);
        }
    }

    private void UpdateSpellLists()
    {
        List<Spell> spellInv = MenuInventoryController.Instance.inventory.spellsInventory;

        List<Spell> removeBlue = new List<Spell>();
        List<Spell> removePurple = new List<Spell>();
        List<Spell> removeRed = new List<Spell>();

        foreach (Spell spell in spellInv)
        {
            foreach (Spell allSpellsBlue in allBlueSpells)
            {
                if (allSpellsBlue.spellName == spell.spellName)
                {
                    removeBlue.Add(allSpellsBlue);
                }
            }

            foreach (Spell allSpellsPurple in allBlueSpells)
            {
                if (allSpellsPurple.spellName == spell.spellName)
                {
                    removePurple.Add(allSpellsPurple);
                }
            }

            foreach (Spell allSpellsRed in allBlueSpells)
            {
                if (allSpellsRed.spellName == spell.spellName)
                {
                    removeRed.Add(allSpellsRed);
                }
            }
        }

        RemoveItemsFromList(ref allBlueSpells, removeBlue);
        RemoveItemsFromList(ref allPurpleSpells, removePurple);
        RemoveItemsFromList(ref allRedSpells, removeRed);
    }

    private void RemoveItemsFromList(ref List<Spell> mainList, List<Spell> removeList)
    {
        foreach (Spell remove in removeList)
        {
            mainList.Remove(remove);
        }
    }

    public void HideDescription()
    {
        descriptionParent.SetActive(false);
    }

    private void ShowDescription(Spell spell)
    {
        descriptionParent.SetActive(true);

        icon.sprite = spell.icon;
        spellName.text = spell.spellName;
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
        if (allBlueSpells.Count <= 0) { MenuNotification.Instance.ShowMessage("All blue spells are learned"); return; }

        if (MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls < learnSpellPrice) { MenuNotification.Instance.ShowMessage("Not enough blue spell scrolls"); return; }

        int index = Random.Range(0,allBlueSpells.Count);

        Spell learnedSpell = allBlueSpells[index];
        allBlueSpells.RemoveAt(index);
        MenuInventoryController.Instance.inventory.spellsInventory.Add(learnedSpell);

        MenuInventoryController.Instance.inventory.moneyInventory.amountBlueScrolls -= learnSpellPrice;

        MenuManager.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(learnSpellClip, 1);
        UpdateScrollsAmount();
        ShowDescription(learnedSpell);
    }

    public void LearnNewSpellPurple()
    {        
        if (allPurpleSpells.Count <= 0) { MenuNotification.Instance.ShowMessage("All purple spells are learned"); return; }

        if (MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls < learnSpellPrice) { MenuNotification.Instance.ShowMessage("Not enough purple spell scrolls"); return; }

        int index = Random.Range(0, allPurpleSpells.Count);

        Spell learnedSpell = allPurpleSpells[index];
        allPurpleSpells.RemoveAt(index);
        MenuInventoryController.Instance.inventory.spellsInventory.Add(learnedSpell);

        MenuInventoryController.Instance.inventory.moneyInventory.amountPurpleScrolls -= learnSpellPrice;

        MenuManager.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(learnSpellClip, 1);
        UpdateScrollsAmount();
        ShowDescription(learnedSpell);
    }

    public void LearnNewSpellRed()
    {
        if (allRedSpells.Count <= 0) { MenuNotification.Instance.ShowMessage("All red spells are learned"); return; }

        if (MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls < learnSpellPrice) { MenuNotification.Instance.ShowMessage("Not enough red spell scrolls"); return; }

        int index = Random.Range(0, allRedSpells.Count);

        Spell learnedSpell = allRedSpells[index];
        allRedSpells.RemoveAt(index);
        MenuInventoryController.Instance.inventory.spellsInventory.Add(learnedSpell);

        MenuInventoryController.Instance.inventory.moneyInventory.amountRedScrolls -= learnSpellPrice;

        MenuManager.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(learnSpellClip, 1);
        UpdateScrollsAmount();
        ShowDescription(learnedSpell);
    }
}
