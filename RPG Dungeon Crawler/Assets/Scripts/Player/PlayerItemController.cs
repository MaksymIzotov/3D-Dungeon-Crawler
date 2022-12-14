using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemController : MonoBehaviour
{
    Item equiped_armor;
    Item equiped_weapon;
    Item equiped_usable;

    private int usableAmount;

    private bool isUsing = false;

    private void Start()
    {
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        //Armor setup
        equiped_armor = LootInventory.Instance.inventory.armor;

        if (equiped_armor != null)
        {
            equiped_armor.ApplyStats(gameObject);
        }

        //Weapon setup
        equiped_weapon = LootInventory.Instance.inventory.weapon;

        //Usable setup
        equiped_usable = LootInventory.Instance.inventory.usable;

        SkillsIconManager.Instance.SetupUsable(equiped_usable, out usableAmount);
    }

    public void UseUsable(InputAction.CallbackContext context)
    {
        if (isUsing) { return; }
        if (GetComponent<SpellsInventory>().ActiveCheck()) { return; }
        if (usableAmount <= 0) { return; }

        StartCoroutine(PreUse());
    }

    private void Use()
    {
        equiped_usable.Use(gameObject);
    }

    IEnumerator PreUse()
    {
        isUsing = true;
        equiped_usable.PreUse(gameObject);

        usableAmount--;
        SkillsIconManager.Instance.UpdateAmount(usableAmount);
        LootInventory.Instance.inventory.GlobalInventory.Remove(equiped_usable);

        yield return new WaitForSeconds(equiped_usable.usageTime);
        isUsing = false;

        Use();
    }

    public bool GetIsUsing()
    {
        return isUsing;
    }
}
