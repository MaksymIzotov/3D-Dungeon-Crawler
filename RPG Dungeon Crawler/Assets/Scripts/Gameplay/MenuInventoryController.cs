using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInventoryController : MonoBehaviour
{
    #region Singleton Init
    public static MenuInventoryController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public CurrentInventory inventory;

    [SerializeField] private TMP_Text itemDecription;

    public void AddSpellToInventory(int spellIndex)
    {
        for (int i = 0; i < inventory.spells.Length; i++)
        {
            if (inventory.spells[i] == SpellsDescription.Instance.currentSpellDisplayed)
                inventory.spells[i] = null;
        }

        inventory.spells[spellIndex] = SpellsDescription.Instance.currentSpellDisplayed;
    }

    public void ShowItemDescription(Item info)
    {
        
    }
}
