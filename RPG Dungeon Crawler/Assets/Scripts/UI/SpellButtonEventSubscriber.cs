using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButtonEventSubscriber : MonoBehaviour
{
    [SerializeField] private Spell currentSpellProperties;

    public void Click()
    {
        SpellsDescription.Instance.ShowDescription(currentSpellProperties);
    }
}
