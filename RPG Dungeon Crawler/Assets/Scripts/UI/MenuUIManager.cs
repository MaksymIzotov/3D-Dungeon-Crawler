using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    #region Singleton Init
    public static MenuUIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private GameObject[] currentSpells;

    [SerializeField] private Transform obtainedSpellsParent;

    public void UpdateSpellsIcons()
    {
        Spell[] inv = MenuInventoryController.Instance.inventory.spells;

        for (int i = 0; i < currentSpells.Length; i++)
        {
            if (inv[i] == null)
                currentSpells[i].GetComponent<Image>().sprite = null; //TODO: Add empty spell sprite
            else
                currentSpells[i].GetComponent<Image>().sprite = inv[i].icon;
        }
    }

    public void UpdateSpellButtons()
    {
        List<CurrentInventory.SpellInfo> spells = MenuInventoryController.Instance.inventory.spellsInventory;

        //Clear
        foreach (Transform child in obtainedSpellsParent)
        {
            Destroy(child.gameObject);
        }

        //Update
        foreach (CurrentInventory.SpellInfo spell in spells)
        {
            Instantiate(spell.buttonPrefab, obtainedSpellsParent);
        }
    }
}
