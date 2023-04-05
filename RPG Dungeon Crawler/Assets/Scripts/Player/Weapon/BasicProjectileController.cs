using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectileController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isColliding;

    [SerializeField] private float force;

    private float damage;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("DestroyObject", 10);
    }

    public void SetProperties(float _damage)
    {
        damage = _damage;
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

        if (!collision.gameObject.CompareTag(TAGS.ENEMY_TAG))
        {
            if (collision.gameObject.tag == TAGS.DESTRUCTABLE_TAG)
            {
                if (collision.gameObject.GetComponent<CapsuleCollider>() != null)
                    collision.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                else if (collision.gameObject.GetComponent<SphereCollider>() != null)
                    collision.gameObject.GetComponent<SphereCollider>().enabled = false;
                else if (collision.gameObject.GetComponent<MeshCollider>() != null)
                    collision.gameObject.GetComponent<MeshCollider>().enabled = false;

                collision.gameObject.GetComponent<EnemyExplode>().Explode();

                Destroy(collision.gameObject, 5);
            }

            DestroyObject();
            return;
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag(TAGS.PLAYER_TAG);

            float criticalMult = player.GetComponent<PlayerPassives>().TryCriticalDamage();

            if (player.GetComponent<PlayerPassives>().TryInstaKill())
                collision.transform.root.GetComponent<IDamagable>()?.TakeDamage(999999, player);
            else
                collision.transform.root.GetComponent<IDamagable>()?.TakeDamage(damage * criticalMult, player);

            DestroyObject();
        } 
    }

    private void DestroyObject()
    {
        GetComponent<ParticlesController>().SpawnExplosionParticles();
        Destroy(gameObject);
    }
}
