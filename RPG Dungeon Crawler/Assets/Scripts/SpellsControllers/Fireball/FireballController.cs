using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isColliding;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float force;

    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;

    private float damage;
    private float burnDamage;

    private bool isFireball;

    private PlayerPassives passives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("DestroyObject", 10);
    }

    public void SetProperties(float _damage, bool _isFireball)
    {
        passives = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG).GetComponent<PlayerPassives>();

        damage = _damage;     
        isFireball = _isFireball;

        if (isFireball)
        {
            burnDamage = passives.GetBurnDamage();
            damage += passives.fireDamage;
        }        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * force * Time.deltaTime);
    }

    private void Update()
    {
        isColliding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) { return; }
        isColliding = true;
        GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

        float criticalMult = passives.TryCriticalDamage();

        //Do damage
        bool isPlayerHit = false;
        var collidersInRange = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider n in collidersInRange)
        {
            if (n.tag == TAGS.PLAYER_TAG)
            {
                if (isPlayerHit) { continue; }

                n.gameObject.GetComponent<PlayerController>().AddImpact(transform, explosionForce);
                n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage, null);
                isPlayerHit = true;
            }
            else if (n.tag == TAGS.ENEMY_TAG)
            {
                if (passives.TryInstaKill())
                    n.transform.root.GetComponent<IDamagable>()?.TakeDamage(999999, player);
                else
                    n.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage * criticalMult, player);

                if (burnDamage > 0)
                {
                    GetComponent<ParticlesController>().SpawnBurnParticles(n.transform.root, 3f, burnDamage);
                }
            }
            else if(n.tag == TAGS.DESTRUCTABLE_TAG)
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

        DestroyObject();
    }

    private void DestroyObject()
    {
        GetComponent<ParticlesController>().SpawnExplosionParticles();
        Destroy(gameObject);
    }
}
