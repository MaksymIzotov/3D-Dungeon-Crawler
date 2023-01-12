using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventSubscriber : MonoBehaviour
{
    public Spell currentSpellProperties;
    public Item currentItemProperties;


    public void ClickSpell()
    {
        SpellsDescription.Instance.ShowDescription(currentSpellProperties);
    }

    public void ClickItem()
    {
        InventoryDescription.Instance.ShowDescription(currentItemProperties);
    }

    public void ClickItemClone()
    {
        CloneMenuController.Instance.ShowDescription(currentItemProperties);
    }
}
