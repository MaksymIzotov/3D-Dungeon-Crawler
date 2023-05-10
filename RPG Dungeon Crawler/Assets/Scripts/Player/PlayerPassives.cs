using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    private int blockAmount;
    private PassiveDescription shieldDescription;

    public bool isInvisible = false;

    public List<PassiveDescription> activePassives = new List<PassiveDescription>();

    [SerializeField] private PassiveDescription poisonPassiveDescription;

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

    public void EnableShield(int amount, PassiveDescription passiveDescription)
    {
        blockAmount = amount;

        shieldDescription = passiveDescription;
        activePassives.Add(passiveDescription);

        StartCoroutine(ShieldFadeOn());
        PassiveDescriptionShow.Instance.UpdatePassives();
    }

    public bool TryShieldBlocking()
    {
        if (blockAmount <= 0) return false;

        blockAmount--;

        if(blockAmount <= 0)
        {
            //Remove FX
            StartCoroutine(ShieldFadeOff());
            activePassives.Remove(shieldDescription);
        }

        return true;
    }

    public void EnableInvisibility(bool toggle, PassiveDescription description)
    {
        isInvisible = toggle;

        if (toggle)
            activePassives.Add(description);
        else
            activePassives.Remove(description);

        PassiveDescriptionShow.Instance.UpdatePassives();
    }

    public void Poison(float damage)
    {
       if(activePassives.Contains(poisonPassiveDescription))
            activePassives.Remove(poisonPassiveDescription);

        StopCoroutine("DealPoisonDamage");
        StartCoroutine(DealPoisonDamage(damage));

        activePassives.Add(poisonPassiveDescription);
        PassiveDescriptionShow.Instance.UpdatePassives();
    }

    IEnumerator DealPoisonDamage(float damage)
    {
        int amount = 0;
        while (amount < 5)
        {         
            yield return new WaitForSeconds(1);

            GetComponent<IDamagable>().TakeDamage(damage, null);
            amount++;
        }

        activePassives.Remove(poisonPassiveDescription);
        PassiveDescriptionShow.Instance.UpdatePassives();
    }

    IEnumerator ShieldFadeOn()
    {
        Image transitionUI = GameObject.Find("ShieldFX").GetComponent<Image>();

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            transitionUI.color = new Color(transitionUI.color.r, transitionUI.color.g, transitionUI.color.b, i);
            yield return null;
        }

        transitionUI.color = new Color(transitionUI.color.r, transitionUI.color.g, transitionUI.color.b, 255);
    }

    IEnumerator ShieldFadeOff()
    {
        Image transitionUI = GameObject.Find("ShieldFX").GetComponent<Image>();

        for (float i = 1; i >= 0; i -= Time.deltaTime * 2)
        {
            // set color with i as alpha
            transitionUI.color = new Color(transitionUI.color.r, transitionUI.color.g, transitionUI.color.b, i);
            yield return null;
        }

        transitionUI.color = new Color(transitionUI.color.r, transitionUI.color.g, transitionUI.color.b, 0);
    }
}
