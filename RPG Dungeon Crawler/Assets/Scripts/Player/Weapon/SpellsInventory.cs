using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellsInventory : MonoBehaviour
{
    private enum STATE { 
        READY,
        ACTIVE,
        COOLDOWN
    }
    private STATE[] spellStates = new STATE[4] { STATE.READY, STATE.READY, STATE.READY, STATE.READY };

    private CooldownCountdown[] cooldownUI = new CooldownCountdown[4];

    private Spell[] spells;
    public Transform spellSpawnPoint;

    private void Start()
    {
        spells = new Spell[4];
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = LootInventory.Instance.inventory.equipedSpells[i];
        }

        cooldownUI[0] = GameObject.Find("Spell01").GetComponent<CooldownCountdown>();
        cooldownUI[1] = GameObject.Find("Spell02").GetComponent<CooldownCountdown>();
        cooldownUI[2] = GameObject.Find("Spell03").GetComponent<CooldownCountdown>();
        cooldownUI[3] = GameObject.Find("Spell04").GetComponent<CooldownCountdown>();

        SkillsIconManager.Instance.SetupIcon(spells);
    }

    public void Spell01Cast(InputAction.CallbackContext context)
    {
        if (GameStates.Instance.state == GameStates.STATE.PAUSE
            || GameStates.Instance.state == GameStates.STATE.LOST
            || GameStates.Instance.state == GameStates.STATE.WON) { return; }

        if (spells[0] == null) { return; }
        if (ActiveCheck()) { return; }
        if (GetComponent<PlayerItemController>().GetIsUsing()) { return; }
        if (spellStates[0] != STATE.READY) { return; }

        //Use spell 01
        StartCoroutine(Activate(0));
    }
    public void Spell02Cast(InputAction.CallbackContext context)
    {
        if (GameStates.Instance.state == GameStates.STATE.PAUSE
             || GameStates.Instance.state == GameStates.STATE.LOST
             || GameStates.Instance.state == GameStates.STATE.WON) { return; }

        if (spells[1] == null) { return; }
        if (ActiveCheck()) { return; }
        if (GetComponent<PlayerItemController>().GetIsUsing()) { return; }
        if (spellStates[1] != STATE.READY) { return; }

        //Use spell 01
        StartCoroutine(Activate(1));
    }
    public void Spell03Cast(InputAction.CallbackContext context)
    {
        if (GameStates.Instance.state == GameStates.STATE.PAUSE
            || GameStates.Instance.state == GameStates.STATE.LOST
            || GameStates.Instance.state == GameStates.STATE.WON) { return; }

        if (spells[2] == null) { return; }
        if (ActiveCheck()) { return; }
        if (GetComponent<PlayerItemController>().GetIsUsing()) { return; }
        if (spellStates[2] != STATE.READY) { return; }

        //Use spell 01
        StartCoroutine(Activate(2));
    }
    public void Spell04Cast(InputAction.CallbackContext context)
    {
        if (GameStates.Instance.state == GameStates.STATE.PAUSE
            || GameStates.Instance.state == GameStates.STATE.LOST
            || GameStates.Instance.state == GameStates.STATE.WON) { return; }

        if (spells[3] == null) { return; }
        if (ActiveCheck()) { return; }
        if (GetComponent<PlayerItemController>().GetIsUsing()) { return; }
        if (spellStates[3] != STATE.READY) { return; }

        //Use spell 01
        StartCoroutine(Activate(3));
    }

    IEnumerator Activate(int index) {
        spells[index]?.PreCast(spellSpawnPoint);
        spellStates[index] = STATE.ACTIVE;
        yield return new WaitForSeconds(spells[index].activateTime);

        spells[index].Cast(spellSpawnPoint);

        StartCoroutine(AfterActivate(index));
    }

    IEnumerator AfterActivate(int index)
    {
        yield return new WaitForSeconds(spells[index].afterActivateTime);
        spells[index].AfterCast(spellSpawnPoint);
        spellStates[index] = STATE.COOLDOWN;

        StartCoroutine(Cooldown(index));
    }

    IEnumerator Cooldown(int index)
    {
        cooldownUI[index].SetTimer(spells[index].coolDownTime);
        yield return new WaitForSeconds(spells[index].coolDownTime);

        spellStates[index] = STATE.READY;
    }


    public bool ActiveCheck()
    {
        for (int i = 0; i < spellStates.Length; i++)
        {
            if (spellStates[i] == STATE.ACTIVE)
            {
                return true;
            }
        }

        return false;
    }
}
