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

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text spellName;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private TMP_Text description;

    public Spell currentSpellDisplayed;

    public void ShowDescription(Spell spell)
    {
        icon.sprite = spell.icon;
        spellName.text = spell.name;
        stats.text = spell.Stats();
        description.text = spell.Desription();

        currentSpellDisplayed = spell;
    }
}
