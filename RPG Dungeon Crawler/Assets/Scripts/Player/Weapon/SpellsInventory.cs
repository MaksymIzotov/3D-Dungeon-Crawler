using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsInventory : MonoBehaviour
{
    private enum STATE { 
        READY,
        ACTIVE,
        COOLDOWN
    }
    private STATE[] spellStates = new STATE[4] { STATE.READY, STATE.READY, STATE.READY, STATE.READY };
    private float[] activateTime = new float[4];
    private float[] cooldownTime = new float[4];

    private CooldownCountdown[] cooldownUI = new CooldownCountdown[4];

    public Spell[] spells;
    public Transform spellSpawnPoint;

    private void Start()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            activateTime[i] = spells[i].activateTime;
            cooldownTime[i] = spells[i].coolDownTime;
        }

        cooldownUI[0] = GameObject.Find("Spell01").GetComponent<CooldownCountdown>();
        cooldownUI[1] = GameObject.Find("Spell02").GetComponent<CooldownCountdown>();
        cooldownUI[2] = GameObject.Find("Spell03").GetComponent<CooldownCountdown>();
        cooldownUI[3] = GameObject.Find("Spell04").GetComponent<CooldownCountdown>();
    }

    private void Update()
    {
        InputDetector();
    }

    private void InputDetector()
    {
        if (ActiveCheck()) { return; }

        if (Input.GetKeyDown(InputManager.Instance.Spell01))
        {
            if (spellStates[0] != STATE.READY) { return; }

            //Use spell 01
            StartCoroutine(Activate(0));
            return;
        }
        if (Input.GetKeyDown(InputManager.Instance.Spell02))
        {
            if (spellStates[1] != STATE.READY) { return; }

            //Use spell 02
            StartCoroutine(Activate(1));
            return;
        }
        if (Input.GetKeyDown(InputManager.Instance.Spell03))
        {
            if (spellStates[2] != STATE.READY) { return; }

            //Use spell 03 
            StartCoroutine(Activate(2));
            return;
        }
        if (Input.GetKeyDown(InputManager.Instance.Spell04))
        {
            if (spellStates[3] != STATE.READY) { return; }

            //Use spell 04 
            StartCoroutine(Activate(3));
            return;
        }
    }

    IEnumerator Activate(int index) {
        spells[index]?.PreCast(gameObject);
        spellStates[index] = STATE.ACTIVE;
        yield return new WaitForSeconds(activateTime[index]);

        spells[index].Cast(spellSpawnPoint);
        spellStates[index] = STATE.COOLDOWN;

        StartCoroutine(Cooldown(index));
    }

    IEnumerator Cooldown(int index)
    {
        cooldownUI[index].SetTimer(cooldownTime[index]);
        yield return new WaitForSeconds(cooldownTime[index]);

        spellStates[index] = STATE.READY;
    }


    private bool ActiveCheck()
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
