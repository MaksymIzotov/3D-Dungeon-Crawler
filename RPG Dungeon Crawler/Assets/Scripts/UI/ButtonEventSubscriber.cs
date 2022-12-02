using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventSubscriber : MonoBehaviour
{
    [SerializeField] private Spell currentSpellProperties;
    [SerializeField] private LootInfo currentItemProperties;

    public void ClickSpell()
    {
        SpellsDescription.Instance.ShowDescription(currentSpellProperties);
    }

    public void ClickItem()
    {

    }
}
