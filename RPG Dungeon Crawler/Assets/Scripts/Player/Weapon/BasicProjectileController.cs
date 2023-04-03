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
