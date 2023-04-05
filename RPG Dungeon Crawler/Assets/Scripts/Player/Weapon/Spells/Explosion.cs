using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Explosion", menuName = "Spells/Explosion", order = 1)]
public class Explosion : Spell
{
    [Space(10)]
    [Header("Main properties")]
    public GameObject explosionFX;

    public float damage;

    [Space(10)]
    [Header("Upgrade amount")]
    public float damageMult;
    public float cooldownReduce;
    public float priceMult;

    [Space(20)]
    [Header("Spell default stats")]
    public float def_damage;
    public float def_cooldown;
    public int def_upgradePrice;

    public override void PreCast(Transform spellSpawnpoint)
    {
        //Animation
        GameObject player = spellSpawnpoint.root.gameObject;
        player.GetComponent<AnimationManager>().PlayPlayerAnimation(ANIMATIONS.EXPLOSION_ANIM);

        //Play audio (riser)
        spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), preCastAudio);
    }

    public override void Cast(Transform spellSpawnpoint)
    {
        GameObject player = spellSpawnpoint.root.gameObject;
        Instantiate(explosionFX, player.transform.position, Quaternion.identity);

        float criticalMult = player.GetComponent<PlayerPassives>().TryCriticalDamage();

        //Do damage
        var collidersInRange = Physics.OverlapSphere(player.transform.position, 10);

        foreach (Collider n in collidersInRange)
        {
            if (n.tag == TAGS.ENEMY_TAG)
            {
                if (player.GetComponent<PlayerPassives>().TryInstaKill())
                    n.transform.root.GetComponent<IDamagable>()?.TakeDamage(999999, player);
                else
                    n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage * criticalMult, player);

                if (player.GetComponent<PlayerPassives>().GetBurnDamage() > 0)
                {
                    player.GetComponent<ParticlesController>().SpawnBurnParticles(n.transform.root, 3f, player.GetComponent<PlayerPassives>().GetBurnDamage());
                }
            }
            else if (n.tag == TAGS.DESTRUCTABLE_TAG)
            {
                if (n.GetComponent<CapsuleCollider>() != null)
                    n.GetComponent<CapsuleCollider>().enabled = false;
                else if (n.GetComponent<SphereCollider>() != null)
                    n.GetComponent<SphereCollider>().enabled = false;
                else if (n.GetComponent<MeshCollider>() != null)
                    n.GetComponent<MeshCollider>().enabled = false;

                n.GetComponent<EnemyExplode>().Explode();

                Destroy(n.gameObject, 5);
            }
        }

        //Shake the camera
        spellSpawnpoint.root.GetComponent<CameraShake>().EnableShaking(0.6f);

         // Play audio (explosion)
         spellSpawnpoint.root.GetComponent<PlayerAudio>().PlayAudio(spellSpawnpoint.root.GetComponent<AudioSource>(), castAudio);
    }

    public override void CastUpgraded(Transform spellProperty)
    {

    }

    public override string Stats()
    {
        return "Damage: " + damage.ToString("F") + "\nCooldown: " + coolDownTime.ToString("F");
    }

    public override string Desription()
    {
        return "Creates an explosion around the player damaging everyone around";
    }

    public override void UpgradeStats()
    {
        float newPrice = upgradePrice * priceMult;
        upgradePrice = (int)newPrice;

        coolDownTime -= cooldownReduce;
        damage *= damageMult;
    }

    public override void Reset()
    {
        damage = def_damage;
        coolDownTime = def_cooldown;
        upgradePrice = def_upgradePrice;

        lvl = 1;
    }
}
