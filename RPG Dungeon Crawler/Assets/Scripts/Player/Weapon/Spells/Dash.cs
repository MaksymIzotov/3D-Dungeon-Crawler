using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Spells/Dash", order = 1)]
public class Dash : Spell
{
    public LayerMask goThroughLayer;
    public float distance;

    [Space(10)]
    [Header("Upgrade amount")]
    public float cooldownReduce;
    public float priceMult;

    [Space(20)]
    [Header("Spell default stats")]
    public float def_cooldown;
    public int def_upgradePrice;

    public override void PreCast(Transform spellSpawnpoint)
    {

    }

    public override void Cast(Transform spellSpawnpoint)
    {
        spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), castAudio);
        spellSpawnpoint.root.GetComponent<CharacterController>().enabled = false;    

        RaycastHit hit;
        if (Physics.Raycast(spellSpawnpoint.root.position, spellSpawnpoint.root.forward, out hit, distance, ~goThroughLayer))
        {
            float dist = Vector3.Distance(spellSpawnpoint.transform.root.position, hit.point);
            Vector3 newPos = spellSpawnpoint.transform.root.position + (spellSpawnpoint.transform.root.forward * (dist-0.5f));
            spellSpawnpoint.root.position = new Vector3(newPos.x, spellSpawnpoint.transform.root.position.y, newPos.z);
        }
        else
        {
            Vector3 newPos = spellSpawnpoint.transform.root.position + (spellSpawnpoint.transform.root.forward * distance);
            spellSpawnpoint.root.position = newPos;
        }

        float stealthDamage = spellSpawnpoint.root.GetComponent<PlayerPassives>().TryStealthAttack();
        if (stealthDamage > 0)
        {
            Debug.Log("Working");
            Collider[] colliders = Physics.OverlapSphere(spellSpawnpoint.root.position, 7);
            foreach(Collider col in colliders)
            {
                if (col.CompareTag(TAGS.ENEMY_TAG))
                {
                    col.gameObject.GetComponent<IDamagable>()?.TakeDamage(stealthDamage, spellSpawnpoint.root.gameObject);
                }
            }
        }

        spellSpawnpoint.root.GetComponent<CharacterController>().enabled = true;
    }

    public override string Stats()
    {
        return "Cooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "Allows you to dash forward on a small distance. Goes through enemies";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        coolDownTime -= cooldownReduce;
    }

    public override void Reset()
    {
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;

        lvl = 1;
    }
}
