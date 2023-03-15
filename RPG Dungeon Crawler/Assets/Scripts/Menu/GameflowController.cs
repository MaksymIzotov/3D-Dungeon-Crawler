using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameflowController : MonoBehaviour
{
    #region SIngleton Init
    public static GameflowController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private CurrentSettings settings;
    public UnityEvent onStartGame;
    public UnityEvent onBossStart;
    public UnityEvent onContinuePlaying;
    public UnityEvent onNewGameStarted;

    private int bossCrystalsAmount = 15;

    private void Start()
    {
        TabManager.Instance.OpenTab("input");
        MenuManager.Instance.OpenMenu("main");

        if (settings.isPlaying)
            onContinuePlaying.Invoke();
    }
    
    public void TryStartGame()
    {
        bool isSpellsEquipped = false;
        bool isDamageSpellEquipped = false;

        foreach(Spell spell in MenuInventoryController.Instance.inventory.equipedSpells)
        {
            if(spell != null)
            {
                isSpellsEquipped = true;
                if (spell.isDamage)
                    isDamageSpellEquipped = true;
            }
        }

        if (!isSpellsEquipped)
        {
            MenuNotification.Instance.ShowMessage("You have no spells equipped. Equip spells in the spells book");
            return;
        }
        else if(!isDamageSpellEquipped)
        {
            MenuNotification.Instance.ShowMessage("You have no damage spells equipped. Equip at least one damage spell to enter the dungeon");
            return;
        }

        onStartGame.Invoke();
    }

    public void TryBossFight()
    {
        if(MenuInventoryController.Instance.inventory.moneyInventory.amountCrystals < bossCrystalsAmount)
        {
            MenuNotification.Instance.ShowMessage("Not enough crystals to enter boss dungeon");
            return;
        }

        bool isSpellsEquipped = false;
        bool isDamageSpellEquipped = false;

        foreach (Spell spell in MenuInventoryController.Instance.inventory.equipedSpells)
        {
            if (spell != null)
            {
                isSpellsEquipped = true;
                if (spell.isDamage)
                    isDamageSpellEquipped = true;
            }
        }

        if (!isSpellsEquipped)
        {
            MenuNotification.Instance.ShowMessage("You have no spells equipped. Equip spells in the spells book");
            return;
        }
        else if (!isDamageSpellEquipped)
        {
            MenuNotification.Instance.ShowMessage("You have no damage spells equipped. Equip at least one damage spell to enter the dungeon");
            return;
        }

        onBossStart.Invoke();
    }

    public void StartGame()
    {
        settings.isPlaying = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeBossCrystalsAmount(int amount)
    {
        bossCrystalsAmount = amount;
    }

    public int GetBossCrystalsAmount() {
        return bossCrystalsAmount;
    }
}
