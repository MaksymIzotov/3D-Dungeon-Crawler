using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassives : MonoBehaviour
{
    public float damage;
    public float fireDamage;
 
    private bool isReturnDamage = false;
    private float returnDamage;

    private bool isBurnEffect = false;
    private float burnDamage;

    private bool isBlockingOn = false;
    private float blockingChance;

    private bool isStunOn = false;
    private float stunChance;

    private bool isStealthAttackOn = false;
    private float stealthChance;
    private float stealthAttackDamage;

    private float criticalDamage;
    private float criticalChance;

    private bool isInstaKillOn = false;
    private float instaKillChance;

    public List<PassiveDescription> activePassives = new List<PassiveDescription>();

    public void EnableBurnDamage(float _burnDamage, PassiveDescription passiveDescription)
    {
        isBurnEffect = true;
        burnDamage = _burnDamage;

        activePassives.Add(passiveDescription);
    }

    public float GetBurnDamage()
    {
        if (isBurnEffect)
            return burnDamage;
        else
            return 0;
    }

    public void EnableDamageReturn(float _returnDamage, PassiveDescription passiveDescription)
    {
        isReturnDamage = true;
        returnDamage = _returnDamage;

        activePassives.Add(passiveDescription);
    }

    public void ReturnDamage(GameObject enemy, float damage)
    {
        if (!isReturnDamage) { return; }

        float returnAmount = damage / 100 * returnDamage;
        enemy.GetComponent<IDamagable>()?.TakeDamage(returnAmount, gameObject);
    }

    public void EnableBlocking(float chance, PassiveDescription passiveDescription)
    {
        isBlockingOn = true;
        blockingChance = chance;

        activePassives.Add(passiveDescription);
    }

    public bool TryBlockDamage()
    {
        if (!isBlockingOn) { return false; }

        int rand = Random.Range(0, 100);
        if(rand < blockingChance)
        {
            return true;
        }

        return false;
    }

    public void EnableStun(float chance, PassiveDescription passiveDescription)
    {
        isStunOn = true;
        stunChance = chance;

        activePassives.Add(passiveDescription);
    }

    public bool TryStun()
    {
        if (!isStunOn) { return false; }

        int rand = Random.Range(0, 100);
        if (rand < stunChance)
        {
            return true;
        }

        return false;
    }

    public void EnableStealthAttack(float chance, float damage, PassiveDescription passiveDescription)
    {
        isStealthAttackOn = true;
        stealthChance = chance;
        stealthAttackDamage = damage;

        activePassives.Add(passiveDescription);
    }

    public float TryStealthAttack()
    {
        if (!isStealthAttackOn) { return 0; }

        int rand = Random.Range(0, 100);
        if (rand < stealthChance)
        {
            return stealthAttackDamage;
        }

        return 0;
    }

    public void SetupCriticalDamage(float chance, float damage, PassiveDescription passiveDescription)
    {
        criticalChance = chance;
        criticalDamage = damage;

        activePassives.Add(passiveDescription);
    }

    public float TryCriticalDamage()
    {
        int rand = Random.Range(0, 100);
        if (rand < criticalChance)
        {
            return criticalDamage / 100;
        }

        return 1;
    }

    public void EnableInstaKill(float chance, PassiveDescription passiveDescription)
    {
        isInstaKillOn = true;
        instaKillChance = chance;

        activePassives.Add(passiveDescription);
    }

    public bool TryInstaKill()
    {
        if (!isInstaKillOn) { return false; }

        float rand = Random.Range(0, 100);
        if (rand < instaKillChance)
        {
            return true;
        }

        return false;
    }
}
